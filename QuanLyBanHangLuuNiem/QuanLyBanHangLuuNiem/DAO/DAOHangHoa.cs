using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    internal class DAOHangHoa
    {
        private static DAOHangHoa instance;

        internal static DAOHangHoa Instance { get { if (instance == null) instance = new DAOHangHoa(); return instance; } set => instance=value; }
        /*
         * Lay tat ca cac hang hoa trong tblHang
         * return List<HangHoaDTO>
         */
        public List<HangHoaDTO> getAllHangHoa()
        {
            List<HangHoaDTO> hhs = new List<HangHoaDTO>();
            string query = "select * from tblHang";
            DataTable data = DataProvider.Instance.executeQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HangHoaDTO hh = new HangHoaDTO(item);
                hhs.Add(hh);
            }
            return hhs;
        }
        /*
         * Xoa mot hang hoa khoi tblHang
         * tham so:maHang
         * return true/false
         */
        public bool deleteDataSql(string maHang)
        {
            string query = "Delete tblHang where MaHang = @maHang ";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { maHang });
            if (rowaff >0)
                return true;
            return false;
        }
        /*
         * Them mot hang hoa khoi tblHang
         * tham so:maHang,tenHang,maChatLieu,soLuong,donGiaNhap,donGiaBan,anh,ghiChu
         * return true/false
         */
        public bool addDataSql(string maHang, string tenHang,string  maChatLieu, float soLuong, float donGiaNhap, float donGiaBan, string anh, string ghiChu)
        {
            string query = "Insert tblHang values( @maHang , @tenHang , @maChatLieu , @soLuong , @donGiaNhap , @donGiaBan , @anh , @ghiChu )";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { maHang, tenHang, maChatLieu, soLuong, donGiaNhap, donGiaBan, anh, ghiChu });
            if (rowaff > 0)
                return true;
            return false;
        }
        /*
         * Check xem co ma hang hoa nao bi trung khong?
         * tham so:maHang
         * return true/false
         */
        public bool checkSameDataSql(string maHang)
        {
            string query = "select count(*) from tblHang where MaHang  = @maHang";
            int rowaff = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maHang });
            if (rowaff > 0)
                return true;
            return false;
        }
        /*
         * Sua mot hang hoa
         * tham so:maHang,tenHang,maChatLieu,soLuong,donGiaNhap,donGiaBan,anh,ghiChu
         * return true/false
         */
        public bool updateDataSql(string maHang, string tenHang, string maChatLieu, float soLuong, float donGiaNhap, float donGiaBan, string anh, string ghiChu)
        {
            string query = "Update tblHang set TenHang = @tenHang , MaChatLieu = @maChatLieu ,SoLuong = @soLuong , DonGiaNhap = @donGiaNhap , DonGiaBan = @donGiaBan , Anh = @anh , GhiChu = @ghiChu where MaHang = @maHang ";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { tenHang, maChatLieu, soLuong, donGiaNhap, donGiaBan, anh, ghiChu , maHang });
            if (rowaff > 0)
                return true;
            return false;
        }
        /*
         * Check dieu kien de xoa chat lieu nao do
         * 
         */
        public bool checkDelete(string maChatLieu)
        {
            string query = "select count(*) from tblHang where MaChatLieu = @maChatLieu ";
            int data = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maChatLieu });
            if(data!=0)
            {
                return true;
            }
            return false;
        }
    }
}
