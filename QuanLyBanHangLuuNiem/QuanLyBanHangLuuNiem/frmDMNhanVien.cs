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
    public partial class frmDMNhanVien : Form
    {
        private List<NhanVienDTO> nvs;
        int check = 0;
        public frmDMNhanVien()
        {
            InitializeComponent();
            nvs = new List<NhanVienDTO>();
        }

        



        private void label5_Click(object sender, EventArgs e)
        {

        }
        void loadNhanVien()
        {
            nvs = DAONhanVien.Instance.getAllNhanVien();
            dgvNhanVien.DataSource = nvs;
            dgvNhanVien.Columns[0].HeaderText = "Ma nhan vien";
            dgvNhanVien.Columns[0].Width = 200;
            dgvNhanVien.Columns[1].HeaderText = "Ten nhan vien";
            dgvNhanVien.Columns[1].Width = 200;
            dgvNhanVien.Columns[2].HeaderText = "Gioi tinh";
            dgvNhanVien.Columns[2].Width = 200;
            dgvNhanVien.Columns[3].HeaderText = "Dia chi";
            dgvNhanVien.Columns[3].Width = 200;
            dgvNhanVien.Columns[4].HeaderText = "Dien thoai";
            dgvNhanVien.Columns[4].Width = 200;
            dgvNhanVien.Columns[5].HeaderText = "Ngay sinh";
            dgvNhanVien.Columns[5].Width = 200;
            
            txtMaNhanVien.Enabled = false;

            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
        }
        private void frmDMNhanVien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
        }
        void resetValue()
        {
            txtNgaySinh.Text = "";
            txtTenNhanVien.Text = "";
            txtMaNhanVien.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            ckbNam.Checked = false;
            ckbNu.Checked = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            check = 0;
            resetValue();
            txtMaNhanVien.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            ckbNam.Enabled = true;
            ckbNu.Enabled = true;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        bool checkValueString()
        {
            if (String.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Thieu ma nhan vien", "Thong bao", MessageBoxButtons.OK);
                txtMaNhanVien.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTenNhanVien.Text))
            {
                MessageBox.Show("Thieu ten nhan vien ", "Thong bao", MessageBoxButtons.OK);
                txtTenNhanVien.Focus();
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
            else if (String.IsNullOrEmpty(txtNgaySinh.Text))
            {
                MessageBox.Show("Thieu ngay sinh", "Thong bao", MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                return false;
            }
            else if (ckbNam.Checked == false && ckbNu.Checked == false)
            {
                MessageBox.Show("Thieu gioi tinh", "Thong bao", MessageBoxButtons.OK);
                ckbNam.Focus();
                return false;
            }else if(IsDate(txtNgaySinh.Text) == false)
            {
                MessageBox.Show("Moi nhap lai ngay sinh!!!", "Thong bao", MessageBoxButtons.OK);
                txtNgaySinh.Focus();
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult mess = MessageBox.Show("Ban co thuc su muon xoa khong", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {
                    if(DAOHoaDonBan.Instance.checkDeleteNhanVien(txtMaNhanVien.Text))
                        {
                            MessageBox.Show("Khong the xoa nhan vien nay!!!");
                            return;
                        }
                    foreach (NhanVienDTO item in nvs)
                    {
                        if (item.MaNhanVien == txtMaNhanVien.Text)
                        {
                            nvs.Remove(item);
                            DAONhanVien.Instance.deleteDataSql(txtMaNhanVien.Text);
                            loadNhanVien();
                            resetValue();
                            return;
                        }
                    }
            }

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            check = 1;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDienThoai.Enabled = true;
            ckbNam.Enabled = true;
            ckbNu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                if (checkValueString()== false )
                {
                    return;
                }
                else if ((int)DAONhanVien.Instance.getSameNhanVien(txtMaNhanVien.Text) > 0)
                {
                    MessageBox.Show("Ma nhan vien bi trung. Doi ma khac", "Thong bao", MessageBoxButtons.OK);
                    txtMaNhanVien.Focus();
                }
                else
                {
                    DateTime ns = DateTime.Parse(txtNgaySinh.Text);
                    NhanVienDTO nv = new NhanVienDTO(txtMaNhanVien.Text,txtTenNhanVien.Text,ckbNam.Checked == true?"NAM":"NU",txtDiaChi.Text, txtDienThoai.Text, ns);
                    nvs.Add(nv);
                    if (DAONhanVien.Instance.addDataSql(nv))
                        MessageBox.Show("Thanh cong!!!");
                    else
                        MessageBox.Show("Khong thanh cong!!!");
                }

            }
            else
            {
                if (checkValueString() == false)
                {
                    return;
                }
                else
                {
                    DateTime ns = DateTime.Parse(txtNgaySinh.Text);
                    NhanVienDTO nv = new NhanVienDTO(txtMaNhanVien.Text, txtTenNhanVien.Text, ckbNam.Checked == true ? "NAM" : "NU",  txtDiaChi.Text, txtDienThoai.Text,ns);
                    if (DAONhanVien.Instance.updateDataSql(nv))
                        MessageBox.Show("Thanh cong!!!");
                    else
                        MessageBox.Show("Khong thanh cong!!!");
                }
            }
            loadNhanVien();
            txtMaNhanVien.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false  && check == 0)
            {
                MessageBox.Show("Dang o che do them moi!!!");
                txtMaNhanVien.Focus();
                return;
            }
            if (nvs.Count == 0)
            {
                MessageBox.Show("Khong co du lieu!!!");
                return;
            }
            txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            if (dgvNhanVien.CurrentRow.Cells[2].Value.ToString().Equals("NAM"))
            {
                ckbNam.Checked = true;
            }
            else
                ckbNu.Checked = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtTenNhanVien.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDienThoai.Enabled = false;
            ckbNam.Enabled = false;
            ckbNu.Enabled = false;
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtDienThoai.Text  = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
        }

        private void ckbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNam.Checked == true)
                ckbNu.Checked = false;
        }

        private void ckbNu_Click(object sender, EventArgs e)
        {
            if (ckbNu.Checked == true)
                ckbNam.Checked = false;
        }
        private bool IsDate(string date)
        {
            string[] elements = date.Split('/');
            if ((Convert.ToInt32(elements[0]) >= 1) && (Convert.ToInt32(elements[0]) <= 31) && (Convert.ToInt32(elements[1]) >= 1) && (Convert.ToInt32(elements[1]) <= 12) && (Convert.ToInt32(elements[2]) >= 1900))
                return true;
            else return false;
        }
    }
}
