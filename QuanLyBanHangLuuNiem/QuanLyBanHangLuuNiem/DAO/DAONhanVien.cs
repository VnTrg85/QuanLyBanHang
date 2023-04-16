using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    internal class DAONhanVien
    {
        private static DAONhanVien instance;

        internal static DAONhanVien Instance { get { if (instance == null) instance = new DAONhanVien(); return instance; } set => instance=value; }
        private DAONhanVien() { }
        public List<NhanVienDTO> getAllNhanVien()
        {
            List<NhanVienDTO> nvs = new List<NhanVienDTO>();
            string query = "select * from tblNhanVien";
            DataTable data = DataProvider.Instance.executeQuery(query);
            foreach (DataRow row in data.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO(row);
                nvs.Add(nv);
            }
            return nvs;
        }
        public bool deleteDataSql(string maNhanVien)
        {
            string query = "delete tblNhanVien where MaNhanVien = @maNhanVien ";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { maNhanVien });
            if (rowaff> 0)
            {
                return true;
            }
            return false;
        }
        public int getSameNhanVien(string maNhanVien)
        {
            string query = "select count(*) from tblNhanVien where MaNhanVien = @maNhanVien ";
            int data = (int)DataProvider.Instance.excecuteScalar(query,new object[] { maNhanVien });
            return data;
        }
        public bool addDataSql(NhanVienDTO nv)
        {
            string query = "Insert tblNhanVien values( @maNhanVien , @tenNhanVien , @gioiTinh , @diaChi , @dienThoai , @ngaySinh )";
            int data = DataProvider.Instance.execueNonquery(query, new object[] { nv.MaNhanVien, nv.TenNhanVien, nv.GioiTinh,  nv.DiaChi, nv.DienThoai, nv.NgaySinh});
            if (data>0)
                return true;
            return false;
        }
        public bool updateDataSql(NhanVienDTO nv)
        {
            string query = "Update tblNhanVien set TenNhanVien = @tenNhanVien , GioiTinh = @gioiTinh , DienThoai = @dienThoai , DiaChi = @diaChi , NgaySinh = @ngaySinh where MaNhanVien = @maNhanVien";
            int rowaff = DataProvider.Instance.execueNonquery(query, new object[] { nv.TenNhanVien, nv.GioiTinh, nv.DiaChi, nv.DienThoai , nv.NgaySinh , nv.MaNhanVien });
            if (rowaff>0) return true;
            return false;
        }
        
    }
}