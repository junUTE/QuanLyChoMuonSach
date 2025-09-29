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
    public partial class frmEdit : Form
    {
        private int _soPhieu;
        private ViewBLL viewCTP = new ViewBLL();
        private readonly FunctionBLL funcBll = new FunctionBLL();
        private readonly StoredProcedureBLL spBll = new StoredProcedureBLL();
        private bool _isCTChanged = false;
        public frmEdit(int soPhieu)
        {
            InitializeComponent();
            _soPhieu = soPhieu;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            LoadCTPhieuMuon();
            LoadThongTinPhieu();
            LoadSach();
            
            dateMuon.Format = DateTimePickerFormat.Custom;
            dateMuon.CustomFormat = "dd/MM/yyyy";
            dateHenTra.Format = DateTimePickerFormat.Custom;
            dateHenTra.CustomFormat = "dd/MM/yyyy";
            dateMuon.Enabled = false;

            dgvCTPhieuMuon.SelectionChanged += dgvCTPhieuMuon_SelectionChanged;
            if (dgvCTPhieuMuon.Rows.Count > 0)
            {
                dgvCTPhieuMuon.Rows[0].Selected = true;
                UpdateChiTietFromRow(dgvCTPhieuMuon.Rows[0]);
            }

            dgvSach.SelectionChanged += dgvSach_SelectionChanged;
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            int soPhieu = _soPhieu;
            string maNV = txtMaNhanVien.Text;
            DateTime ngayHenTra = dateHenTra.Value;

            // Validation ngay trên UI
            if (soPhieu <= 0)
            {
                MessageBox.Show("Số phiếu không hợp lệ!");
                return;
            }
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                return;
            }
            string error;
            bool ok = spBll.ChinhSuaPhieuMuon(soPhieu, maNV, ngayHenTra, out error);
            if (ok)
            {
                MessageBox.Show("Cập nhật phiếu mượn thành công");
                btnClose.Enabled = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Không thể cập nhật phiếu mượn: " + error);
            }

            }

        private void btnDoiSach_Click(object sender, EventArgs e)
        {
            string err;
            int maCuonSachCu = int.Parse(txtMaSachCu.Text);
            int maCuonSachMoi = int.Parse(txtMaSachMoi.Text);

            if (spBll.ChinhSuaCT(_soPhieu, maCuonSachCu, maCuonSachMoi, out err))
            {
                MessageBox.Show("Đổi sách thành công");
                LoadCTPhieuMuon();
                LoadSach();
                _isCTChanged = true; // Đánh dấu đã thay đổi
                btnClose.Enabled = false; // disable nút Close
            }
            else
            {
                MessageBox.Show("Không thể đổi sách: " + err);
            }
        }

        private void LoadCTPhieuMuon()
        {
            dgvCTPhieuMuon.DataSource = viewCTP.GetCTPhieuMuon(_soPhieu);
            if (dgvCTPhieuMuon.Columns["soPhieu"] != null)
            {
                dgvCTPhieuMuon.Columns["soPhieu"].HeaderText = "Số phiếu";
                dgvCTPhieuMuon.Columns["soPhieu"].FillWeight = 15;
            }
            if (dgvCTPhieuMuon.Columns["maCuonSach"] != null)
            {
                dgvCTPhieuMuon.Columns["maCuonSach"].HeaderText = "Mã sách";
                dgvCTPhieuMuon.Columns["maCuonSach"].FillWeight = 15;
            }
            if (dgvCTPhieuMuon.Columns["tenTuaSach"] != null)
            {
                dgvCTPhieuMuon.Columns["tenTuaSach"].HeaderText = "Tên tựa sách";
                dgvCTPhieuMuon.Columns["tenTuaSach"].FillWeight = 25;
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
            DesignDGV(dgvCTPhieuMuon);
        }
        private void LoadThongTinPhieu()
        {
            var tk = Session.CurrentUser;
            DataTable dt = funcBll.GetThongTinPhieu(_soPhieu);
            if (dt == null || dt.Rows.Count == 0)
                return;

            DataRow r = dt.Rows[0];

            // Gán dữ liệu vào các TextBox
            txtSoPhieu.Text = r["soPhieu"]?.ToString();
            txtMaDocGia.Text = r["maDocGia"]?.ToString();
            txtTenDocGia.Text = r["hoTen"]?.ToString();
            txtMaNhanVien.Text = r["maNhanVien"]?.ToString();
            txtNhanVienSuaPhieu.Text = funcBll.GetMaNhanVien(tk.maNguoi);

            if (r["ngayMuon"] != DBNull.Value)
                dateMuon.Value = Convert.ToDateTime(r["ngayMuon"]);
            if (r["ngayHenTra"] != DBNull.Value)
                dateHenTra.Value = Convert.ToDateTime(r["ngayHenTra"]);
        }
        private void dgvCTPhieuMuon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCTPhieuMuon.CurrentRow != null && !dgvCTPhieuMuon.CurrentRow.IsNewRow)
                UpdateChiTietFromRow(dgvCTPhieuMuon.CurrentRow);
        }

        private void UpdateChiTietFromRow(DataGridViewRow row)
        {
            txtMaSachCu.Text = row.Cells["maCuonSach"]?.Value?.ToString();
            txtTenSachCu.Text = row.Cells["tenTuaSach"]?.Value?.ToString();
        }

        private void LoadSach()
        {
            dgvSach.DataSource = funcBll.SachTheoTinhTrang("Có sẵn");

            // Thiết lập header và định dạng cột cụ thể
            if (dgvSach.Columns["maCuonSach"] != null)
            {
                dgvSach.Columns["maCuonSach"].HeaderText = "Mã sách";
                dgvSach.Columns["maCuonSach"].FillWeight = 18;
            }

            if (dgvSach.Columns["tenTuaSach"] != null)
            {
                dgvSach.Columns["tenTuaSach"].HeaderText = "Tên sách";
                dgvSach.Columns["tenTuaSach"].FillWeight = 42;
            }
            if (dgvSach.Columns["tacGia"] != null)
            {
                dgvSach.Columns["tacGia"].HeaderText = "Tác giả";
                dgvSach.Columns["tacGia"].FillWeight = 40;
            }
            DesignDGV(dgvSach);
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow != null && !dgvSach.CurrentRow.IsNewRow)
            {
                txtMaSachMoi.Text = dgvSach.CurrentRow.Cells["maCuonSach"].Value.ToString();
                txtTenSachMoi.Text = dgvSach.CurrentRow.Cells["tenTuaSach"].Value.ToString();
            }
        }
               
        private void btnSearchSach_Click(object sender, EventArgs e)
        {
            string tinhTrang = "Có sẵn"; // hoặc lấy từ ComboBox
            string keyword = txtSearchSach.Text.Trim();
            dgvSach.DataSource = funcBll.TimKiemSachTheoTinhTrang(tinhTrang, keyword);
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (dgvCTPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn chi tiết phiếu để xóa.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCuonSach = Convert.ToInt32(dgvCTPhieuMuon.CurrentRow.Cells["maCuonSach"].Value);
            string error;

            bool ok = spBll.XoaCT(_soPhieu, maCuonSach, out error);
            if (ok)
            {
                MessageBox.Show("Xóa chi tiết thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCTPhieuMuon();
                _isCTChanged = true; // Đánh dấu đã thay đổi
                btnClose.Enabled = false; // disable nút Close
            }
            else
            {
                MessageBox.Show("Không thể thêm chi tiết: " + error, "Lỗi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách để thêm.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maCuonSach = Convert.ToInt32(dgvSach.CurrentRow.Cells["maCuonSach"].Value);

            string error;
            bool ok = spBll.ThemCT(_soPhieu, maCuonSach, out error);

            if (ok)
            {
                MessageBox.Show("Thêm chi tiết thành công.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCTPhieuMuon();
                LoadSach();
                _isCTChanged = true; // Đánh dấu đã thay đổi
                btnClose.Enabled = false; // disable nút Close
            }
            else
            {
                MessageBox.Show("Không thể thêm chi tiết: " + error, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
