using System.Windows.Forms;

namespace GUI
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lbl_role = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnStatic = new System.Windows.Forms.Button();
            this.btnCreateAcc = new System.Windows.Forms.Button();
            this.btnAcc = new System.Windows.Forms.Button();
            this.btnBookManager = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblClubName = new System.Windows.Forms.Label();
            this.logoLib = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelBookManager = new System.Windows.Forms.Panel();
            this.btnSearchPhieu = new System.Windows.Forms.Button();
            this.cbbSort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.btnSuaPhieu = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.lblBookManager = new System.Windows.Forms.Label();
            this.btnMuonSach = new System.Windows.Forms.Button();
            this.panelInfoCard = new System.Windows.Forms.Panel();
            this.lblDiaChi = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.TextBox();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.panelStatic = new System.Windows.Forms.Panel();
            this.lblStatic = new System.Windows.Forms.Label();
            this.panelCreateAcc = new System.Windows.Forms.Panel();
            this.lblCreateAcc = new System.Windows.Forms.Label();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoLib)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelBookManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.panelInfoCard.SuspendLayout();
            this.panelStatic.SuspendLayout();
            this.panelCreateAcc.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(74)))), ((int)(((byte)(191)))));
            this.panelSidebar.Controls.Add(this.lbl_role);
            this.panelSidebar.Controls.Add(this.label1);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnStatic);
            this.panelSidebar.Controls.Add(this.btnCreateAcc);
            this.panelSidebar.Controls.Add(this.btnAcc);
            this.panelSidebar.Controls.Add(this.btnBookManager);
            this.panelSidebar.Controls.Add(this.btnSearch);
            this.panelSidebar.Controls.Add(this.lblClubName);
            this.panelSidebar.Controls.Add(this.logoLib);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 804);
            this.panelSidebar.TabIndex = 0;
            // 
            // lbl_role
            // 
            this.lbl_role.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
            this.lbl_role.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_role.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_role.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_role.Location = new System.Drawing.Point(0, 0);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(250, 38);
            this.lbl_role.TabIndex = 5;
            this.lbl_role.Text = "Vai trò";
            this.lbl_role.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 48);
            this.label1.TabIndex = 9;
            this.label1.Text = "Thư Viện";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Salmon;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(46, 705);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(171, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnStatic
            // 
            this.btnStatic.BackColor = System.Drawing.Color.Transparent;
            this.btnStatic.FlatAppearance.BorderSize = 0;
            this.btnStatic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatic.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatic.ForeColor = System.Drawing.Color.White;
            this.btnStatic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatic.Location = new System.Drawing.Point(19, 500);
            this.btnStatic.Name = "btnStatic";
            this.btnStatic.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnStatic.Size = new System.Drawing.Size(210, 40);
            this.btnStatic.TabIndex = 7;
            this.btnStatic.Text = "Thống kê";
            this.btnStatic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatic.UseVisualStyleBackColor = false;
            this.btnStatic.Click += new System.EventHandler(this.btnStatic_Click);
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateAcc.FlatAppearance.BorderSize = 0;
            this.btnCreateAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAcc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAcc.ForeColor = System.Drawing.Color.White;
            this.btnCreateAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAcc.Location = new System.Drawing.Point(19, 455);
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnCreateAcc.Size = new System.Drawing.Size(225, 40);
            this.btnCreateAcc.TabIndex = 6;
            this.btnCreateAcc.Text = "Quản lý tài khoản";
            this.btnCreateAcc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAcc.UseVisualStyleBackColor = false;
            this.btnCreateAcc.Click += new System.EventHandler(this.btnCreateAcc_Click);
            // 
            // btnAcc
            // 
            this.btnAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(74)))), ((int)(((byte)(191)))));
            this.btnAcc.FlatAppearance.BorderSize = 0;
            this.btnAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAcc.ForeColor = System.Drawing.Color.White;
            this.btnAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcc.Location = new System.Drawing.Point(19, 320);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnAcc.Size = new System.Drawing.Size(210, 40);
            this.btnAcc.TabIndex = 5;
            this.btnAcc.Text = "Tài khoản";
            this.btnAcc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcc.UseVisualStyleBackColor = false;
            this.btnAcc.Click += new System.EventHandler(this.btnAcc_Click);
            // 
            // btnBookManager
            // 
            this.btnBookManager.BackColor = System.Drawing.Color.Transparent;
            this.btnBookManager.FlatAppearance.BorderSize = 0;
            this.btnBookManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookManager.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookManager.ForeColor = System.Drawing.Color.White;
            this.btnBookManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookManager.Location = new System.Drawing.Point(18, 364);
            this.btnBookManager.Name = "btnBookManager";
            this.btnBookManager.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnBookManager.Size = new System.Drawing.Size(251, 40);
            this.btnBookManager.TabIndex = 4;
            this.btnBookManager.Text = "Quản lý mượn sách";
            this.btnBookManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookManager.UseVisualStyleBackColor = false;
            this.btnBookManager.Click += new System.EventHandler(this.btnBookManager_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(19, 410);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(210, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tra cứu sách";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblClubName
            // 
            this.lblClubName.AutoSize = true;
            this.lblClubName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblClubName.ForeColor = System.Drawing.Color.White;
            this.lblClubName.Location = new System.Drawing.Point(15, 192);
            this.lblClubName.Name = "lblClubName";
            this.lblClubName.Size = new System.Drawing.Size(156, 48);
            this.lblClubName.TabIndex = 1;
            this.lblClubName.Text = "Quản Lý";
            // 
            // logoLib
            // 
            this.logoLib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(60)))), ((int)(((byte)(150)))));
            this.logoLib.Image = ((System.Drawing.Image)(resources.GetObject("logoLib.Image")));
            this.logoLib.Location = new System.Drawing.Point(56, 44);
            this.logoLib.Name = "logoLib";
            this.logoLib.Size = new System.Drawing.Size(155, 145);
            this.logoLib.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoLib.TabIndex = 0;
            this.logoLib.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelMain.Controls.Add(this.panelBookManager);
            this.panelMain.Controls.Add(this.panelInfoCard);
            this.panelMain.Controls.Add(this.lbTaiKhoan);
            this.panelMain.Controls.Add(this.panelStatic);
            this.panelMain.Controls.Add(this.panelCreateAcc);
            this.panelMain.Controls.Add(this.panelAccount);
            this.panelMain.Controls.Add(this.panelSearch);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(250, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelMain.Size = new System.Drawing.Size(946, 744);
            this.panelMain.TabIndex = 1;
            // 
            // panelBookManager
            // 
            this.panelBookManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelBookManager.Controls.Add(this.btnSearchPhieu);
            this.panelBookManager.Controls.Add(this.cbbSort);
            this.panelBookManager.Controls.Add(this.btnHuyPhieu);
            this.panelBookManager.Controls.Add(this.btnSuaPhieu);
            this.panelBookManager.Controls.Add(this.txtSearch);
            this.panelBookManager.Controls.Add(this.btnTraSach);
            this.panelBookManager.Controls.Add(this.dgvPhieuMuon);
            this.panelBookManager.Controls.Add(this.lblBookManager);
            this.panelBookManager.Controls.Add(this.btnMuonSach);
            this.panelBookManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBookManager.Location = new System.Drawing.Point(30, 20);
            this.panelBookManager.Name = "panelBookManager";
            this.panelBookManager.Size = new System.Drawing.Size(886, 704);
            this.panelBookManager.TabIndex = 13;
            this.panelBookManager.Visible = false;
            // 
            // btnSearchPhieu
            // 
            this.btnSearchPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPhieu.Image")));
            this.btnSearchPhieu.Location = new System.Drawing.Point(233, 166);
            this.btnSearchPhieu.Name = "btnSearchPhieu";
            this.btnSearchPhieu.Size = new System.Drawing.Size(42, 39);
            this.btnSearchPhieu.TabIndex = 7;
            this.btnSearchPhieu.UseVisualStyleBackColor = true;
            this.btnSearchPhieu.Click += new System.EventHandler(this.btnSearchPhieu_Click);
            // 
            // cbbSort
            // 
            this.cbbSort.EditValue = "Sắp xếp";
            this.cbbSort.Location = new System.Drawing.Point(747, 164);
            this.cbbSort.Margin = new System.Windows.Forms.Padding(4);
            this.cbbSort.Name = "cbbSort";
            this.cbbSort.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSort.Properties.Appearance.Options.UseFont = true;
            this.cbbSort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbSort.Properties.DropDownRows = 2;
            this.cbbSort.Properties.Items.AddRange(new object[] {
            "Mới nhất",
            "Cũ nhất"});
            this.cbbSort.Size = new System.Drawing.Size(118, 36);
            this.cbbSort.TabIndex = 6;
            this.cbbSort.SelectedIndexChanged += new System.EventHandler(this.cbbSort_SelectedIndexChanged);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(74)))), ((int)(((byte)(191)))));
            this.btnHuyPhieu.FlatAppearance.BorderSize = 0;
            this.btnHuyPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuyPhieu.ForeColor = System.Drawing.Color.White;
            this.btnHuyPhieu.Location = new System.Drawing.Point(280, 111);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(130, 40);
            this.btnHuyPhieu.TabIndex = 5;
            this.btnHuyPhieu.Text = "Hủy Phiếu";
            this.btnHuyPhieu.UseVisualStyleBackColor = false;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // btnSuaPhieu
            // 
            this.btnSuaPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(74)))), ((int)(((byte)(191)))));
            this.btnSuaPhieu.FlatAppearance.BorderSize = 0;
            this.btnSuaPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuaPhieu.ForeColor = System.Drawing.Color.White;
            this.btnSuaPhieu.Location = new System.Drawing.Point(425, 111);
            this.btnSuaPhieu.Name = "btnSuaPhieu";
            this.btnSuaPhieu.Size = new System.Drawing.Size(130, 40);
            this.btnSuaPhieu.TabIndex = 4;
            this.btnSuaPhieu.Text = "Sửa Phiếu";
            this.btnSuaPhieu.UseVisualStyleBackColor = false;
            this.btnSuaPhieu.Click += new System.EventHandler(this.btnSuaPhieu_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(280, 166);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(293, 37);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(74)))), ((int)(((byte)(191)))));
            this.btnTraSach.FlatAppearance.BorderSize = 0;
            this.btnTraSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTraSach.ForeColor = System.Drawing.Color.White;
            this.btnTraSach.Location = new System.Drawing.Point(570, 111);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(130, 40);
            this.btnTraSach.TabIndex = 3;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(21, 206);
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.RowHeadersWidth = 62;
            this.dgvPhieuMuon.RowTemplate.Height = 28;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(845, 459);
            this.dgvPhieuMuon.TabIndex = 1;
            // 
            // lblBookManager
            // 
            this.lblBookManager.AutoSize = true;
            this.lblBookManager.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBookManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblBookManager.Location = new System.Drawing.Point(24, 18);
            this.lblBookManager.Name = "lblBookManager";
            this.lblBookManager.Size = new System.Drawing.Size(461, 65);
            this.lblBookManager.TabIndex = 0;
            this.lblBookManager.Text = "Quản lý mượn sách";
            // 
            // btnMuonSach
            // 
            this.btnMuonSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(74)))), ((int)(((byte)(191)))));
            this.btnMuonSach.FlatAppearance.BorderSize = 0;
            this.btnMuonSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuonSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMuonSach.ForeColor = System.Drawing.Color.White;
            this.btnMuonSach.Location = new System.Drawing.Point(715, 111);
            this.btnMuonSach.Name = "btnMuonSach";
            this.btnMuonSach.Size = new System.Drawing.Size(151, 40);
            this.btnMuonSach.TabIndex = 2;
            this.btnMuonSach.Text = "Mượn Sách";
            this.btnMuonSach.UseVisualStyleBackColor = false;
            this.btnMuonSach.Click += new System.EventHandler(this.btnMuonSach_Click);
            // 
            // panelInfoCard
            // 
            this.panelInfoCard.BackColor = System.Drawing.Color.White;
            this.panelInfoCard.Controls.Add(this.lblDiaChi);
            this.panelInfoCard.Controls.Add(this.lblChucVu);
            this.panelInfoCard.Controls.Add(this.lblGioiTinh);
            this.panelInfoCard.Controls.Add(this.lblEmail);
            this.panelInfoCard.Controls.Add(this.lblSDT);
            this.panelInfoCard.Controls.Add(this.lblCCCD);
            this.panelInfoCard.Controls.Add(this.lblNgaySinh);
            this.panelInfoCard.Controls.Add(this.lblHoTen);
            this.panelInfoCard.Controls.Add(this.lblId);
            this.panelInfoCard.Location = new System.Drawing.Point(40, 150);
            this.panelInfoCard.Name = "panelInfoCard";
            this.panelInfoCard.Size = new System.Drawing.Size(870, 550);
            this.panelInfoCard.TabIndex = 12;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblDiaChi.Location = new System.Drawing.Point(30, 450);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(810, 45);
            this.lblDiaChi.TabIndex = 11;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // lblChucVu
            // 
            this.lblChucVu.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblChucVu.Location = new System.Drawing.Point(450, 360);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(390, 45);
            this.lblChucVu.TabIndex = 10;
            this.lblChucVu.Text = "Chức vụ";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblGioiTinh.Location = new System.Drawing.Point(450, 270);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(390, 45);
            this.lblGioiTinh.TabIndex = 9;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblEmail.Location = new System.Drawing.Point(450, 180);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(390, 45);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // lblSDT
            // 
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSDT.Location = new System.Drawing.Point(450, 90);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(390, 45);
            this.lblSDT.TabIndex = 7;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblCCCD
            // 
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblCCCD.Location = new System.Drawing.Point(30, 360);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(390, 45);
            this.lblCCCD.TabIndex = 6;
            this.lblCCCD.Text = "CCCD";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 270);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(390, 45);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblHoTen.Location = new System.Drawing.Point(30, 180);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(390, 45);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "Họ tên";
            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblId.Location = new System.Drawing.Point(30, 90);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(390, 45);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "ID: ";
            // 
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lbTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbTaiKhoan.Location = new System.Drawing.Point(40, 40);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(436, 65);
            this.lbTaiKhoan.TabIndex = 0;
            this.lbTaiKhoan.Text = "Thông tin cá nhân";
            // 
            // panelStatic
            // 
            this.panelStatic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelStatic.Controls.Add(this.lblStatic);
            this.panelStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatic.Location = new System.Drawing.Point(30, 20);
            this.panelStatic.Name = "panelStatic";
            this.panelStatic.Size = new System.Drawing.Size(886, 704);
            this.panelStatic.TabIndex = 16;
            this.panelStatic.Visible = false;
            // 
            // lblStatic
            // 
            this.lblStatic.AutoSize = true;
            this.lblStatic.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblStatic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStatic.Location = new System.Drawing.Point(40, 40);
            this.lblStatic.Name = "lblStatic";
            this.lblStatic.Size = new System.Drawing.Size(238, 65);
            this.lblStatic.TabIndex = 0;
            this.lblStatic.Text = "Thống kê";
            // 
            // panelCreateAcc
            // 
            this.panelCreateAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelCreateAcc.Controls.Add(this.lblCreateAcc);
            this.panelCreateAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCreateAcc.Location = new System.Drawing.Point(30, 20);
            this.panelCreateAcc.Name = "panelCreateAcc";
            this.panelCreateAcc.Size = new System.Drawing.Size(886, 704);
            this.panelCreateAcc.TabIndex = 15;
            this.panelCreateAcc.Visible = false;
            // 
            // lblCreateAcc
            // 
            this.lblCreateAcc.AutoSize = true;
            this.lblCreateAcc.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCreateAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblCreateAcc.Location = new System.Drawing.Point(40, 40);
            this.lblCreateAcc.Name = "lblCreateAcc";
            this.lblCreateAcc.Size = new System.Drawing.Size(336, 65);
            this.lblCreateAcc.TabIndex = 0;
            this.lblCreateAcc.Text = "Tạo tài khoản";
            // 
            // panelAccount
            // 
            this.panelAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccount.Location = new System.Drawing.Point(30, 20);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(886, 704);
            this.panelAccount.TabIndex = 17;
            this.panelAccount.Visible = false;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearch.Location = new System.Drawing.Point(30, 20);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(886, 704);
            this.panelSearch.TabIndex = 14;
            this.panelSearch.Visible = false;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblSearch.Location = new System.Drawing.Point(40, 40);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(306, 65);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tra cứu sách";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.btnSettings);
            this.panelHeader.Controls.Add(this.btnNotifications);
            this.panelHeader.Controls.Add(this.btnMenu);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(250, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(946, 60);
            this.panelHeader.TabIndex = 2;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSettings.Location = new System.Drawing.Point(880, 15);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 30);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "⚙";
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            this.btnNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnNotifications.FlatAppearance.BorderSize = 0;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifications.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNotifications.Location = new System.Drawing.Point(830, 15);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Size = new System.Drawing.Size(40, 30);
            this.btnNotifications.TabIndex = 2;
            this.btnNotifications.Text = "🔔";
            this.btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnMenu.Location = new System.Drawing.Point(20, 15);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(40, 30);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "≡";
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 804);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Silvers Club - Dashboard";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoLib)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelBookManager.ResumeLayout(false);
            this.panelBookManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbSort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.panelInfoCard.ResumeLayout(false);
            this.panelInfoCard.PerformLayout();
            this.panelStatic.ResumeLayout(false);
            this.panelStatic.PerformLayout();
            this.panelCreateAcc.ResumeLayout(false);
            this.panelCreateAcc.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnStatic;
        private System.Windows.Forms.Button btnCreateAcc;
        private System.Windows.Forms.Button btnAcc;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblClubName;
        private System.Windows.Forms.PictureBox logoLib;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lbTaiKhoan;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBookManager;
        private System.Windows.Forms.Button btnMuonSach;
        private System.Windows.Forms.TextBox lblId;
        private System.Windows.Forms.TextBox lblDiaChi;
        private System.Windows.Forms.TextBox lblChucVu;
        private System.Windows.Forms.TextBox lblGioiTinh;
        private System.Windows.Forms.TextBox lblEmail;
        private System.Windows.Forms.TextBox lblSDT;
        private System.Windows.Forms.TextBox lblCCCD;
        private System.Windows.Forms.TextBox lblNgaySinh;
        private System.Windows.Forms.TextBox lblHoTen;
        private System.Windows.Forms.TextBox lbl_role;
        private System.Windows.Forms.Panel panelInfoCard;
        private System.Windows.Forms.Panel panelBookManager;
        private System.Windows.Forms.Label lblBookManager;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panelCreateAcc;
        private System.Windows.Forms.Label lblCreateAcc;
        private System.Windows.Forms.Panel panelStatic;
        private System.Windows.Forms.Label lblStatic;
        private System.Windows.Forms.Panel panelAccount;
        private DataGridView dgvPhieuMuon;
        private Button btnSuaPhieu;
        private Button btnTraSach;
        private Button btnHuyPhieu;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSort;
        private Button btnSearchPhieu;
    }
}