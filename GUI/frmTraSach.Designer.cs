namespace GUI
{
    partial class frmTraSach
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblThongTin = new System.Windows.Forms.Label();
            this.btnTra = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Trả sách";
            // 
            // lblThongTin
            // 
            this.lblThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongTin.Location = new System.Drawing.Point(20, 80);
            this.lblThongTin.Name = "lblThongTin";
            this.lblThongTin.Size = new System.Drawing.Size(300, 60);
            this.lblThongTin.TabIndex = 1;
            this.lblThongTin.Text = "Thông tin sách sẽ hiển thị ở đây";
            // 
            // btnTra
            // 
            this.btnTra.Location = new System.Drawing.Point(25, 198);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(120, 35);
            this.btnTra.TabIndex = 2;
            this.btnTra.Text = "Xác nhận trả";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            // 
            // frmTraSach
            // 
            this.ClientSize = new System.Drawing.Size(433, 272);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblThongTin);
            this.Controls.Add(this.btnTra);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmTraSach";
            this.Text = "Trả sách";
            this.Load += new System.EventHandler(this.frmTraSach_Load_1);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblThongTin;
        private System.Windows.Forms.Button btnTra;
        private System.Windows.Forms.Button btnCancel;
    }
}
