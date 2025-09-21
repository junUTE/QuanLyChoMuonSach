namespace GUI
{
    partial class frmEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEdit));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();
            this.lblMaDG = new System.Windows.Forms.Label();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.lblTenDG = new System.Windows.Forms.Label();
            this.txtTenDocGia = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lblNgayHenTra = new System.Windows.Forms.Label();
            this.dtpNgayHenTra = new System.Windows.Forms.DateTimePicker();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCTPhieuMuon = new System.Windows.Forms.DataGridView();
            this.btnXoaCT = new System.Windows.Forms.Button();
            this.dgvSachCoSan = new System.Windows.Forms.DataGridView();
            this.btnThemCT = new System.Windows.Forms.Button();
            this.lblMaSachCu = new System.Windows.Forms.Label();
            this.txtMaSachCu = new System.Windows.Forms.TextBox();
            this.lblMaSachMoi = new System.Windows.Forms.Label();
            this.txtMaSachMoi = new System.Windows.Forms.TextBox();
            this.btnDoiSach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPhieuMuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCoSan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(20, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chỉnh sửa Phiếu mượn";
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhieu.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSoPhieu.Location = new System.Drawing.Point(31, 82);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(118, 31);
            this.lblSoPhieu.TabIndex = 1;
            this.lblSoPhieu.Text = "Số phiếu:";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhieu.Location = new System.Drawing.Point(155, 79);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(118, 34);
            this.txtSoPhieu.TabIndex = 2;
            // 
            // lblMaDG
            // 
            this.lblMaDG.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaDG.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMaDG.Location = new System.Drawing.Point(33, 119);
            this.lblMaDG.Name = "lblMaDG";
            this.lblMaDG.Size = new System.Drawing.Size(118, 31);
            this.lblMaDG.TabIndex = 3;
            this.lblMaDG.Text = "Mã ĐG:";
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDocGia.Location = new System.Drawing.Point(155, 119);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.ReadOnly = true;
            this.txtMaDocGia.Size = new System.Drawing.Size(118, 34);
            this.txtMaDocGia.TabIndex = 4;
            // 
            // lblTenDG
            // 
            this.lblTenDG.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDG.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTenDG.Location = new System.Drawing.Point(31, 159);
            this.lblTenDG.Name = "lblTenDG";
            this.lblTenDG.Size = new System.Drawing.Size(118, 31);
            this.lblTenDG.TabIndex = 5;
            this.lblTenDG.Text = "Tên ĐG:";
            // 
            // txtTenDocGia
            // 
            this.txtTenDocGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDocGia.Location = new System.Drawing.Point(155, 159);
            this.txtTenDocGia.Name = "txtTenDocGia";
            this.txtTenDocGia.ReadOnly = true;
            this.txtTenDocGia.Size = new System.Drawing.Size(218, 34);
            this.txtTenDocGia.TabIndex = 6;
            // 
            // lblMaNV
            // 
            this.lblMaNV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMaNV.Location = new System.Drawing.Point(393, 85);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(88, 31);
            this.lblMaNV.TabIndex = 7;
            this.lblMaNV.Text = "Mã NV:";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhanVien.Location = new System.Drawing.Point(542, 82);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(138, 34);
            this.txtMaNhanVien.TabIndex = 8;
            // 
            // lblNgayHenTra
            // 
            this.lblNgayHenTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayHenTra.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNgayHenTra.Location = new System.Drawing.Point(393, 135);
            this.lblNgayHenTra.Name = "lblNgayHenTra";
            this.lblNgayHenTra.Size = new System.Drawing.Size(143, 31);
            this.lblNgayHenTra.TabIndex = 9;
            this.lblNgayHenTra.Text = "Ngày hẹn trả:";
            // 
            // dtpNgayHenTra
            // 
            this.dtpNgayHenTra.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHenTra.Location = new System.Drawing.Point(542, 132);
            this.dtpNgayHenTra.Name = "dtpNgayHenTra";
            this.dtpNgayHenTra.Size = new System.Drawing.Size(172, 34);
            this.dtpNgayHenTra.TabIndex = 10;
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuPhieu.Image")));
            this.btnLuuPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuPhieu.Location = new System.Drawing.Point(818, 48);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(151, 43);
            this.btnLuuPhieu.TabIndex = 11;
            this.btnLuuPhieu.Text = "     Lưu phiếu";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(20, 262);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCTPhieuMuon);
            this.splitContainer1.Panel1.Controls.Add(this.btnXoaCT);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSachCoSan);
            this.splitContainer1.Panel2.Controls.Add(this.btnThemCT);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 400);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 12;
            // 
            // dgvCTPhieuMuon
            // 
            this.dgvCTPhieuMuon.ColumnHeadersHeight = 34;
            this.dgvCTPhieuMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTPhieuMuon.Location = new System.Drawing.Point(0, 0);
            this.dgvCTPhieuMuon.Name = "dgvCTPhieuMuon";
            this.dgvCTPhieuMuon.RowHeadersWidth = 62;
            this.dgvCTPhieuMuon.Size = new System.Drawing.Size(500, 362);
            this.dgvCTPhieuMuon.TabIndex = 0;
            // 
            // btnXoaCT
            // 
            this.btnXoaCT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXoaCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCT.ForeColor = System.Drawing.Color.Red;
            this.btnXoaCT.Location = new System.Drawing.Point(0, 362);
            this.btnXoaCT.Name = "btnXoaCT";
            this.btnXoaCT.Size = new System.Drawing.Size(500, 38);
            this.btnXoaCT.TabIndex = 1;
            this.btnXoaCT.Text = "Xóa sách mượn";
            // 
            // dgvSachCoSan
            // 
            this.dgvSachCoSan.ColumnHeadersHeight = 34;
            this.dgvSachCoSan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSachCoSan.Location = new System.Drawing.Point(0, 0);
            this.dgvSachCoSan.Name = "dgvSachCoSan";
            this.dgvSachCoSan.RowHeadersWidth = 62;
            this.dgvSachCoSan.Size = new System.Drawing.Size(496, 362);
            this.dgvSachCoSan.TabIndex = 0;
            // 
            // btnThemCT
            // 
            this.btnThemCT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThemCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCT.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnThemCT.Location = new System.Drawing.Point(0, 362);
            this.btnThemCT.Name = "btnThemCT";
            this.btnThemCT.Size = new System.Drawing.Size(496, 38);
            this.btnThemCT.TabIndex = 1;
            this.btnThemCT.Text = "Mượn thêm sách";
            // 
            // lblMaSachCu
            // 
            this.lblMaSachCu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSachCu.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMaSachCu.Location = new System.Drawing.Point(21, 221);
            this.lblMaSachCu.Name = "lblMaSachCu";
            this.lblMaSachCu.Size = new System.Drawing.Size(118, 31);
            this.lblMaSachCu.TabIndex = 13;
            this.lblMaSachCu.Text = "Mã sách cũ:";
            // 
            // txtMaSachCu
            // 
            this.txtMaSachCu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSachCu.Location = new System.Drawing.Point(145, 221);
            this.txtMaSachCu.Name = "txtMaSachCu";
            this.txtMaSachCu.ReadOnly = true;
            this.txtMaSachCu.Size = new System.Drawing.Size(118, 34);
            this.txtMaSachCu.TabIndex = 14;
            // 
            // lblMaSachMoi
            // 
            this.lblMaSachMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSachMoi.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblMaSachMoi.Location = new System.Drawing.Point(489, 216);
            this.lblMaSachMoi.Name = "lblMaSachMoi";
            this.lblMaSachMoi.Size = new System.Drawing.Size(147, 31);
            this.lblMaSachMoi.TabIndex = 15;
            this.lblMaSachMoi.Text = "Mã sách mới:";
            // 
            // txtMaSachMoi
            // 
            this.txtMaSachMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSachMoi.Location = new System.Drawing.Point(642, 213);
            this.txtMaSachMoi.Name = "txtMaSachMoi";
            this.txtMaSachMoi.Size = new System.Drawing.Size(118, 34);
            this.txtMaSachMoi.TabIndex = 16;
            // 
            // btnDoiSach
            // 
            this.btnDoiSach.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiSach.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiSach.Image")));
            this.btnDoiSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiSach.Location = new System.Drawing.Point(818, 209);
            this.btnDoiSach.Name = "btnDoiSach";
            this.btnDoiSach.Size = new System.Drawing.Size(151, 43);
            this.btnDoiSach.TabIndex = 17;
            this.btnDoiSach.Text = "     Chỉnh sửa";
            // 
            // frmEdit
            // 
            this.ClientSize = new System.Drawing.Size(1046, 691);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSoPhieu);
            this.Controls.Add(this.txtSoPhieu);
            this.Controls.Add(this.lblMaDG);
            this.Controls.Add(this.txtMaDocGia);
            this.Controls.Add(this.lblTenDG);
            this.Controls.Add(this.txtTenDocGia);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.lblNgayHenTra);
            this.Controls.Add(this.dtpNgayHenTra);
            this.Controls.Add(this.btnLuuPhieu);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblMaSachCu);
            this.Controls.Add(this.txtMaSachCu);
            this.Controls.Add(this.lblMaSachMoi);
            this.Controls.Add(this.txtMaSachMoi);
            this.Controls.Add(this.btnDoiSach);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "frmEdit";
            this.Text = "Chỉnh sửa Phiếu mượn";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPhieuMuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCoSan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblMaDG;
        private System.Windows.Forms.TextBox txtMaDocGia;
        private System.Windows.Forms.Label lblTenDG;
        private System.Windows.Forms.TextBox txtTenDocGia;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Label lblNgayHenTra;
        private System.Windows.Forms.DateTimePicker dtpNgayHenTra;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCTPhieuMuon;
        private System.Windows.Forms.Button btnXoaCT;
        private System.Windows.Forms.DataGridView dgvSachCoSan;
        private System.Windows.Forms.Button btnThemCT;
        private System.Windows.Forms.Label lblMaSachCu;
        private System.Windows.Forms.TextBox txtMaSachCu;
        private System.Windows.Forms.Label lblMaSachMoi;
        private System.Windows.Forms.TextBox txtMaSachMoi;
        private System.Windows.Forms.Button btnDoiSach;
    }
}
