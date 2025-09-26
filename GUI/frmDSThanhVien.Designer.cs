namespace GUI
{
    partial class frmDSThanhVien
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
            this.dgvDsThanhVien = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsThanhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDsThanhVien
            // 
            this.dgvDsThanhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDsThanhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDsThanhVien.Location = new System.Drawing.Point(0, 0);
            this.dgvDsThanhVien.Name = "dgvDsThanhVien";
            this.dgvDsThanhVien.RowHeadersWidth = 62;
            this.dgvDsThanhVien.RowTemplate.Height = 28;
            this.dgvDsThanhVien.Size = new System.Drawing.Size(1416, 754);
            this.dgvDsThanhVien.TabIndex = 0;
            // 
            // frmDSThanhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 754);
            this.Controls.Add(this.dgvDsThanhVien);
            this.Name = "frmDSThanhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Thành Viên";
            this.Load += new System.EventHandler(this.frmDSThanhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsThanhVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDsThanhVien;
    }
}