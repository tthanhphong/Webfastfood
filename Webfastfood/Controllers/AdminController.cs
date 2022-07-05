using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webfastfood.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Webfastfood.Controllers
{
    public class AdminController : Controller
    {
        public class ChiTietDonHang_
        {
            public ChiTietDDH ctddh { get; set; }
            public SanPham sp { get; set; }
           
            
        }
        public class KhachHang_
        {
            public KhachHang kh { get; set; }
        }
        dtbFastFoodDataContext db = new dtbFastFoodDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPham(int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 6;
            return View(db.SanPhams.ToList().OrderBy(n => n.IDSanPham).ToPagedList(pageNum, pageSize));
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendangnhap = collection["username"];
            var matkhau = collection["password"];
            if (string.IsNullOrEmpty(tendangnhap))
            {
                ViewData["loi1"] = "Tên đăng nhập không được để trống";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi2"] = "Mật khẩu không được để trống";
            }
            else
            {
                Admin admin = db.Admins.SingleOrDefault(n => n.UserAdmin == tendangnhap && n.PassAdmin == matkhau);
                if (admin != null)
                {
                    ViewBag.Thongbao = "Đăng Nhập Thành Công";
                    Session["TaiKhoan"] = admin;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Thongbao = "Tên Đăng nhập hoặc mật khẩu không đúng";
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult ThemMonMoi()
        {
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSanPham), "IDLoaiSanPham", "TenLoaiSanPham");
            return View();

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMonMoi(SanPham sanPham, HttpPostedFileBase fileupload)
        {
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSanPham), "IDLoaiSanPham", "TenLoaiSanPham");
            if (fileupload == null)
            {
                ViewBag.ThongBao = "Hãy Thêm Ảnh Vào";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    // luu ten file
                    var filename = Path.GetFileName(fileupload.FileName);
                    //luu duong dan
                    var path = Path.Combine(Server.MapPath("~/product_Img"),filename);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    sanPham.HinhAnh = filename;
                    // luu vao csdl
                    db.SanPhams.InsertOnSubmit(sanPham);
                    db.SubmitChanges();

                }
                return RedirectToAction("SanPham");
            }
        }
        [HttpGet]
        public ActionResult XoaMon(int id)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.IDSanPham == id);
            ViewBag.IDSanPham = sanPham.IDSanPham;
            if(sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanPham);
        }
        [HttpPost, ActionName("XoaMon")]
        public ActionResult XacNhanXoa(int id)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.IDSanPham == id);
            ViewBag.IDSanPham = sanPham.IDSanPham;
            if (sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SanPhams.DeleteOnSubmit(sanPham);
            db.SubmitChanges();
            return RedirectToAction("SanPham");
        }
        [HttpGet]
        public ActionResult SuaMon(int id)
        {
            
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.IDSanPham == id);
            if(sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSanPham),"IDLoaiSanPham","TenLoaiSanPham",sanPham.IDLoaiSanPham);
            return View(sanPham);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaMon(SanPham sanPham, HttpPostedFileBase fileupload)
        {
            ViewBag.IDLoaiSanPham = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSanPham), "IDLoaiSanPham", "TenLoaiSanPham");         
            int.TryParse(HttpContext.Request.Form["IDSanPham"], out int idSP);
            SanPham sanPham1 = db.SanPhams.SingleOrDefault(n => n.IDSanPham == idSP);
            UpdateModel(sanPham1);
            db.SubmitChanges();
            return RedirectToAction("SanPham");
        }
        public ActionResult ChuThich(int id)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(n => n.IDSanPham == id);
            ViewBag.IDSanPham = sanPham.IDSanPham;
            if (sanPham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanPham);
        }
        public ActionResult Details(int id)
        {
            var mon = from x in db.SanPhams where x.IDSanPham == id select x;
            return View(mon.Single());
        }
        public ActionResult DonHang()
        {
            return View(db.DonDatHangs.ToList());
        }
        [HttpGet]
        public ActionResult Edit( int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.SingleOrDefault(n => n.IDDonDatHang == id);
            if(donDatHang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHangs.ToList().OrderBy(n => n.DaThanhToan), "IDDonDatHang", "DaThanhToan");
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHangs.ToList().OrderBy(n => n.TrangThaiGiaoHang), "IDDonDatHang", "TrangThaiGiaoHang");
            return View(donDatHang);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DonDatHang donDatHang )
        {
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHangs.ToList().OrderBy(n => n.DaThanhToan), "IDDonDatHang", "DaThanhToan");
            ViewBag.IDDonDatHang = new SelectList(db.DonDatHangs.ToList().OrderBy(n => n.TrangThaiGiaoHang), "IDDonDatHang", "TrangThaiGiaoHang");
            
            int.TryParse(HttpContext.Request.Form["IDDonDatHang"], out int IDDonDH);
            DonDatHang ddh = db.DonDatHangs.SingleOrDefault(n => n.IDDonDatHang == IDDonDH);
            UpdateModel(ddh);
            db.SubmitChanges();
            return RedirectToAction("DonHang");
        }
        
        public ActionResult ChiTiet(int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.SingleOrDefault(n => n.IDDonDatHang == id);
            //ChiTietDonHang_ ctdh = (from ddh in data.DonDatHangs join kh in data.KhachHangs on ddh.IDKhachHang equals kh.IDKhachHang
            //                        into chitiet from ct in chitiet.DefaultIfEmpty()
            //                        select new ChiTietDonHang_ { ddh = ddh, kh = ct }).SingleOrDefault(n => n.ddh.IDDonDatHang == id);
            List<ChiTietDonHang_> ctdh = (from ctddh in db.ChiTietDDHs
                                          join sp in db.SanPhams on ctddh.IDSanPham equals sp.IDSanPham
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
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            List<ChiTietDDH> chiTietDDH = db.ChiTietDDHs.Where(n => n.IDDonDatHang == id).ToList();
            if (chiTietDDH.Count == 0)
            {
                Response.StatusCode = 404;
                return RedirectToAction("DonHang", "Admin");
            }
            db.ChiTietDDHs.DeleteAllOnSubmit(chiTietDDH);
            db.SubmitChanges();

            DonDatHang donDatHang = db.DonDatHangs.SingleOrDefault(n => n.IDDonDatHang == id);
            if (donDatHang == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("DonHang", "Admin");
            }
            db.DonDatHangs.DeleteOnSubmit(donDatHang);
            db.SubmitChanges();

            // return View(chiTietDDH);
            return RedirectToAction("DonHang", "Admin");
        }
        public ActionResult QLKH(int? page)
        {
            int pageNum = (page ?? 1);
            int pageSize = 100;
            return View(db.KhachHangs.ToList().OrderBy(n => n.IDKhachHang).ToPagedList(pageNum, pageSize));
        }
        
        public ActionResult XoaKH(int id)
        {

            KhachHang khachHang = db.KhachHangs.FirstOrDefault(n => n.IDKhachHang == id);
            if (khachHang == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("QLKH", "Admin");
            }
            db.KhachHangs.DeleteOnSubmit(khachHang);
            db.SubmitChanges();
            return RedirectToAction("QLKH", "Admin");
        }
    }
}