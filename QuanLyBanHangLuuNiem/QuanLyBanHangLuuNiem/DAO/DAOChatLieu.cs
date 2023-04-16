using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DAO
{
    internal class DAOChatLieu
    {
        private static DAOChatLieu instance;

        public static DAOChatLieu Instance { get { if (instance == null) instance = new DAOChatLieu(); return instance; } set => instance=value; }
        
        public List<ChatLieuDTO> getAllChatLieu()
        {
            List<ChatLieuDTO> list = new List<ChatLieuDTO>();
            string query = "select * from tblChatLieu";
            DataTable data = DataProvider.Instance.executeQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ChatLieuDTO cl = new ChatLieuDTO(item);
                list.Add(cl);
            }
            return list;
        }
        public int getNumberOfSameChatLieu(string maChatLieu)
        {
            string query = "select count(*) from tblChatLieu where MaChatLieu = @maChatLieu";
            int results = (int)DataProvider.Instance.excecuteScalar(query, new object[] { maChatLieu });
            return results;
        }
        public bool updateDataIntoSql(string maChatLieu, string tenChatLieu)
        {
            string query = "Update tblChatLieu set TenChatLieu = @TenChatLieu where MaChatLieu = @MaChatLieu ";
            int results = DataProvider.Instance.execueNonquery(query, new object[] { tenChatLieu, maChatLieu, });
            if (results > 0)
                return true;
            return false;
        }
        public bool addDataIntoSql(string maChatLieu, string tenChatLieu)
        {
            string query = "Insert tblChatLieu values( @TenChatLieu , @MaChatLieu )";
            int results = DataProvider.Instance.execueNonquery(query, new object[] { maChatLieu, tenChatLieu });
            if (results > 0)
                return true;
            return false;
        }
        public bool deleteDataSql(string maChatLieu)
        {
            string query = "Delete tblChatLieu  where MaChatLieu = @maChatLieu ";
            int results = DataProvider.Instance.execueNonquery(query, new object[] { maChatLieu });
            if (results > 0)
                return true;
            return false;
        }
        /*
         Lay ten chat lieu dua vao ma chat lieu
         tham so :maChatLieu
         return : tenChatLieu
         */
        public string getNameChatLieu(string maChatLieu)
        {
            string query = "select TenChatLieu from tblChatLieu  where MaChatLieu = @maChatLieu ";
            string results =(string) DataProvider.Instance.excecuteScalar(query, new object[] { maChatLieu });
            return results;
        }
        
    }
}
