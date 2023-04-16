using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    internal class DAOKhachHang
    {
        private static DAOKhachHang instance;//Taoo mot doi tuong static DAOKHACHANG

        internal static DAOKhachHang Instance { get { if (instance == null) instance = new DAOKhachHang();return instance; } set => instance=value; }
        /*
        Lay tat ca cac KhachHang trong tblKhachHang
        return list<KhachHangDTO> 
        */
        
        public List<KhachHangDTO> getAllKhachHang()
        {
            List<KhachHangDTO> khs = new List<KhachHangDTO>();
            string query = "select * from tblKhach";
            DataTable data = DataProvider.Instance.executeQuery(query); 
            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO kh = new KhachHangDTO(item);
                khs.Add(kh);
            }
            return khs;
        }
        /*
         *Delete khach hang torng tblKhach
         *Tham so : maKhach
         *return true/false
         */
        public bool deleteDataSql(string maKhach)
        {
            string query = "delete tblKhach where MaKhach = @maKhach ";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { maKhach });
            if(rowaff > 0)
            {
                return true;
            }
            return false;
        }
        /*
         * Them mot khach hang vao tblKhach
         * Tham so :maKhach,tenKhach,diaChi,dienThoai
         * return true/false
         */
        public bool addDataSql(string maKhach,string tenKhach,string diaChi,string dienThoai)//Them mot khach hang vao tblKhach
        {
            string query = "Insert tblKhach values( @maKhach , @tenKhach , @diaChi , @dienThoai )";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { maKhach,tenKhach,diaChi,dienThoai });
            if (rowaff > 0)
            {
                return true;
            }
            return false;
        }
        /*
         * update Khach hang trong tblKhach
         * tham so : maKhach,tenKhach,diaChi,dienThoai
         * reutrn false/true
         */
        public bool updateDataSql(string maKhach , string tenKhach, string diaChi, string dienThoai)//Update du lieu trong tblKhach dua vao maKhach
        {
            string query = "Update tblKhach set TenKhach = @tenKhach , DiaChi = @diaChi , DienThoai = @dienThoai where maKhach = @maKhach ";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] {  tenKhach, diaChi, dienThoai,maKhach });
            if (rowaff > 0)
            {
                return true;
            }
            return false;
        }
        /*
         * Check xem co khach hang nao bi trung ma hay khong?
         * tham so :maKhach
         * return : true/false
         */
        public bool checkSameKhachHang(string maKhach)
        {
            string query = "select count(*) from tblKhach where MaKhach = @maKhach ";
            int number = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maKhach });
            if (number>0)
                return true;
            return false;
        }
    }
}
