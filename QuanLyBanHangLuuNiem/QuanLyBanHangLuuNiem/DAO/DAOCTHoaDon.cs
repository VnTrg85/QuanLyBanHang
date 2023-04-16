using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    internal class DAOCTHoaDon
    {
        private static DAOCTHoaDon instance;

        internal static DAOCTHoaDon Instance { get { if (instance == null) instance = new DAOCTHoaDon() { }; return instance; } set => instance=value; }
        private DAOCTHoaDon() { }
        /*
         * Them CTHD vao tblChiTietHDBan
         * Tham so: CTHoaDonCTO
         * return true/false;
         * */
        public bool saveDatatoSql(CTHoaDonDTO hd)
        {
            string query = "insert tblChiTietHDBan values( @maHoaDon , @maHang , @soLuong , @donBan , @giamGia , @thanhTien )";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { hd.MaHD, hd.MaHang, hd.SoLuong, hd.DonGia, hd.GiamGia, hd.ThanhTien });
            if (rowaff > 0)
                return true;
            return false;
        }
        /*
         * Kiem tra xe co ton tai CTHoaDonBan nao co ma hang  = maHang k?
         * Tham so = maHang
         * return true/false
         */
        public bool checkDeleteHangHoa(string maHang)
        {
            string query = "select count(*) from tblChiTietHDBan where MaHang = @maHang ";
            int rowaff = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maHang });
            if (rowaff > 0)
                return true;
            return false;
        }

        /*
         * Kiem tra xe co ton tai CTHoaDonBan nao co ma hoa don  = maHD k?
         * Tham so = maHD
         * return true/false
         */
        public bool checkDeleteHangHoaTheoMaHD(string maHD)
        {
            string query = "select count(*) from tblChiTietHDBan where MaHDBan = @maHD ";
            int rowaff = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maHD });
            if (rowaff > 0)
                return true;
            return false;
        }
    }
}
