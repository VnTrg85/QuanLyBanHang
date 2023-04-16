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
    public partial class frmDMKhachHang : Form
    {
        List<KhachHangDTO> khs;
        int check = 0;//Kiem tra xem che do la them hay sua 0:Them 1:Sua
        public frmDMKhachHang()
        {
            InitializeComponent();
            khs = new List<KhachHangDTO>();
        }

        void loadDataIntoDgvKhach() //Load du lieu vao dataGridView
        {
            khs = DAOKhachHang.Instance.getAllKhachHang();
            dgvKhachHang.DataSource = khs;
            dgvKhachHang.Columns[0].HeaderText = "Ma khach hang";
            dgvKhachHang.Columns[0].Width = 200;
            dgvKhachHang.Columns[1].HeaderText = "Ten khach hang";
            dgvKhachHang.Columns[1].Width = 200;
            dgvKhachHang.Columns[2].HeaderText = "Dia chi";
            dgvKhachHang.Columns[2].Width = 200;
            dgvKhachHang.Columns[3].HeaderText = "Dien thoai";
            dgvKhachHang.Columns[3].Width = 200;
            btnLuu.Enabled = false;
            btnBoQua.Enabled= false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {
            loadDataIntoDgvKhach();
        }
        void enableTxt()//enable cac text 
        {
            txtMaKhach.Enabled = true;
            txtDienThoai.Enabled = true;
            txtDiaChi.Enabled = true;
            txtTenKhach.Enabled = true;
        }
        void unEnableTxt()//unenable cac text 
        {
            txtMaKhach.Enabled = false;
            txtDienThoai.Enabled = false;
            txtDiaChi.Enabled = false;
            txtTenKhach.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            check = 0 ;
            resetValue();
            btnThem.Enabled = false;
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            enableTxt();
        }
        void resetValue()//clear cac txt
        {
            txtMaKhach.Text = "";
            txtTenKhach.Text ="";
            txtDiaChi.Text ="";
            txtDienThoai.Text="";
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Ban co thuc su muon xoa khong", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {
                if(DAOHoaDonBan.Instance.checkDeleteKhach(txtMaKhach.Text))
                {
                    MessageBox.Show("Khong the xoa khach hang nay!!!");
                    return;
                }
                foreach (KhachHangDTO item in khs)
                {
                    if (item.MaKhach == txtMaKhach.Text)
                    {
                        khs.Remove(item);
                        DAOKhachHang.Instance.deleteDataSql(txtMaKhach.Text);
                        resetValue();
                        loadDataIntoDgvKhach();
                        break;
                    }
                }
            }
                      
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            check = 1;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            enableTxt();
            txtMaKhach.Enabled = false;
        }
        /*
         * Check xem co text nao empty hay khong? 
         * return true/false
         */
        bool checkValueString()
        {
            if (String.IsNullOrEmpty(txtMaKhach.Text))
            {
                MessageBox.Show("Thieu ma khach hang", "Thong bao", MessageBoxButtons.OK);
                txtMaKhach.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTenKhach.Text))
            {
                MessageBox.Show("Thieu ten khach hang", "Thong bao", MessageBoxButtons.OK);
                txtTenKhach.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Thieu dia chi", "Thong bao", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Thieu so dien thoai", "Thong bao", MessageBoxButtons.OK);
                txtDienThoai.Focus();
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkValueString() == false)
            {
                return;
            }
            if (check == 0)
            {
                if (DAOKhachHang.Instance.checkSameKhachHang(txtMaKhach.Text))
                {
                    MessageBox.Show("Ma khach hang bi trung!!!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                KhachHangDTO kh = new KhachHangDTO(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, txtDienThoai.Text);
                khs.Add(kh);
                if (DAOKhachHang.Instance.addDataSql(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, txtDienThoai.Text))
                {
                    MessageBox.Show("Thanh cong");
                }
                else
                    MessageBox.Show("Khong thanh cong");
            }else
            {
                if(DAOKhachHang.Instance.updateDataSql(txtMaKhach.Text, txtTenKhach.Text, txtDiaChi.Text, txtDienThoai.Text))
                {
                    MessageBox.Show("Thanh cong");
                }
                else
                    MessageBox.Show("Khong thanh cong");
            }
            btnThem.Enabled = true;
            loadDataIntoDgvKhach();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled = false && check == 0)
            {
                MessageBox.Show("Dang o che do them moi");
                txtMaKhach.Focus();
                return;
            }
            if(khs.Count == 0)
            {
                MessageBox.Show("Khong co du lieu");
                return;
            }
            unEnableTxt();
            btnXoa.Enabled =true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
