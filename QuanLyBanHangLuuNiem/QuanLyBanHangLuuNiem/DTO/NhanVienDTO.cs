using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DTO
{
    internal class NhanVienDTO
    {
        private string maNhanVien, tenNhanVien, gioiTinh, diaChi, dienThoai;
        private DateTime ngaySinh;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai=value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh=value; }

        public NhanVienDTO() { }
        public NhanVienDTO(string maNhanVien, string tenNhanVien, string gioiTinh, string diaChi, string dienThoai, DateTime ngaySinh)
        {
            MaNhanVien=maNhanVien;
            TenNhanVien=tenNhanVien;
            GioiTinh=gioiTinh;
            DiaChi=diaChi;
            DienThoai=dienThoai;
            NgaySinh=ngaySinh;
        }
        public NhanVienDTO(DataRow data)
        {
            MaNhanVien=(string)data["MaNhanVien"];
            TenNhanVien=(string)data["TenNhanVien"];
            GioiTinh=(string)data["GioiTinh"];
            DiaChi=(string)data["DiaChi"]; ;
            DienThoai=(string)data["DienThoai"]; ;
            NgaySinh=(DateTime)data["NgaySinh"]; ;
        }
    }
}
