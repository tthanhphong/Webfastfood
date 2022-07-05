using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webfastfood.Models;
using PagedList;
using PagedList.Mvc; 

namespace Webfastfood.Controllers
{
    public class ChiTietDonHang_
    {
        public ChiTietDDH ctddh { get; set; }
        public SanPham sp { get; set; }
    }
    public class FastFoodController : Controller
    {
        // GET: FastFood
        dtbFastFoodDataContext data = new dtbFastFoodDataContext();
        private List<SanPham> LaySanPhamMoi(int count)
        {
            return data.SanPhams.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            // tao bien quy dinh mon an/trang
            int pageSize = 9;
            int pageNum = (page ?? 1);
            var monmoi = LaySanPhamMoi(20);
            return View(monmoi.ToPagedList(pageNum,pageSize));
        }

        public ActionResult Menu()
        {
            var menu = from cd in data.LoaiSanPhams select cd;
            return PartialView(menu);
        }
        public ActionResult SPTheoMenu(int id)
        {
            var mon = from x in data.SanPhams where x.IDLoaiSanPham == id select x;
            return View(mon);
        }
        public ActionResult Details(int id)
        {
            var mon = from x in data.SanPhams where x.IDSanPham == id select x;
            return View(mon.Single());
        }
        public ActionResult DonHang()
        {
            return View(data.DonDatHangs.ToList());
        }

        public ActionResult ChiTietDonHang(int id)
        {
            DonDatHang donDatHang = data.DonDatHangs.SingleOrDefault(n => n.IDDonDatHang == id);
            List<ChiTietDonHang_> ctdh = (from ctddh in data.ChiTietDDHs
                                          join sp in data.SanPhams on ctddh.IDSanPham equals sp.IDSanPham
                                          into chitiet
                                          from ct in chitiet.DefaultIfEmpty()
                                          select new ChiTietDonHang_ { ctddh = ctddh, sp = ct }).Where(n => n.ctddh.IDDonDatHang == id).ToList();
            ViewBag.IDDonDatHanng = donDatHang.IDDonDatHang;
            ViewBag.ctdh = ctdh;
            if (donDatHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donDatHang);
        }
        //xoa chi tiet truoc roi moi xoa don hang, phải tạo cái view cho 2 thằng này
        public ActionResult XoaChiTietDonHang(int id)
        {
            ChiTietDDH chiTietDDH = data.ChiTietDDHs.Where(n => n.IDDonDatHang == id).FirstOrDefault();
            ViewBag.IDDonDatHang = chiTietDDH.IDDonDatHang;
            if (chiTietDDH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chiTietDDH);
        }
        [HttpPost, ActionName("XoaChiTietDonHang")]
        public ActionResult XNXoaChiTietDonHang(int id)
        {
            ChiTietDDH chiTietDDH = data.ChiTietDDHs.Where(n => n.IDDonDatHang == id).FirstOrDefault();
            ViewBag.IDDonDatHang = chiTietDDH.IDDonDatHang;
            if (chiTietDDH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.ChiTietDDHs.DeleteOnSubmit(chiTietDDH);
            data.SubmitChanges();
           // return View(chiTietDDH);
            return RedirectToAction("DonHang", "FastFood");

        }
        //sau khi xoa duoc chi tiet ta tiep tuc xoa don hang
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DonDatHang donDatHang = data.DonDatHangs.Where(n => n.IDDonDatHang == id).FirstOrDefault();
            ViewBag.IDDonDatHang = donDatHang.IDDonDatHang;
            if (donDatHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donDatHang);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanHuy(int id)
        {
            DonDatHang donDatHang = data.DonDatHangs.Where(n => n.IDDonDatHang == id).FirstOrDefault();
            ViewBag.IDDonDatHang = donDatHang.IDDonDatHang;
            if (donDatHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.DonDatHangs.DeleteOnSubmit(donDatHang);
            data.SubmitChanges();
            return RedirectToAction("DonHang");
        }

    }
}