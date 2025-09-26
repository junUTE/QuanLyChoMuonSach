using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace GUI
{
    public partial class frmDSThanhVien : Form
    {
        public readonly StoredProcedureBLL _bll = new StoredProcedureBLL();
        public frmDSThanhVien()
        {
            InitializeComponent();
        }

        private void frmDSThanhVien_Load(object sender, EventArgs e)
        {
            dgvDsThanhVien.DataSource = _bll.XemDSThanhVien();
            DesignDGV(dgvDsThanhVien);
        }
        private void DesignDGV(DataGridView dgv)
        {
            // ===== Tổng thể =====
            dgv.BackgroundColor = Color.FromArgb(248, 249, 250); // nền trắng cùng màu form
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // ===== Header =====
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray; // xám nhạt
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // ===== Cell =====
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // khi hover chọn dòng
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // ===== Row =====
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // ===== Hiệu ứng hover =====
            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.AliceBlue;
            };
            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            };

            //căn giữa
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thiết lập header và định dạng cột cụ thể
            if (dgv.Columns["maNguoi"] != null)
            {
                dgv.Columns["maNguoi"].HeaderText = "Mã người";
                dgv.Columns["maNguoi"].FillWeight = 8;
            }

            if (dgv.Columns["hoTen"] != null)
            {
                dgv.Columns["hoTen"].HeaderText = "Họ tên";
                dgv.Columns["hoTen"].FillWeight = 20;
            }

            if (dgv.Columns["gioiTinh"] != null)
            {
                dgv.Columns["gioiTinh"].HeaderText = "Giới tính";
                dgv.Columns["gioiTinh"].FillWeight = 10;
            }

            if (dgv.Columns["ngaySinh"] != null)
            {
                dgv.Columns["ngaySinh"].HeaderText = "Ngày sinh";
                dgv.Columns["ngaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["ngaySinh"].FillWeight = 12;
            }

            if (dgv.Columns["diaChi"] != null)
            {
                dgv.Columns["diaChi"].HeaderText = "Địa chỉ";
                dgv.Columns["diaChi"].FillWeight = 25;
            }

            if (dgv.Columns["SDT"] != null)
            {
                dgv.Columns["SDT"].HeaderText = "SĐT";
                dgv.Columns["SDT"].FillWeight = 12;
            }

            if (dgv.Columns["email"] != null)
            {
                dgv.Columns["email"].HeaderText = "Email";
                dgv.Columns["email"].FillWeight = 20;
            }

            if (dgv.Columns["cccd"] != null)
            {
                dgv.Columns["cccd"].HeaderText = "CCCD";
                dgv.Columns["cccd"].FillWeight = 15;
            }

            if (dgv.Columns["vaiTro"] != null)
            {
                dgv.Columns["vaiTro"].HeaderText = "Vai trò";
                dgv.Columns["vaiTro"].FillWeight = 8;
            }
        }

    }
}
