using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webfastfood.Models;

namespace Webfastfood.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        dtbFastFoodDataContext data = new dtbFastFoodDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang== null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang; 
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iIDSanPham,string strURL)
        {
            // lay session
            List<GioHang> lstGioHang = LayGioHang();
            //kiem tra mon an da chon vao gio hang chua
            GioHang sanpham = lstGioHang.Find(n => n.iIDSanPham == iIDSanPham);
            if(sanpham == null)
            {
                sanpham = new GioHang(iIDSanPham);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        // tong so luong
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if(lstGioHang!=null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return iTongTien;
        }
        // tao gio hang
        public ActionResult GioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            if(lstGioHang.Count==0)
            {
                return RedirectToAction("Index", "FastFood");
                
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        public ActionResult GioHangPatial ()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iIDSanPham == iMaSP);
            if (lstGioHang!=null)
            {
                lstGioHang.RemoveAll(n => n.iIDSanPham == iMaSP);
                return RedirectToAction("GioHang");

            }
            if (lstGioHang.Count == 0)
            {
                
                return RedirectToAction("Index","FastFood");

            }
            return RedirectToAction("GioHang"); 
        }
        public ActionResult XoaTatcaGiohang()
        {
            List<GioHang> dsGiohang = LayGioHang();
            dsGiohang.Clear();
            return RedirectToAction("Index", "FastFood");
        }
        public ActionResult CapNhatGioHang(int iMaSP,FormCollection f)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iIDSanPham == iMaSP);
            if(sanpham!=null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang"); 
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            //kiem tra dang nhap
            if(Session["TaiKhoan"]==null || Session["TaiKhoan"].ToString()=="")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null || Session["GioHang"].ToString() == "")
            {
                return RedirectToAction("Index","FastFood");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        public ActionResult DatHang(FormCollection collection)
        {
            //them don hàng
            DonDatHang ddh = new DonDatHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.IDKhachHang = kh.IDKhachHang;
            ddh.NgayDH = DateTime.Now;
            var ngaygiao = string.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            ddh.NgayGiao = DateTime.Parse(ngaygiao);
            ddh.TrangThaiGiaoHang = false;
            ddh.DaThanhToan = false;
            data.DonDatHangs.InsertOnSubmit(ddh);
            data.SubmitChanges();
            //them chi tiet don hang
            foreach(var item in gh)
            {
                ChiTietDDH ctddh = new ChiTietDDH();
                ctddh.IDDonDatHang = ddh.IDDonDatHang;
                ctddh.IDSanPham = item.iIDSanPham;
                ctddh.SoLuong = item.iSoLuong;
                ctddh.Gia = (decimal) item.dDonGia;
                data.ChiTietDDHs.InsertOnSubmit(ctddh);
            }
            data.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }
        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}
