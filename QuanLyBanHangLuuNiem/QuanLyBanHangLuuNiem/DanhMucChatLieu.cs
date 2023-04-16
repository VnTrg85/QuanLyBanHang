using QuanLyBanHangLuuNiem.DAO;
using QuanLyBanHangLuuNiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangLuuNiem
{
    public partial class DanhMucChatLieu : Form
    {
        int check = 0;
        List<ChatLieuDTO> list;
        public DanhMucChatLieu()
        {
            InitializeComponent();
            list = new List<ChatLieuDTO>();
            loadDataGridView();
        }
        
        private void resetValue()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }
        void loadDataGridView()
        {
            list = DAOChatLieu.Instance.getAllChatLieu();
            dgvChatLieu.DataSource = list;
            dgvChatLieu.Columns[0].HeaderText = "Ma Chat Lieu";
            dgvChatLieu.Columns[1].HeaderText = "Ten Chat Lieu";
            dgvChatLieu.Columns[0].Width = 500;
            dgvChatLieu.Columns[1].Width = 1000;
            
            dgvChatLieu.AllowUserToAddRows= false;
            dgvChatLieu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DanhMucChatLieu_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            loadDataGridView();
        }

        private void dgvChatLieu_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled == false  && check == 0)
            {
                MessageBox.Show("Dang o che do them moi!!!");
                txtMaChatLieu.Focus();
                return;
            }
            if(list.Count == 0)
            {
                MessageBox.Show("Khong co du lieu!!!");
                return;
            }
            txtMaChatLieu.Enabled = false;
            txtMaChatLieu.Text = dgvChatLieu.CurrentRow.Cells[0].Value.ToString();
            txtTenChatLieu.Text = dgvChatLieu.CurrentRow.Cells[1].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            check = 0;
            resetValue();
            txtMaChatLieu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;           
        }
        bool checkValueString()
        {
            if (String.IsNullOrEmpty(txtMaChatLieu.Text))
            {
                MessageBox.Show("Thieu ma chat lieu", "Thong bao", MessageBoxButtons.OK);
                txtMaChatLieu.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(txtTenChatLieu.Text))
            {
                MessageBox.Show("Thieu ten chat lieu", "Thong bao", MessageBoxButtons.OK);
                txtTenChatLieu.Focus();
                return false;
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        { 
            if(check == 0)
            {
                    if(checkValueString()== false)
                    {
                        return;
                    }
                    else if ((int)DAOChatLieu.Instance.getNumberOfSameChatLieu(txtMaChatLieu.Text) > 0)
                    {
                        MessageBox.Show("Ma chat lieu bi trung. Doi ma khac", "Thong bao", MessageBoxButtons.OK);
                        txtMaChatLieu.Focus();
                    }
                    else
                    {
                        ChatLieuDTO cl = new ChatLieuDTO(txtMaChatLieu.Text, txtTenChatLieu.Text);
                        list.Add(cl);
                        if (DAOChatLieu.Instance.addDataIntoSql(txtMaChatLieu.Text, txtTenChatLieu.Text)==true)
                            MessageBox.Show("Thanh cong!!!");
                        else
                            MessageBox.Show("Khong thanh cong!!!");
                    }
                
            }else
            {
                if (checkValueString() == false)
                {
                    return;
                }
                else
                { 
                    if (DAOChatLieu.Instance.updateDataIntoSql(txtMaChatLieu.Text, txtTenChatLieu.Text)==true)
                        MessageBox.Show("Thanh cong!!!");
                    else
                        MessageBox.Show("Khong thanh cong!!!");
                }
            }
            loadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DAOHangHoa.Instance.checkDelete(txtMaChatLieu.Text))
            {
                MessageBox.Show("Khong the xoa chat lieu nay");
                return;
            }
            DialogResult mess = MessageBox.Show("Ban co thuc su muon xoa khong", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess == DialogResult.Yes)
            {
                
                foreach (ChatLieuDTO item in list)
                {
                    if (item.MaChatLieu == txtMaChatLieu.Text)
                    {
                        list.Remove(item);
                        if(DAOChatLieu.Instance.deleteDataSql(txtMaChatLieu.Text))
                            MessageBox.Show("Thanh cong!!!");
                        else
                            MessageBox.Show("Khong thanh cong!!!");
                        loadDataGridView();
                        resetValue();
                        return;
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
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
