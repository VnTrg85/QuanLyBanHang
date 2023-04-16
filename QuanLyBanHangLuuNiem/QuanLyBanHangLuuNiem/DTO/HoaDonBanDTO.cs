using QuanLyBanHangLuuNiem.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DTO
{
    internal class HoaDonBanDTO
    {
        string maHD;
        DateTime ngayBan;
        string maNhanVien, maKhachHang;
        float tongTien;
        public string MaHD { get => maHD; set => maHD=value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan=value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public float TongTien { get => tongTien; set => tongTien=value; }

        public HoaDonBanDTO() { }
        public HoaDonBanDTO(string maHD, DateTime ngayBan, string maNhanVien,  string maKhachHang,float tongTien)
        {
            this.maHD = maHD;
            this.ngayBan = ngayBan;
            this.maNhanVien  = maNhanVien;
            this.maKhachHang = maKhachHang;
            this.tongTien = tongTien;
        }
        public HoaDonBanDTO(DataRow data)
        {
            this.maHD = (string)data["MaHDBan"];
            this.ngayBan = (DateTime)data["NgayBan"];
            this.MaNhanVien = (string)data["MaNhanVien"];
            this.MaKhachHang = (string)data["MaKhach"];
            this.tongTien = float.Parse((data["TongTien"]).ToString());
        }
    }
}
