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
    public partial class frmDMHang : Form
    {
        int check = 0;//Kiem tra o che do them hay sua them:0 sua 1
        List<HangHoaDTO> hhs;
        List<ChatLieuDTO> cls;
        public frmDMHang()
        {
            InitializeComponent();
            hhs = new List<HangHoaDTO>();
            cls = new List<ChatLieuDTO>();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void loadDataGridViewHangHoa()
        {
            cls = DAOChatLieu.Instance.getAllChatLieu();
            cmbMaChatLieu.DataSource = cls;
            cmbMaChatLieu.DisplayMember ="TenChatLieu";
            hhs = DAOHangHoa.Instance.getAllHangHoa();
            dgvDMHang.DataSource = hhs;
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            dgvDMHang.Columns[0].HeaderText ="Ma hang";
            dgvDMHang.Columns[0].Width = 150;
            dgvDMHang.Columns[1].HeaderText ="Ten hang";
            dgvDMHang.Columns[1].Width = 150;
            dgvDMHang.Columns[2].HeaderText ="Ma chat lieu";
            dgvDMHang.Columns[2].Width = 150;
            dgvDMHang.Columns[3].HeaderText ="So luong";
            dgvDMHang.Columns[3].Width = 150;
            dgvDMHang.Columns[4].HeaderText ="Don gia nhap";
            dgvDMHang.Columns[4].Width = 150;
            dgvDMHang.Columns[5].HeaderText ="Don gia ban";
            dgvDMHang.Columns[5].Width = 150;
            dgvDMHang.Columns[6].HeaderText ="Anh";
            dgvDMHang.Columns[6].Width = 150;
            dgvDMHang.Columns[7].HeaderText ="Ghi chu";
            dgvDMHang.Columns[7].Width = 150;
        }
        void resetValue()//Clear cac txtBox
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtAnh.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtSoLuong.Text = "";
            cmbMaChatLieu.Text = "";
            txtGhiChu.Text = "";
        }
        void enabledText()
        {
            txtMaHang.Enabled = true ;
            txtTenHang.Enabled = true;
            txtAnh.Enabled = true;
            txtGiaBan.Enabled = true;
            txtGiaNhap.Enabled = true;
            txtSoLuong.Enabled = true;
            cmbMaChatLieu.Enabled = true;
            txtGhiChu.Enabled = true;
        }
        void unEnabledText()
        {
            txtMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            txtAnh.Enabled = false;
            txtGiaBan.Enabled = false;
            txtGiaNhap.Enabled = false;
            txtSoLuong.Enabled = false;
            cmbMaChatLieu.Enabled = false;
            txtGhiChu.Enabled = false;
        }

        private void dgvDMHang_Click(object sender, EventArgs e)
        {
            if (dgvDMHang.RowCount == 0)
                return;
            if (btnThem.Enabled == false  && check == 0)
            {
                MessageBox.Show("Dang o che do them moi!!!");
                txtMaHang.Focus();
                btnBoQua.Enabled = true;
                return;
            }
            unEnabledText();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnMo.Enabled = false;
            btnThem.Enabled = true;
            txtMaHang.Text = dgvDMHang.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dgvDMHang.CurrentRow.Cells[1].Value.ToString();
            ChatLieuDTO cl = getChatLieu(dgvDMHang.CurrentRow.Cells[2].Value.ToString());
            cmbMaChatLieu.SelectedIndex = cmbMaChatLieu.Items.IndexOf(cl);
            txtSoLuong.Text = dgvDMHang.CurrentRow.Cells[3].Value.ToString();
            txtGiaNhap.Text = dgvDMHang.CurrentRow.Cells[4].Value.ToString();
            txtGiaBan.Text = dgvDMHang.CurrentRow.Cells[5].Value.ToString();
            txtAnh.Text = dgvDMHang.CurrentRow.Cells[6].Value.ToString();
            txtGhiChu.Text = dgvDMHang.CurrentRow.Cells[7].Value.ToString();
            picAnh.Image = Image.FromFile(txtAnh.Text);
        }
        ChatLieuDTO getChatLieu(string ma)
        {
            ChatLieuDTO cl = new ChatLieuDTO();
            foreach (ChatLieuDTO item in cls)
            {
                if (item.MaChatLieu == ma)
                    cl =item;
            }
            return cl;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Ban co thuc su muon xoa khong", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                if(DAOCTHoaDon.Instance.checkDeleteHangHoa(txtMaHang.Text))
                {
                    MessageBox.Show("Khong the xoa ma hang nay!!!");
                    return;
                }
                if (DAOHangHoa.Instance.deleteDataSql(txtMaHang.Text))
                {
                    resetValue();
                    loadDataGridViewHangHoa();
                    MessageBox.Show("Xoa thanh cong");
                }
                else
                    MessageBox.Show("Xoa khong thanh cong");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnMo.Enabled = true;
            btnSua.Enabled  =false;
            check =1;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            enabledText();
            txtMaHang.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            enabledText();
            resetValue();
            btnThem.Enabled = false;
            btnMo.Enabled = true;
            check = 0;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetValue();
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool checkValueString()//Check xem co textBox nao empty hay khong?
        {
            if(String.IsNullOrEmpty(txtMaHang.Text))
            {
                MessageBox.Show("Khong co ma hang!!!");
                txtMaHang.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTenHang.Text))
            {
                MessageBox.Show("Khong co ten hang!!!");
                txtTenHang.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(cmbMaChatLieu.SelectedItem.ToString()))
            {
                MessageBox.Show("Khong co ma chat lieu!!!");
                cmbMaChatLieu.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtMaHang.Text))
            {
                MessageBox.Show("Khong co ma hang!!!");
                txtMaHang.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Thieu so luong!!!");
                txtSoLuong.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtGiaNhap.Text))
            {
                MessageBox.Show("Thieu gia nhap!!!");
                txtGiaNhap.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Thieu gia ban!!!");
                txtGiaBan.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtAnh.Text))
            {
                MessageBox.Show("Thieu anh!!!");
                txtAnh.Focus();
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkNumber(txtSoLuong.Text) == false|| checkNumber(txtGiaBan.Text) == false|| checkNumber(txtGiaNhap.Text) == false)
            {
                MessageBox.Show("So luong,gia ban , gia nhap phai la chu so!!!");
                return;
            }
            if (checkValueString() == false)
            {
                return;
            }
            if(check == 0)
            {
                if(DAOHangHoa.Instance.checkSameDataSql(txtMaHang.Text) == true)
                {
                    MessageBox.Show("Ma hang hoa bi trung!!!");
                    txtMaHang.Focus();
                    return;
                }
                ChatLieuDTO? temp = cmbMaChatLieu.SelectedItem as ChatLieuDTO;
                HangHoaDTO hh = new HangHoaDTO(txtMaHang.Text, txtTenHang.Text, temp.MaChatLieu, float.Parse(txtSoLuong.Text), float.Parse(txtGiaNhap.Text) , float.Parse(txtGiaBan.Text), txtAnh.Text, txtGhiChu.Text);
                if (DAOHangHoa.Instance.addDataSql(txtMaHang.Text, txtTenHang.Text, temp.MaChatLieu, float.Parse(txtSoLuong.Text), float.Parse(txtGiaNhap.Text), float.Parse(txtGiaBan.Text), txtAnh.Text, txtGhiChu.Text))
                    MessageBox.Show("Them thanh cong!!!");
                else
                    MessageBox.Show("Khong thanh cong!!!");
            }else
            {
                ChatLieuDTO? temp = cmbMaChatLieu.SelectedItem as ChatLieuDTO;
                if (DAOHangHoa.Instance.updateDataSql(txtMaHang.Text, txtTenHang.Text, temp.MaChatLieu, float.Parse(txtSoLuong.Text), float.Parse(txtGiaNhap.Text), float.Parse(txtGiaBan.Text), txtAnh.Text, txtGhiChu.Text)==true)
                    MessageBox.Show("Thanh cong");
                else
                    MessageBox.Show("Khong thanh cong");
            }
            loadDataGridViewHangHoa();
        }

        private void frmDMHang_Load(object sender, EventArgs e)
        {
            loadDataGridViewHangHoa();
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }
        /*Check input co phai la so hay khong
         * tham so : string so
         * return : true/false
         */
        bool checkNumber(string so)
        {
            try
            {
                float soTemp = float.Parse(so);
                return true;
            }
            catch (Exception)
            {
                return false;
            }   
        }
    }
}
