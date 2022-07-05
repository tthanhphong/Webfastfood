using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Webfastfood.Models;

namespace Webfastfood.Controllers
{
    public class NguoidungController : Controller
    {
        dtbFastFoodDataContext db = new dtbFastFoodDataContext();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        
        
        [HttpPost]
        public ActionResult DangKy(FormCollection collection,KhachHang kh) 
        {
            var hoten = collection["HoTenKhachHang"];
            var tendangnhap = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var matkhaunhaplai = collection["MatKhauNhapLai"];
            var email = collection["Email"];
            var dienthoai = collection["DienThoai"];
            var diachi = collection["DiaChi"];
            var ngaysinh = string.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            if(string.IsNullOrEmpty(hoten))
            {
                ViewData["loi1"] = "Họ tên khách hàng không được để trống!";
            }
            if (string.IsNullOrEmpty(tendangnhap))
            {
                ViewData["loi2"] = "Tài khoảng không được để trống!";
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["loi3"] = "Mật Khẩu không được để trống!";
            }
            if (string.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["loi4"] = "Mật khẩu nhập lại không được để trống!";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewData["loi5"] = "Email không được để trống!";
            }
            if (string.IsNullOrEmpty(dienthoai))
            {
                ViewData["loi6"] = "Số điện thoại không được để trống!";
            }
            if (string.IsNullOrEmpty(diachi))
            {
                ViewData["loi7"] = "Địa chỉ không được để trống!";
            }
            else
            {
                //up to dtb
                kh.HoTenKhachHang = hoten;
                kh.TaiKhoan = tendangnhap;
                kh.MatKhau = matkhau;
                kh.Email = email;
                kh.SoDienThoai = dienthoai;
                kh.DiaChi = diachi;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["TenDN"];
            var matkhau = collection["MatKhau"];
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
                KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == tendangnhap && n.MatKhau == matkhau);
                if(kh != null)
                {
                    ViewBag.Thongbao = "Đăng Nhập Thành Công";
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Index", "FastFood");
                }
                else
                {
                    ViewBag.Thongbao = "Tên Đăng nhập hoặc mật khẩu không đúng";
                }

            }
            return View();
        }
        [NonAction]
        public void sendcontact(string Name, string Email, string Subject, string Content)
        {

            var fromEmail = new MailAddress("thanhdatpqkg23@outlook.com");
            var toEmail = new MailAddress("thanhdatpqkg23@gmail.com");
            var fromEmailPassword = "Teoconpq2001"; // replace with actual password
            string subject = Subject;
            string body = "<br/> Họ tên: " + Name + "<br/><br/> Email: " + " " + Email + "<br/><br/> Nội dung: " + Content;

            var smtp = new SmtpClient
            {
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            }) smtp.Send(message);
        }
        public ActionResult gioithieu()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Lienhe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lienhe(LienHeModel lienhe)
        {
            if (ModelState.IsValid)
            {
                sendcontact(lienhe.Name, lienhe.Email, lienhe.Subject, lienhe.Message);
                return RedirectToAction("thongbaolienhe", "User");

            }
            else
            {

            }
            return View(lienhe);
        }
        public ActionResult thongbaolienhe()
        {
            return View();
        }
    }
}