namespace QuanLyBanHangLuuNiem
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChatLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHienTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVaiNet = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbKh = new System.Windows.Forms.ComboBox();
            this.cmbNv = new System.Windows.Forms.ComboBox();
            this.cmbKhachHang = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.Label();
            this.btnThemHD = new System.Windows.Forms.Button();
            this.dgvCtHD = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nmrGiamGia = new System.Windows.Forms.NumericUpDown();
            this.cmbTenHang = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuDanhMuc,
            this.mnuHoaDon,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1638, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThoat});
            this.mnuFile.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(130, 41);
            this.mnuFile.Text = "Tap Tin";
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(359, 46);
            this.mnuThoat.Text = "Thoat";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChatLieu,
            this.mnuNhanVien,
            this.mnuKhachHang,
            this.mnuHangHoa});
            this.mnuDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuDanhMuc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(166, 41);
            this.mnuDanhMuc.Text = "Danh Muc";
            // 
            // mnuChatLieu
            // 
            this.mnuChatLieu.Name = "mnuChatLieu";
            this.mnuChatLieu.Size = new System.Drawing.Size(359, 46);
            this.mnuChatLieu.Text = "Chat Lieu";
            this.mnuChatLieu.Click += new System.EventHandler(this.mnuChatLieu_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(359, 46);
            this.mnuNhanVien.Text = "Nhan Vien ";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(359, 46);
            this.mnuKhachHang.Text = "Khach Hang";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuHangHoa
            // 
            this.mnuHangHoa.Name = "mnuHangHoa";
            this.mnuHangHoa.Size = new System.Drawing.Size(359, 46);
            this.mnuHangHoa.Text = "HangHoa";
            this.mnuHangHoa.Click += new System.EventHandler(this.mnuHangHoa_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoaDonBan});
            this.mnuHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuHoaDon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Size = new System.Drawing.Size(150, 41);
            this.mnuHoaDon.Text = "Hoa Don";
            // 
            // mnuHoaDonBan
            // 
            this.mnuHoaDonBan.Name = "mnuHoaDonBan";
            this.mnuHoaDonBan.Size = new System.Drawing.Size(359, 46);
            this.mnuHoaDonBan.Text = "Hoa Don Ban";
            this.mnuHoaDonBan.Click += new System.EventHandler(this.mnuHoaDonBan_Click);
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHienTroGiup,
            this.mnuVaiNet});
            this.mnuTroGiup.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuTroGiup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(146, 41);
            this.mnuTroGiup.Text = "Tro Giup";
            // 
            // mnuHienTroGiup
            // 
            this.mnuHienTroGiup.Name = "mnuHienTroGiup";
            this.mnuHienTroGiup.Size = new System.Drawing.Size(359, 46);
            this.mnuHienTroGiup.Text = "Tro Giup";
            // 
            // mnuVaiNet
            // 
            this.mnuVaiNet.Name = "mnuVaiNet";
            this.mnuVaiNet.Size = new System.Drawing.Size(359, 46);
            this.mnuVaiNet.Text = "Vai Net";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(23, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1603, 113);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label5.Location = new System.Drawing.Point(541, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(522, 78);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chi Tiet Hoa Don";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbKh);
            this.panel2.Controls.Add(this.cmbNv);
            this.panel2.Controls.Add(this.cmbKhachHang);
            this.panel2.Controls.Add(this.cmbNhanVien);
            this.panel2.Controls.Add(this.btnThemHD);
            this.panel2.Controls.Add(this.dgvCtHD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnHuy);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.txtTongTien);
            this.panel2.ForeColor = System.Drawing.Color.DarkSalmon;
            this.panel2.Location = new System.Drawing.Point(23, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1603, 563);
            this.panel2.TabIndex = 2;
            // 
            // cmbKh
            // 
            this.cmbKh.FormattingEnabled = true;
            this.cmbKh.Location = new System.Drawing.Point(1257, 67);
            this.cmbKh.Name = "cmbKh";
            this.cmbKh.Size = new System.Drawing.Size(242, 53);
            this.cmbKh.TabIndex = 13;
            this.cmbKh.SelectedValueChanged += new System.EventHandler(this.cmbKh_SelectedValueChanged);
            // 
            // cmbNv
            // 
            this.cmbNv.FormattingEnabled = true;
            this.cmbNv.Location = new System.Drawing.Point(1257, 8);
            this.cmbNv.Name = "cmbNv";
            this.cmbNv.Size = new System.Drawing.Size(242, 53);
            this.cmbNv.TabIndex = 12;
            // 
            // cmbKhachHang
            // 
            this.cmbKhachHang.AutoSize = true;
            this.cmbKhachHang.Location = new System.Drawing.Point(1031, 67);
            this.cmbKhachHang.Name = "cmbKhachHang";
            this.cmbKhachHang.Size = new System.Drawing.Size(192, 45);
            this.cmbKhachHang.TabIndex = 11;
            this.cmbKhachHang.Text = "KhachHang";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.AutoSize = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(1031, 3);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(166, 45);
            this.cmbNhanVien.TabIndex = 10;
            this.cmbNhanVien.Text = "NhanVien";
            // 
            // btnThemHD
            // 
            this.btnThemHD.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThemHD.Location = new System.Drawing.Point(1047, 318);
            this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.Size = new System.Drawing.Size(170, 65);
            this.btnThemHD.TabIndex = 9;
            this.btnThemHD.Text = "ThemHD";
            this.btnThemHD.UseVisualStyleBackColor = true;
            this.btnThemHD.Click += new System.EventHandler(this.btnThemHD_Click);
            // 
            // dgvCtHD
            // 
            this.dgvCtHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtHD.Location = new System.Drawing.Point(3, 3);
            this.dgvCtHD.Name = "dgvCtHD";
            this.dgvCtHD.RowHeadersWidth = 82;
            this.dgvCtHD.RowTemplate.Height = 41;
            this.dgvCtHD.Size = new System.Drawing.Size(1022, 489);
            this.dgvCtHD.TabIndex = 0;
            this.dgvCtHD.Click += new System.EventHandler(this.dgvCtHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1074, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "TongTien";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnHuy.Location = new System.Drawing.Point(1450, 318);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 65);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Huy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnLuu.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnLuu.Location = new System.Drawing.Point(1257, 318);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 65);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Luu HD";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(1239, 209);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(324, 50);
            this.txtTongTien.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1000, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 45);
            this.label4.TabIndex = 10;
            this.label4.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(725, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 45);
            this.label2.TabIndex = 6;
            this.label2.Text = "GiamGia";
            // 
            // nmrGiamGia
            // 
            this.nmrGiamGia.Location = new System.Drawing.Point(904, 237);
            this.nmrGiamGia.Name = "nmrGiamGia";
            this.nmrGiamGia.Size = new System.Drawing.Size(90, 50);
            this.nmrGiamGia.TabIndex = 9;
            // 
            // cmbTenHang
            // 
            this.cmbTenHang.FormattingEnabled = true;
            this.cmbTenHang.Location = new System.Drawing.Point(213, 241);
            this.cmbTenHang.Name = "cmbTenHang";
            this.cmbTenHang.Size = new System.Drawing.Size(289, 53);
            this.cmbTenHang.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(26, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 45);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ten Hang";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(529, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 45);
            this.label7.TabIndex = 5;
            this.label7.Text = "SL";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(620, 241);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(99, 50);
            this.txtSL.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThem.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.Location = new System.Drawing.Point(1280, 225);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 66);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnXoa.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.Location = new System.Drawing.Point(1141, 225);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(115, 66);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1638, 829);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTenHang);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nmrGiamGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Chuong Trinh Quan Ly Ban Hang Luu Niem ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuChatLieu;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuHangHoa;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem mnuHoaDonBan;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuHienTroGiup;
        private ToolStripMenuItem mnuVaiNet;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvCtHD;
        private Button btnLuu;
        private Button btnHuy;
        private Label label5;
        private Label label1;
        private TextBox txtTongTien;
        private Label label4;
        private Label label2;
        private NumericUpDown nmrGiamGia;
        private ComboBox cmbTenHang;
        private Label label6;
        private Label label7;
        private TextBox txtSL;
        private Button btnThem;
        private Button btnXoa;
        private Button btnThemHD;
        private ComboBox cmbKh;
        private ComboBox cmbNv;
        private Label cmbKhachHang;
        private Label cmbNhanVien;
    }
}