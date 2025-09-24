using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace GUI
{
    public partial class frmTraSach : Form
    {
        private int _soPhieu;
        private ViewBLL viewCTP = new ViewBLL();
        private readonly FunctionBLL funcBll = new FunctionBLL();
        private readonly StoredProcedureBLL spBll = new StoredProcedureBLL();

        public frmTraSach(int soPhieu) // Corrected parameter name  
        {
            InitializeComponent();
            _soPhieu = soPhieu; // Fixed assignment  
        }

        private void frmTraSach_Load_2(object sender, EventArgs e)
        {
            LoadCTPhieuMuon();
            LoadThongTinPhieu();
            DesignDGV(dgvCTPhieuMuon);
            dateMuon.Format = DateTimePickerFormat.Custom;
            dateMuon.CustomFormat = "dd/MM/yyyy";
            dateTra.Format = DateTimePickerFormat.Custom;
            dateTra.CustomFormat = "dd/MM/yyyy";
            dateMuon.Enabled = false;
            dateTra.Enabled = false;

            dgvCTPhieuMuon.SelectionChanged += dgvCTPhieuMuon_SelectionChanged;
            if (dgvCTPhieuMuon.Rows.Count > 0)
            {
                dgvCTPhieuMuon.Rows[0].Selected = true;
                UpdateChiTietFromRow(dgvCTPhieuMuon.Rows[0]);
            }

        }

        private void LoadCTPhieuMuon()
        {
            dgvCTPhieuMuon.DataSource = viewCTP.GetCTPhieuMuon(_soPhieu);
            if (dgvCTPhieuMuon.Columns["soPhieu"] != null)
            {
                dgvCTPhieuMuon.Columns["soPhieu"].HeaderText = "Số phiếu";
                dgvCTPhieuMuon.Columns["soPhieu"].FillWeight = 12;
            }
            if (dgvCTPhieuMuon.Columns["maCuonSach"] != null)
            {
                dgvCTPhieuMuon.Columns["maCuonSach"].HeaderText = "Mã sách";
                dgvCTPhieuMuon.Columns["maCuonSach"].FillWeight = 13;
            }
            if (dgvCTPhieuMuon.Columns["tenTuaSach"] != null)
            {
                dgvCTPhieuMuon.Columns["tenTuaSach"].HeaderText = "Tên tựa sách";
                dgvCTPhieuMuon.Columns["tenTuaSach"].FillWeight = 30;
            }
            if (dgvCTPhieuMuon.Columns["tacGia"] != null)
            {
                dgvCTPhieuMuon.Columns["tacGia"].HeaderText = "Tác giả";
                dgvCTPhieuMuon.Columns["tacGia"].FillWeight = 25;
            }
            if (dgvCTPhieuMuon.Columns["trangThai"] != null)
            {
                dgvCTPhieuMuon.Columns["trangThai"].HeaderText = "Trạng thái";
                dgvCTPhieuMuon.Columns["trangThai"].FillWeight = 20;
            }
        }
        private void LoadThongTinPhieu()
        {
            DataTable dt = funcBll.GetThongTinPhieu(_soPhieu);
            if (dt == null || dt.Rows.Count == 0)
                return;

            DataRow r = dt.Rows[0];

            // Gán dữ liệu vào các TextBox
            txtMaDG.Text = r["maDocGia"]?.ToString();
            txtHoTen.Text = r["hoTen"]?.ToString();
            txtMaNV.Text = r["maNhanVien"]?.ToString();

            if (r["ngayMuon"] != DBNull.Value)
                dateMuon.Value = Convert.ToDateTime(r["ngayMuon"]);
                dateTra.Value = DateTime.Now;
        }
        private void dgvCTPhieuMuon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCTPhieuMuon.CurrentRow != null && !dgvCTPhieuMuon.CurrentRow.IsNewRow)
                UpdateChiTietFromRow(dgvCTPhieuMuon.CurrentRow);
        }

        private void UpdateChiTietFromRow(DataGridViewRow row)
        {
            txtMaSach.Text = row.Cells["maCuonSach"]?.Value?.ToString();
            txtTenSach.Text = row.Cells["tenTuaSach"]?.Value?.ToString();
            txtTacGia.Text = row.Cells["tacGia"]?.Value?.ToString();
            txtGhiChu.Text = row.Cells["trangThai"]?.Value?.ToString();
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
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvCTPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sách trong chi tiết phiếu.");
                return;
            }

            int soPhieu = _soPhieu;
            int maCuonSach = Convert.ToInt32(dgvCTPhieuMuon.CurrentRow.Cells["maCuonSach"].Value);

            // Lấy trạng thái mới từ combo box
            string tinhTrangMoi = string.IsNullOrWhiteSpace(cbbTinhTrangMoi.Text)
                                  ? null
                                  : cbbTinhTrangMoi.Text;

            string err;
            bool ok = spBll.TraTungSach(soPhieu, maCuonSach, tinhTrangMoi, out err);

            if (ok)
            {
                MessageBox.Show("Trả sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCTPhieuMuon(); // reload dgv
            }
            else
            {
                MessageBox.Show("Không thể trả sách. " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
