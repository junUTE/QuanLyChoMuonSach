namespace GUI
{
    partial class frmTraSach
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.Label lblMaPhieu, lblMaDocGia, lblNgayMuon, lblNgayHenTra, lblNgayTra, lblTrangThai;
        private System.Windows.Forms.TextBox txtMaPhieu, txtMaDocGia, txtNgayMuon, txtNgayHenTra, txtNgayTra, txtTrangThai;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraSach));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.gbThongTinPhieu = new System.Windows.Forms.GroupBox();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.dateTra = new System.Windows.Forms.DateTimePicker();
            this.dateMuon = new System.Windows.Forms.DateTimePicker();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbThongTinSach = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbTinhTrangMoi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCTPhieuMuon = new System.Windows.Forms.DataGridView();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.lblMaDocGia = new System.Windows.Forms.Label();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.lblNgayHenTra = new System.Windows.Forms.Label();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.txtNgayMuon = new System.Windows.Forms.TextBox();
            this.txtNgayHenTra = new System.Windows.Forms.TextBox();
            this.txtNgayTra = new System.Windows.Forms.TextBox();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.gbThongTinPhieu.SuspendLayout();
            this.gbThongTinSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTinhTrangMoi.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.08642F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.91358F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1167, 560);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRight.Controls.Add(this.gbThongTinPhieu, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.gbThongTinSach, 0, 1);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(622, 3);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 2;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.72202F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.27798F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(542, 554);
            this.tableLayoutPanelRight.TabIndex = 1;
            // 
            // gbThongTinPhieu
            // 
            this.gbThongTinPhieu.Controls.Add(this.btnClose);
            this.gbThongTinPhieu.Controls.Add(this.btnTraSach);
            this.gbThongTinPhieu.Controls.Add(this.dateTra);
            this.gbThongTinPhieu.Controls.Add(this.dateMuon);
            this.gbThongTinPhieu.Controls.Add(this.txtHoTen);
            this.gbThongTinPhieu.Controls.Add(this.txtMaNV);
            this.gbThongTinPhieu.Controls.Add(this.txtMaDG);
            this.gbThongTinPhieu.Controls.Add(this.label5);
            this.gbThongTinPhieu.Controls.Add(this.label4);
            this.gbThongTinPhieu.Controls.Add(this.label3);
            this.gbThongTinPhieu.Controls.Add(this.label2);
            this.gbThongTinPhieu.Controls.Add(this.label1);
            this.gbThongTinPhieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbThongTinPhieu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbThongTinPhieu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbThongTinPhieu.Location = new System.Drawing.Point(3, 3);
            this.gbThongTinPhieu.Name = "gbThongTinPhieu";
            this.gbThongTinPhieu.Size = new System.Drawing.Size(536, 274);
            this.gbThongTinPhieu.TabIndex = 0;
            this.gbThongTinPhieu.TabStop = false;
            this.gbThongTinPhieu.Text = "Thông tin phiếu mượn";
            // 
            // btnTraSach
            // 
            this.btnTraSach.Location = new System.Drawing.Point(395, 218);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(121, 42);
            this.btnTraSach.TabIndex = 14;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // dateTra
            // 
            this.dateTra.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTra.Location = new System.Drawing.Point(176, 201);
            this.dateTra.Name = "dateTra";
            this.dateTra.Size = new System.Drawing.Size(186, 37);
            this.dateTra.TabIndex = 13;
            // 
            // dateMuon
            // 
            this.dateMuon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateMuon.Location = new System.Drawing.Point(176, 152);
            this.dateMuon.Name = "dateMuon";
            this.dateMuon.Size = new System.Drawing.Size(186, 37);
            this.dateMuon.TabIndex = 12;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(116, 103);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(272, 37);
            this.txtHoTen.TabIndex = 7;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(370, 46);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(146, 37);
            this.txtMaNV.TabIndex = 11;
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(116, 49);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.ReadOnly = true;
            this.txtMaDG.Size = new System.Drawing.Size(148, 37);
            this.txtMaDG.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(282, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mã NV: ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngày trả:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày mượn:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã ĐG: ";
            // 
            // gbThongTinSach
            // 
            this.gbThongTinSach.Controls.Add(this.label7);
            this.gbThongTinSach.Controls.Add(this.cbbTinhTrangMoi);
            this.gbThongTinSach.Controls.Add(this.txtGhiChu);
            this.gbThongTinSach.Controls.Add(this.label6);
            this.gbThongTinSach.Controls.Add(this.txtMaSach);
            this.gbThongTinSach.Controls.Add(this.txtTacGia);
            this.gbThongTinSach.Controls.Add(this.txtTenSach);
            this.gbThongTinSach.Controls.Add(this.lblTacGia);
            this.gbThongTinSach.Controls.Add(this.lblTenSach);
            this.gbThongTinSach.Controls.Add(this.lblMaSach);
            this.gbThongTinSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbThongTinSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbThongTinSach.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbThongTinSach.Location = new System.Drawing.Point(3, 283);
            this.gbThongTinSach.Name = "gbThongTinSach";
            this.gbThongTinSach.Size = new System.Drawing.Size(536, 268);
            this.gbThongTinSach.TabIndex = 1;
            this.gbThongTinSach.TabStop = false;
            this.gbThongTinSach.Text = "Thông tin sách chi tiết";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(75, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 30);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tình trạng mới:";
            // 
            // cbbTinhTrangMoi
            // 
            this.cbbTinhTrangMoi.Location = new System.Drawing.Point(244, 191);
            this.cbbTinhTrangMoi.Name = "cbbTinhTrangMoi";
            this.cbbTinhTrangMoi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cbbTinhTrangMoi.Properties.Appearance.Options.UseFont = true;
            this.cbbTinhTrangMoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbTinhTrangMoi.Properties.Items.AddRange(new object[] {
            "Hỏng",
            "Mất"});
            this.cbbTinhTrangMoi.Size = new System.Drawing.Size(150, 36);
            this.cbbTinhTrangMoi.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(243, 143);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ReadOnly = true;
            this.txtGhiChu.Size = new System.Drawing.Size(151, 37);
            this.txtGhiChu.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(87, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 30);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tình trạng cũ:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(116, 49);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(70, 37);
            this.txtMaSach.TabIndex = 5;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(126, 94);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.ReadOnly = true;
            this.txtTacGia.Size = new System.Drawing.Size(262, 37);
            this.txtTacGia.TabIndex = 4;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(323, 49);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.ReadOnly = true;
            this.txtTenSach.Size = new System.Drawing.Size(207, 37);
            this.txtTenSach.TabIndex = 3;
            // 
            // lblTacGia
            // 
            this.lblTacGia.Location = new System.Drawing.Point(14, 94);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(96, 30);
            this.lblTacGia.TabIndex = 0;
            this.lblTacGia.Text = "Tác giả: ";
            // 
            // lblTenSach
            // 
            this.lblTenSach.Location = new System.Drawing.Point(214, 49);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(109, 30);
            this.lblTenSach.TabIndex = 1;
            this.lblTenSach.Text = "Tên sách: ";
            // 
            // lblMaSach
            // 
            this.lblMaSach.Location = new System.Drawing.Point(14, 49);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(106, 33);
            this.lblMaSach.TabIndex = 2;
            this.lblMaSach.Text = "Mã sách: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCTPhieuMuon);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 554);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Phiếu Mượn Chi Tiết";
            // 
            // dgvCTPhieuMuon
            // 
            this.dgvCTPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTPhieuMuon.Location = new System.Drawing.Point(3, 31);
            this.dgvCTPhieuMuon.Name = "dgvCTPhieuMuon";
            this.dgvCTPhieuMuon.RowHeadersWidth = 62;
            this.dgvCTPhieuMuon.RowTemplate.Height = 28;
            this.dgvCTPhieuMuon.Size = new System.Drawing.Size(607, 520);
            this.dgvCTPhieuMuon.TabIndex = 0;
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.Location = new System.Drawing.Point(0, 0);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(100, 23);
            this.lblMaPhieu.TabIndex = 0;
            // 
            // lblMaDocGia
            // 
            this.lblMaDocGia.Location = new System.Drawing.Point(0, 0);
            this.lblMaDocGia.Name = "lblMaDocGia";
            this.lblMaDocGia.Size = new System.Drawing.Size(100, 23);
            this.lblMaDocGia.TabIndex = 0;
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.Location = new System.Drawing.Point(0, 0);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(100, 23);
            this.lblNgayMuon.TabIndex = 0;
            // 
            // lblNgayHenTra
            // 
            this.lblNgayHenTra.Location = new System.Drawing.Point(0, 0);
            this.lblNgayHenTra.Name = "lblNgayHenTra";
            this.lblNgayHenTra.Size = new System.Drawing.Size(100, 23);
            this.lblNgayHenTra.TabIndex = 0;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.Location = new System.Drawing.Point(0, 0);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(100, 23);
            this.lblNgayTra.TabIndex = 0;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 0;
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(0, 0);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(100, 26);
            this.txtMaPhieu.TabIndex = 0;
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.Location = new System.Drawing.Point(0, 0);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.Size = new System.Drawing.Size(100, 26);
            this.txtMaDocGia.TabIndex = 0;
            // 
            // txtNgayMuon
            // 
            this.txtNgayMuon.Location = new System.Drawing.Point(0, 0);
            this.txtNgayMuon.Name = "txtNgayMuon";
            this.txtNgayMuon.Size = new System.Drawing.Size(100, 26);
            this.txtNgayMuon.TabIndex = 0;
            // 
            // txtNgayHenTra
            // 
            this.txtNgayHenTra.Location = new System.Drawing.Point(0, 0);
            this.txtNgayHenTra.Name = "txtNgayHenTra";
            this.txtNgayHenTra.Size = new System.Drawing.Size(100, 26);
            this.txtNgayHenTra.TabIndex = 0;
            // 
            // txtNgayTra
            // 
            this.txtNgayTra.Location = new System.Drawing.Point(0, 0);
            this.txtNgayTra.Name = "txtNgayTra";
            this.txtNgayTra.Size = new System.Drawing.Size(100, 26);
            this.txtNgayTra.TabIndex = 0;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(0, 0);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(100, 26);
            this.txtTrangThai.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(395, 169);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 43);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "    Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTraSach
            // 
            this.ClientSize = new System.Drawing.Size(1167, 560);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "frmTraSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả sách";
            this.Load += new System.EventHandler(this.frmTraSach_Load_2);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.gbThongTinPhieu.ResumeLayout(false);
            this.gbThongTinPhieu.PerformLayout();
            this.gbThongTinSach.ResumeLayout(false);
            this.gbThongTinSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbTinhTrangMoi.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPhieuMuon)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.GroupBox gbThongTinPhieu;
        private System.Windows.Forms.GroupBox gbThongTinSach;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCTPhieuMuon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTra;
        private System.Windows.Forms.DateTimePicker dateMuon;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTraSach;
        private DevExpress.XtraEditors.ComboBoxEdit cbbTinhTrangMoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
    }
}
