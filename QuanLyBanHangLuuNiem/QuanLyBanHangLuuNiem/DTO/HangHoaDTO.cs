using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DTO
{
    internal class HangHoaDTO
    {
        private string maHang,tenHang,maChatLieu,anh,ghiChu;
        float donGiaNhap,donGiaBan, soLuong;

        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public string MaChatLieu { get => maChatLieu; set => maChatLieu = value; }
        public float SoLuong { get => soLuong; set => soLuong=value; }
        public float DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        public float DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
        
        public string Anh { get => anh; set => anh = value; }
        public string GhiChu { get => ghiChu; set => ghiChu=value; }
        public HangHoaDTO() { }
        public HangHoaDTO(string maHang, string tenHang, string maChatLieu, float soLuong, float donGiaNhap, float donGiaBan,  string anh, string ghiChu)
        {
            MaHang=maHang;
            TenHang=tenHang;
            MaChatLieu=maChatLieu;
            SoLuong=soLuong;
            DonGiaNhap=donGiaNhap;
            DonGiaBan=donGiaBan;
            Anh=anh;
            GhiChu=ghiChu;
        }
        public HangHoaDTO(DataRow data)
        {
            MaHang=(string)data["MaHang"];
            TenHang=(string)data["TenHang"];
            MaChatLieu=(string)data["MaChatLieu"];
            SoLuong=float.Parse((data["SoLuong"]).ToString());
            DonGiaNhap= float.Parse((data["DonGiaNhap"]).ToString());
            DonGiaBan=float.Parse((data["DonGiaBan"]).ToString());
            Anh=(string)data["Anh"];
            GhiChu=(string)data["GhiChu"];
        }
    }
}
