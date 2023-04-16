using QuanLyBanHangLuuNiem.DAO;
using QuanLyBanHangLuuNiem.DTO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyBanHangLuuNiem
{
    public partial class frmMain : Form
    {
        List<HangHoaDTO> listHh;
        List<CTHoaDonDTO> listHd;
        List<NhanVienDTO> listNv;
        List<KhachHangDTO> listKh;
        float thanhTien = 0 ;
        string maHd;
        public frmMain()
        {
            InitializeComponent();
            listHh = new List<HangHoaDTO>();
            listHd = new List<CTHoaDonDTO>();
            listNv = new List<NhanVienDTO>();
            listKh = new List<KhachHangDTO>();
            loadCmbTenHang();
            loadCmbNhanVien();
            loadCmbKhachHang();
            txtTongTien.Enabled = false;
            addColumnDgv();
        }
        /*
         * load comboBox ten hang
         */
        void loadCmbTenHang()
        {
            listHh = DAOHangHoa.Instance.getAllHangHoa();
            cmbTenHang.DataSource =listHh;
            cmbTenHang.DisplayMember = "TenHang";
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }
        void loadCmbNhanVien()
        {
            listNv = DAONhanVien.Instance.getAllNhanVien();
            cmbNv.DataSource = listNv;
            cmbNv.DisplayMember = "TenNhanVien";
        }
        void loadCmbKhachHang()
        {
            KhachHangDTO kh = new KhachHangDTO() { TenKhach = "Khach hang moi" };
            listKh = DAOKhachHang.Instance.getAllKhachHang();
            listKh.Add(kh);
            cmbKh.DataSource = listKh;
            cmbKh.DisplayMember = "TenKhach";
            
        }
        void ranDomMaHD()
        {
            bool check = true;
            List<HoaDonBanDTO> hdbs = DAOHoaDonBan.Instance.getAllHDBan();
            do
            {
                Random random = new Random();
                maHd = random.Next(1, 100000).ToString();
                foreach (HoaDonBanDTO item in hdbs)
                {
                    if (item.MaHD != maHd)
                        check =  false;  
                }
            } while (check);
        }
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void addColumnDgv()//Them cac column vao datagridview
        {
            dgvCtHD.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "MaHD" ,Width = 150 });
            dgvCtHD.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ten hang", Width = 150 });
            dgvCtHD.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "So Luong", Width = 150 });
            dgvCtHD.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Don Gia", Width = 150 });
            dgvCtHD.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Giam Gia", Width = 150 });
            dgvCtHD.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Thanh Tien", Width = 150 });
        }
        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            DanhMucChatLieu cl = new DanhMucChatLieu();
            cl.ShowDialog();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanVien nv = new frmDMNhanVien();
            nv.ShowDialog();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang kh =new frmDMKhachHang();
            kh.ShowDialog();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHang hh = new frmDMHang();
            hh.ShowDialog();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan hdb = new frmHoaDonBan();
            hdb.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            loadCmbKhachHang();
            
            NhanVienDTO nv = (NhanVienDTO)cmbNv.SelectedItem;
            KhachHangDTO kh = (KhachHangDTO)cmbKh.SelectedItem;
            HoaDonBanDTO hdb = new HoaDonBanDTO() { MaHD = maHd, MaNhanVien = nv.MaNhanVien, NgayBan = DateTime.Now, MaKhachHang = kh.MaKhach, TongTien = float.Parse(txtTongTien.Text) };
            if(DAOHoaDonBan.Instance.SaveHDBan(hdb))
            {
                bool check = true;
                foreach (CTHoaDonDTO item in listHd)
                {
                    if (DAOCTHoaDon.Instance.saveDatatoSql(item) == false)
                    {
                        check = false;
                    }
                }
                if (check == false)
                {
                    MessageBox.Show("Da xay ra loi trong qua trinh luu HD");
                    return;
                }
                MessageBox.Show("Luu thanh cong");
                resetDgv();
            }
            else
            {
                MessageBox.Show("Xay ra loi");
            }
            
        }
        
        void resetDgv()//Clear cac Row trong datagridview
        {
            dgvCtHD.Rows.Clear();
            txtTongTien.Text ="";
            txtSL.Text = "";
        }
        /*
         * Update lai tong tien trong CThoaDon dua vao ma Hang
         * tham so maHang , soLuong
         */
        void updateThanhTien(string maHang, float soLuong,float giamGia)
        {
            foreach (CTHoaDonDTO item in listHd)
            {
                if(item.MaHang == maHang)
                {
                    item.SoLuong = soLuong;
                    item.GiamGia = giamGia;
                    item.ThanhTien = tinhThanhTien(item.SoLuong, item.DonGia, item.GiamGia);
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = true;
            
            if (!IsNumber(txtSL.Text) || String.IsNullOrEmpty(txtSL.Text))
            {               
                MessageBox.Show("So luong phai la chu so!!!");
                txtSL.Focus();
                return;
            }
            if(float.Parse(txtSL.Text) < 0)
            {
                MessageBox.Show("So luong phai lon hon 0!!!");
                txtSL.Focus();
                return;
            }
            HangHoaDTO hh =(HangHoaDTO)cmbTenHang.SelectedItem;
            CTHoaDonDTO hd = new CTHoaDonDTO() { MaHD = maHd, MaHang = hh.MaHang, SoLuong = float.Parse(txtSL.Text) , DonGia = hh.DonGiaBan,GiamGia = float.Parse(nmrGiamGia.Value.ToString()) ,ThanhTien = tinhThanhTien(float.Parse(txtSL.Text), hh.DonGiaBan , float.Parse(nmrGiamGia.Value.ToString()))};
           
              foreach (DataGridViewRow item in dgvCtHD.Rows)
                {
                        if (item.Cells[1].Value == null)
                            break;
                        if (item.Cells[1].Value.ToString() == hh.TenHang)
                        {
                            item.Cells[2].Value = (float.Parse(item.Cells[2].Value.ToString())+hd.SoLuong).ToString();
                            check = false;
                            item.Cells[4].Value = (float.Parse(item.Cells[4].Value.ToString())+hd.GiamGia).ToString();
                            updateThanhTien(hh.MaHang, float.Parse(item.Cells[2].Value.ToString()), float.Parse(item.Cells[4].Value.ToString()));
                            item.Cells[5].Value = (float.Parse(item.Cells[2].Value.ToString()) * float.Parse(item.Cells[3].Value.ToString()) - float.Parse(item.Cells[2].Value.ToString()) * float.Parse(item.Cells[3].Value.ToString())*float.Parse(item.Cells[4].Value.ToString())/100).ToString();
                        }

                }
            
            if(check == true)
            {
                dgvCtHD.Rows.Add(new Object[] { maHd, hh.TenHang, float.Parse(txtSL.Text), hh.DonGiaBan, float.Parse(nmrGiamGia.Value.ToString()), tinhThanhTien(float.Parse(txtSL.Text), hh.DonGiaBan, float.Parse(nmrGiamGia.Value.ToString())) });
                listHd.Add(hd);
            }
            thanhTien = 0;
            foreach (CTHoaDonDTO item in listHd)
            {
                thanhTien+=item.ThanhTien;
            }
            txtTongTien.Text = thanhTien.ToString();
        }
        /*
         * Tinh thanh tien dua vao don gia , soluong , giamgia
         * tham so don gia , soluong , giamgia
         * return thanhTien
         */
        float tinhThanhTien(float soLuong ,  float donGia , float giamGia)
        {
            return (soLuong*donGia)-(soLuong*donGia)*((float)giamGia/100);
        }
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            btnThemHD.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false ;
            ranDomMaHD();
        }

        private void dgvCtHD_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Ban co chac muon xoa khong??","Thong bao",MessageBoxButtons.OKCancel);
            if(dl == DialogResult.OK)
            {
                thanhTien = thanhTien - float.Parse(dgvCtHD.CurrentRow.Cells[5].Value.ToString().ToString());
                txtTongTien.Text =thanhTien.ToString();
                HangHoaDTO temp = new HangHoaDTO();
                foreach (HangHoaDTO item in listHh)
                {
                    if (item.TenHang == dgvCtHD.CurrentRow.Cells[1].Value.ToString())
                        temp = item;
                }

                foreach (CTHoaDonDTO item in listHd)
                {
                    if(item.MaHang == temp.MaHang)
                    {
                        listHd.Remove(item);
                        break;
                    }
                }
                dgvCtHD.Rows.Remove(dgvCtHD.CurrentRow);
            }
            
            btnXoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {            
            dgvCtHD.Rows.Clear();
            for(int i = listHd.Count- 1; i >= 0;i--)
            {
                listHd.RemoveAt(i);
            }
            btnHuy.Enabled = false;
            btnThem.Enabled = false ;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnThemHD.Enabled = true;
            thanhTien= 0;
            txtTongTien.Text ="";
        }
        
        private void cmbKh_SelectedValueChanged(object sender, EventArgs e)
        {
            KhachHangDTO kh = (KhachHangDTO)cmbKh.SelectedItem;
            if(kh.TenKhach == "Khach hang moi")
            {
                mnuKhachHang_Click(sender, e);
            }
        }
        /*
         * Kiem tra xem txtSL co phai so hay khong
         */
        
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}