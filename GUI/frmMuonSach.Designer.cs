namespace GUI
{
    partial class frmMuonSach
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox gbDocGia;
        private System.Windows.Forms.GroupBox gbSachMuon;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.DataGridView dgvSachMuon;
        private System.Windows.Forms.Label lblMaDG;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgayMuon;
        private System.Windows.Forms.Label lblNgayHenTra;
        private System.Windows.Forms.DateTimePicker dtNgayMuon;
        private System.Windows.Forms.DateTimePicker dtNgayHenTra;
        private System.Windows.Forms.TableLayoutPanel centerLayout;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label lblDocGiaList;
        private System.Windows.Forms.Label lblSachList;
        private System.Windows.Forms.ToolStrip toolSachMuon;
        private System.Windows.Forms.ToolStripButton btnLuu;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMuonSach));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.txtSearchDG = new System.Windows.Forms.TextBox();
            this.btnSearchDG = new System.Windows.Forms.Button();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.lblDocGiaList = new System.Windows.Forms.Label();
            this.centerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gbDocGia = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaDG = new System.Windows.Forms.Label();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgayMuon = new System.Windows.Forms.Label();
            this.dtNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.lblNgayHenTra = new System.Windows.Forms.Label();
            this.dtNgayHenTra = new System.Windows.Forms.DateTimePicker();
            this.gbSachMuon = new System.Windows.Forms.GroupBox();
            this.dgvSachMuon = new System.Windows.Forms.DataGridView();
            this.toolSachMuon = new System.Windows.Forms.ToolStrip();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.txtSearchSach = new System.Windows.Forms.TextBox();
            this.btnSearchSach = new System.Windows.Forms.Button();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.lblSachList = new System.Windows.Forms.Label();
            this.Xoa = new System.Windows.Forms.ToolStripButton();
            this.mainLayout.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.centerLayout.SuspendLayout();
            this.gbDocGia.SuspendLayout();
            this.gbSachMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachMuon)).BeginInit();
            this.toolSachMuon.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 3;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.4987F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.58486F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.98172F));
            this.mainLayout.Controls.Add(this.leftPanel, 0, 0);
            this.mainLayout.Controls.Add(this.centerLayout, 1, 0);
            this.mainLayout.Controls.Add(this.rightPanel, 2, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Size = new System.Drawing.Size(1566, 788);
            this.mainLayout.TabIndex = 0;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.txtSearchDG);
            this.leftPanel.Controls.Add(this.btnSearchDG);
            this.leftPanel.Controls.Add(this.dgvDocGia);
            this.leftPanel.Controls.Add(this.lblDocGiaList);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(3, 3);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(361, 782);
            this.leftPanel.TabIndex = 0;
            // 
            // txtSearchDG
            // 
            this.txtSearchDG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchDG.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchDG.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchDG.Location = new System.Drawing.Point(73, 67);
            this.txtSearchDG.Name = "txtSearchDG";
            this.txtSearchDG.Size = new System.Drawing.Size(276, 37);
            this.txtSearchDG.TabIndex = 9;
            // 
            // btnSearchDG
            // 
            this.btnSearchDG.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchDG.Image")));
            this.btnSearchDG.Location = new System.Drawing.Point(25, 65);
            this.btnSearchDG.Name = "btnSearchDG";
            this.btnSearchDG.Size = new System.Drawing.Size(42, 39);
            this.btnSearchDG.TabIndex = 8;
            this.btnSearchDG.UseVisualStyleBackColor = true;
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.ColumnHeadersHeight = 34;
            this.dgvDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocGia.Location = new System.Drawing.Point(0, 158);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.RowHeadersWidth = 62;
            this.dgvDocGia.Size = new System.Drawing.Size(361, 624);
            this.dgvDocGia.TabIndex = 0;
            // 
            // lblDocGiaList
            // 
            this.lblDocGiaList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDocGiaList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocGiaList.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDocGiaList.Location = new System.Drawing.Point(0, 0);
            this.lblDocGiaList.Name = "lblDocGiaList";
            this.lblDocGiaList.Size = new System.Drawing.Size(361, 158);
            this.lblDocGiaList.TabIndex = 1;
            this.lblDocGiaList.Text = "Danh sách độc giả";
            // 
            // centerLayout
            // 
            this.centerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.centerLayout.Controls.Add(this.gbDocGia, 0, 0);
            this.centerLayout.Controls.Add(this.gbSachMuon, 0, 1);
            this.centerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerLayout.Location = new System.Drawing.Point(370, 3);
            this.centerLayout.Name = "centerLayout";
            this.centerLayout.RowCount = 2;
            this.centerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.centerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centerLayout.Size = new System.Drawing.Size(738, 782);
            this.centerLayout.TabIndex = 1;
            // 
            // gbDocGia
            // 
            this.gbDocGia.Controls.Add(this.txtGhiChu);
            this.gbDocGia.Controls.Add(this.label1);
            this.gbDocGia.Controls.Add(this.lblMaDG);
            this.gbDocGia.Controls.Add(this.txtMaDG);
            this.gbDocGia.Controls.Add(this.lblHoTen);
            this.gbDocGia.Controls.Add(this.txtHoTen);
            this.gbDocGia.Controls.Add(this.lblNgayMuon);
            this.gbDocGia.Controls.Add(this.dtNgayMuon);
            this.gbDocGia.Controls.Add(this.lblNgayHenTra);
            this.gbDocGia.Controls.Add(this.dtNgayHenTra);
            this.gbDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbDocGia.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbDocGia.Location = new System.Drawing.Point(3, 3);
            this.gbDocGia.Name = "gbDocGia";
            this.gbDocGia.Size = new System.Drawing.Size(732, 215);
            this.gbDocGia.TabIndex = 0;
            this.gbDocGia.TabStop = false;
            this.gbDocGia.Text = "Thông tin độc giả";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(154, 153);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(557, 34);
            this.txtGhiChu.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(45, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ghi chú:";
            // 
            // lblMaDG
            // 
            this.lblMaDG.Location = new System.Drawing.Point(20, 61);
            this.lblMaDG.Name = "lblMaDG";
            this.lblMaDG.Size = new System.Drawing.Size(128, 31);
            this.lblMaDG.TabIndex = 0;
            this.lblMaDG.Text = "Mã độc giả:";
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(154, 61);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(150, 34);
            this.txtMaDG.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(325, 61);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(84, 36);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(415, 61);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(296, 34);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblNgayMuon
            // 
            this.lblNgayMuon.Location = new System.Drawing.Point(10, 109);
            this.lblNgayMuon.Name = "lblNgayMuon";
            this.lblNgayMuon.Size = new System.Drawing.Size(138, 34);
            this.lblNgayMuon.TabIndex = 4;
            this.lblNgayMuon.Text = "Ngày mượn:";
            // 
            // dtNgayMuon
            // 
            this.dtNgayMuon.CustomFormat = "dd/MM/yyyy";
            this.dtNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayMuon.Location = new System.Drawing.Point(154, 109);
            this.dtNgayMuon.Name = "dtNgayMuon";
            this.dtNgayMuon.Size = new System.Drawing.Size(164, 34);
            this.dtNgayMuon.TabIndex = 5;
            // 
            // lblNgayHenTra
            // 
            this.lblNgayHenTra.Location = new System.Drawing.Point(341, 109);
            this.lblNgayHenTra.Name = "lblNgayHenTra";
            this.lblNgayHenTra.Size = new System.Drawing.Size(149, 34);
            this.lblNgayHenTra.TabIndex = 6;
            this.lblNgayHenTra.Text = "Ngày hẹn trả:";
            // 
            // dtNgayHenTra
            // 
            this.dtNgayHenTra.CustomFormat = "dd/MM/yyyy";
            this.dtNgayHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayHenTra.Location = new System.Drawing.Point(496, 109);
            this.dtNgayHenTra.Name = "dtNgayHenTra";
            this.dtNgayHenTra.Size = new System.Drawing.Size(171, 34);
            this.dtNgayHenTra.TabIndex = 7;
            // 
            // gbSachMuon
            // 
            this.gbSachMuon.Controls.Add(this.dgvSachMuon);
            this.gbSachMuon.Controls.Add(this.toolSachMuon);
            this.gbSachMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSachMuon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSachMuon.ForeColor = System.Drawing.Color.Red;
            this.gbSachMuon.Location = new System.Drawing.Point(3, 224);
            this.gbSachMuon.Name = "gbSachMuon";
            this.gbSachMuon.Size = new System.Drawing.Size(732, 555);
            this.gbSachMuon.TabIndex = 1;
            this.gbSachMuon.TabStop = false;
            this.gbSachMuon.Text = "Danh sách sách mượn";
            // 
            // dgvSachMuon
            // 
            this.dgvSachMuon.ColumnHeadersHeight = 34;
            this.dgvSachMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSachMuon.Location = new System.Drawing.Point(3, 72);
            this.dgvSachMuon.Name = "dgvSachMuon";
            this.dgvSachMuon.RowHeadersWidth = 62;
            this.dgvSachMuon.Size = new System.Drawing.Size(726, 480);
            this.dgvSachMuon.TabIndex = 0;
            // 
            // toolSachMuon
            // 
            this.toolSachMuon.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolSachMuon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Xoa,
            this.btnLuu});
            this.toolSachMuon.Location = new System.Drawing.Point(3, 35);
            this.toolSachMuon.Name = "toolSachMuon";
            this.toolSachMuon.Size = new System.Drawing.Size(726, 37);
            this.toolSachMuon.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 32);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.txtSearchSach);
            this.rightPanel.Controls.Add(this.btnSearchSach);
            this.rightPanel.Controls.Add(this.dgvSach);
            this.rightPanel.Controls.Add(this.lblSachList);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(1114, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(449, 782);
            this.rightPanel.TabIndex = 2;
            // 
            // txtSearchSach
            // 
            this.txtSearchSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchSach.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSach.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchSach.Location = new System.Drawing.Point(90, 64);
            this.txtSearchSach.Name = "txtSearchSach";
            this.txtSearchSach.Size = new System.Drawing.Size(270, 37);
            this.txtSearchSach.TabIndex = 10;
            // 
            // btnSearchSach
            // 
            this.btnSearchSach.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSach.Image")));
            this.btnSearchSach.Location = new System.Drawing.Point(35, 65);
            this.btnSearchSach.Name = "btnSearchSach";
            this.btnSearchSach.Size = new System.Drawing.Size(42, 39);
            this.btnSearchSach.TabIndex = 9;
            this.btnSearchSach.UseVisualStyleBackColor = true;
            // 
            // dgvSach
            // 
            this.dgvSach.ColumnHeadersHeight = 34;
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(0, 158);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 62;
            this.dgvSach.Size = new System.Drawing.Size(449, 624);
            this.dgvSach.TabIndex = 0;
            // 
            // lblSachList
            // 
            this.lblSachList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSachList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSachList.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSachList.Location = new System.Drawing.Point(0, 0);
            this.lblSachList.Name = "lblSachList";
            this.lblSachList.Size = new System.Drawing.Size(449, 158);
            this.lblSachList.TabIndex = 1;
            this.lblSachList.Text = "Danh sách sách";
            // 
            // Xoa
            // 
            this.Xoa.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xoa.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Xoa.Image = ((System.Drawing.Image)(resources.GetObject("Xoa.Image")));
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(77, 32);
            this.Xoa.Text = "Xóa";
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // frmMuonSach
            // 
            this.ClientSize = new System.Drawing.Size(1566, 788);
            this.Controls.Add(this.mainLayout);
            this.Name = "frmMuonSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý mượn sách";
            this.Load += new System.EventHandler(this.frmMuonSach_Load);
            this.mainLayout.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.centerLayout.ResumeLayout(false);
            this.gbDocGia.ResumeLayout(false);
            this.gbDocGia.PerformLayout();
            this.gbSachMuon.ResumeLayout(false);
            this.gbSachMuon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachMuon)).EndInit();
            this.toolSachMuon.ResumeLayout(false);
            this.toolSachMuon.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDG;
        private System.Windows.Forms.Button btnSearchSach;
        private System.Windows.Forms.TextBox txtSearchDG;
        private System.Windows.Forms.TextBox txtSearchSach;
        private System.Windows.Forms.ToolStripButton Xoa;
    }
}
