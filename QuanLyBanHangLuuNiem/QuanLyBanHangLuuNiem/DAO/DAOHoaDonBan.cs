using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    internal class DAOHoaDonBan
    {
        private static DAOHoaDonBan instance;

        internal static DAOHoaDonBan Instance { get { if (instance  == null) instance = new DAOHoaDonBan();return instance; } set => instance=value; }
        /*
         * lay ta ca cac hoa don ban tu bang tblHDBan
         * return list<HoaDonBanDTO> 
         */
        public List<HoaDonBanDTO> getAllHDBan()
        {
            List<HoaDonBanDTO> hdbs = new List<HoaDonBanDTO>();
            string query = "select * from tblHDBan";
            DataTable data = DataProvider.Instance.executeQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoaDonBanDTO hdb = new HoaDonBanDTO(item);
                hdbs.Add(hdb);
            }
            return hdbs;
        }
        /*
         * Huy hoa don ban 
         * tham so : maHD
         * return true/false
         */
        public bool deleteHDBan(string maHD)
        {
            string query = "delete from tblHDBan where maHDBan = @maHoaDon ";
            int results = DataProvider.Instance.execueNonquery(query, new object[] { maHD });
            if (results > 0)
                return true;
            return false;
        }
        /*
         * Luu hoa don ban 
         * tham so : maHD
         * return true/false
         */
        public bool SaveHDBan(HoaDonBanDTO hd)
        {
            string query = "insert  tblHDBan values( @maHoaDon , @maNhanVien , @ngayBan , @maKhach , @thanhTien )";
            int results = DataProvider.Instance.execueNonquery(query, new object[] { hd.MaHD, hd.MaNhanVien,hd.NgayBan,hd.MaKhachHang,hd.TongTien });
            if (results > 0)
                return true;
            return false;
        }
        /*
         * Check xem co HdBan nao thuoc nhan vien theo maNhanVien khong?
         * tham so : maNhanVien
         * return true/false
         */

        public bool checkDeleteNhanVien(string maNhanVien)
        {
            string query = "select count(*) from tblHDBan where MaNhanVien = @maNhanVien ";
            int rowaff = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maNhanVien });
            if (rowaff> 0)
                return true;
            return false;

        }
        /*
         * Check xem co HdBan nao thuoc khach hang co MaKhach = maKhach khong?
         * tham so : maKhach
         * return true/false
         */

        public bool checkDeleteKhach(string maKhach)
        {
            string query = "select count(*) from tblHDBan where MaKhach = @maKhach ";
            int rowaff = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maKhach });
            if (rowaff> 0)
                return true;
            return false;

        }
    }
}
