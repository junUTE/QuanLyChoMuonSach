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
    public partial class frmCTPhieu : Form
    {
        private StoredProcedureBLL spBLL = new StoredProcedureBLL();
        private int soPhieu;
        public frmCTPhieu(int _soPhieu)
        {
            InitializeComponent();
            soPhieu = _soPhieu;
        }

        private void CTPhieu_Load(object sender, EventArgs e)
        {
            string errorMessage;
            dgvChiTietPhieu.DataSource = spBLL.XemDsChiTietPhieuMuon(soPhieu, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DesignDGV(dgvChiTietPhieu);
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
            if (dgv.Columns["soPhieu"] != null)
            {
                dgv.Columns["soPhieu"].HeaderText = "Số phiếu";
                dgv.Columns["soPhieu"].FillWeight = 7;
            }

            if (dgv.Columns["maCuonSach"] != null)
            {
                dgv.Columns["maCuonSach"].HeaderText = "Mã Sách";
                dgv.Columns["maCuonSach"].FillWeight = 7;
            }

            if (dgv.Columns["ngayMuon"] != null)
            {
                dgv.Columns["ngayMuon"].HeaderText = "Ngày mượn";
                dgv.Columns["ngayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["ngayMuon"].FillWeight = 15;
            }
            if (dgv.Columns["ngayHenTra"] != null)
            {
                dgv.Columns["ngayHenTra"].HeaderText = "Ngày hẹn trả";
                dgv.Columns["ngayHenTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["ngayHenTra"].FillWeight = 15;
            }    
            if (dgv.Columns["ngayTra"] != null)
            {
                dgv.Columns["ngayTra"].HeaderText = "Ngày trả";
                dgv.Columns["ngayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["ngayTra"].FillWeight = 15;
            }
            if (dgv.Columns["trangThai"] != null)
            {
                dgv.Columns["trangThai"].HeaderText = "Trạng thái";
                dgv.Columns["trangThai"].FillWeight = 12;
            }
            if (dgv.Columns["soNgayTre"] != null)
            {
                dgv.Columns["soNgayTre"].HeaderText = "Số ngày trễ";
                dgv.Columns["soNgayTre"].FillWeight = 10;
            }
            if (dgv.Columns["ghiChu"] != null)
            {
                dgv.Columns["ghiChu"].HeaderText = "Ghi chú";
                dgv.Columns["ghiChu"].FillWeight = 30;
            }

        }
    }
}
