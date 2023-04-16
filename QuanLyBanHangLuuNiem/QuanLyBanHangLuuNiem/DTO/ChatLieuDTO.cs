using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangLuuNiem.DTO
{
    internal class ChatLieuDTO
    {
        //Properties
        private string maChatLieu;
        private string tenChatLieu;
       
        public string MaChatLieu { get => maChatLieu; set => maChatLieu=value; }
        public string TenChatLieu { get => tenChatLieu; set => tenChatLieu=value; }
        public ChatLieuDTO() { }
        public ChatLieuDTO(string maChatLieu, string tenChatLieu)
        {
            MaChatLieu=maChatLieu;
            TenChatLieu=tenChatLieu;           
        }
        public ChatLieuDTO(DataRow data)
        {
            MaChatLieu=(string)data["MaChatLieu"];
            TenChatLieu=(string)data["TenChatLieu"];
        }
    }
}
