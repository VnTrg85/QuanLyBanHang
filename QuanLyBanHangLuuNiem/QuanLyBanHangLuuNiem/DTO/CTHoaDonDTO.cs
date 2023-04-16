using QuanLyBanHangLuuNiem.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DTO
{
    internal class CTHoaDonDTO
    {
        
        string maHD, maHang;
        float soLuong, donGia, giamGia, thanhTien;
        public string MaHang { get => maHang; set => maHang=value; }
        public float SoLuong { get => soLuong; set => soLuong = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public float GiamGia { get => giamGia; set => giamGia = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien=value; }
        public string MaHD { get => maHD; set => maHD=value; }
    }
}
