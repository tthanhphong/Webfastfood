using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Webfastfood.Models
{
    public class GioHang
    {
        dtbFastFoodDataContext data = new dtbFastFoodDataContext();
        public int iIDSanPham { set; get; }
        public string STenSanPham { set; get; }
        public string SHinhAnh { set; get; }
        public Double dDonGia { set; get; }
        public int iSoLuong { set; get; }
        public Double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int IDSanPham)
        {
            iIDSanPham = IDSanPham;
            SanPham sanPham = data.SanPhams.Single(n => n.IDSanPham == iIDSanPham);
            STenSanPham = sanPham.TenSanPham;
            SHinhAnh = sanPham.HinhAnh;
            dDonGia = double.Parse(sanPham.DonGia.ToString());
            iSoLuong = 1;
        }

    }
}