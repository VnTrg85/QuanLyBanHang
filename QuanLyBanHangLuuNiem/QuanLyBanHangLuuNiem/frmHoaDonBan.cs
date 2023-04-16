using QuanLyBanHangLuuNiem.DAO;
using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangLuuNiem
{
    public partial class frmHoaDonBan : Form
    {
        List<HoaDonBanDTO> hdbs;
        public frmHoaDonBan()
        {
            InitializeComponent();
            hdbs = new List<HoaDonBanDTO>();
            
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            loadHDBan();
        }
        void loadHDBan()
        {
            hdbs = DAOHoaDonBan.Instance.getAllHDBan();
            dgvHDBanHang.DataSource= hdbs;
            FillTxtTongTien();
            dgvHDBanHang.Columns[0].HeaderText ="Ma Hoa Don";
            dgvHDBanHang.Columns[0].Width = 200;
            dgvHDBanHang.Columns[1].HeaderText ="Ngay Ban";
            dgvHDBanHang.Columns[1].Width = 200;
            dgvHDBanHang.Columns[2].HeaderText ="Ma Nhan Vien";
            dgvHDBanHang.Columns[2].Width = 200;
            dgvHDBanHang.Columns[3].HeaderText ="Ma Khach";
            dgvHDBanHang.Columns[3].Width = 200;
            dgvHDBanHang.Columns[4].HeaderText ="Tong Tien";
            dgvHDBanHang.Columns[4].Width = 300;
        }
        void resetValue()
        {
            txtMaHD.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            txtMaKhach.Text = "";
            txtMaNhanVien.Text = "";
            txtTongT.Text = "";
        }

        private void dgvHDBanHang_Click(object sender, EventArgs e)
        {
            unEnableTxt();
            txtMaHD.Text = dgvHDBanHang.CurrentRow.Cells[0].Value.ToString();
            txtMaNhanVien.Text = dgvHDBanHang.CurrentRow.Cells[2].Value.ToString();
            dtpNgayBan.Value = DateTime.Parse(dgvHDBanHang.CurrentRow.Cells[1].Value.ToString());
            txtMaKhach.Text = dgvHDBanHang.CurrentRow.Cells[3].Value.ToString();
            txtTongT.Text =  dgvHDBanHang.CurrentRow.Cells[4].Value.ToString();
        }
        public void unEnableTxt()
        {
            txtMaHD.Enabled = false;
            txtMaKhach.Enabled = false;
            txtMaNhanVien.Enabled = false;
            txtTongT.Enabled = false;
            dtpNgayBan.Enabled = false;
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Ban co thuc su muon xoa khong", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                if(DAOCTHoaDon.Instance.checkDeleteHangHoaTheoMaHD(txtMaHD.Text))
                {
                    MessageBox.Show("Khong the huy hoa don nay");
                    return;
                }
                if(DAOHoaDonBan.Instance.deleteHDBan(txtMaHD.Text))
                {
                    resetValue();
                    MessageBox.Show("Huy thanh cong");
                }
                else
                    MessageBox.Show("Huy khong thanh cong");
            }
            loadHDBan();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void FillTxtTongTien()
        {
            float tong = 0;
            foreach (HoaDonBanDTO item in hdbs)
            {
                tong+=item.TongTien;
            }
            txtTongTien.Text = tong.ToString();            
            txtThanhChu.Text = ChuyenSoSangChu(tong.ToString());
        }
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp break; 
                    break;
                    switch ((mLen - i) % 9)
                    {
                        case 0:
                            mTemp = mTemp + " tỷ";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 6:
                            mTemp = mTemp + " triệu";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        case 3:
                            mTemp = mTemp + " nghìn";
                            if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
                            break;
                        default:
                            switch ((mLen - i) % 3)
                            {
                                case 2:
                                    mTemp = mTemp + " trăm";
                                    break;
                                case 1:
                                    mTemp = mTemp + " mươi";
                                    break;
                            }
                            break;
                    }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", ""); //Loại bỏ trường hợp 00x 
            mTemp = mTemp.Replace("không mươi ", "linh "); //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            List<HoaDonBanDTO> listTemp = new List<HoaDonBanDTO>();
            foreach (HoaDonBanDTO item in hdbs)
            {
                if(item.MaHD == txtTim.Text)
                {
                    listTemp.Add(item);
                    dgvHDBanHang.DataSource = listTemp;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadHDBan();
        }
    }
}
