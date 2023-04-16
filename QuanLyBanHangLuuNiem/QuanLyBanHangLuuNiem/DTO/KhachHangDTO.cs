using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DTO
{
    internal class KhachHangDTO
    {
        private string maKhach, tenKhach, diaChi, dienThoai;

        public string MaKhach { get => maKhach; set => maKhach = value; }
        public string TenKhach { get => tenKhach; set => tenKhach = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai=value; }
        public KhachHangDTO() { }
        public KhachHangDTO(string maKhach, string tenKhach, string diaChi, string dienThoai)
        {
            MaKhach=maKhach;
            TenKhach=tenKhach;
            DiaChi=diaChi;
            DienThoai=dienThoai;
        }
        public KhachHangDTO(DataRow data)
        {
            MaKhach=(string)data["MaKhach"];
            TenKhach=(string)data["TenKhach"];
            DiaChi=(string)data["DiaChi"];
            DienThoai=(string)data["DienThoai"];
        }
    }
}
