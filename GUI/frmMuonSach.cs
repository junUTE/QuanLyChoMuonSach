using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;

namespace GUI
{
    public partial class frmMuonSach : Form
    {
        private ViewBLL viewBll = new ViewBLL();
        private FunctionBLL Funcbll = new FunctionBLL();
        public frmMuonSach()
        {
            InitializeComponent();
        }
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            LoadDocGia();
            LoadSach();
            LoadMuonSach();

            txtMaDG.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            dtNgayMuon.Enabled = false;
            dtNgayMuon.Format = DateTimePickerFormat.Custom;
            dtNgayMuon.CustomFormat = "dd/MM/yyyy";

            dtNgayHenTra.Format = DateTimePickerFormat.Custom;
            dtNgayHenTra.CustomFormat = "dd/MM/yyyy";

            dgvDocGia.CellContentDoubleClick += dgvDocGia_CellDoubleClick;
            dgvSach.CellDoubleClick += dgvSach_CellDoubleClick;
        }

        private void LoadDocGia()
        {
            dgvDocGia.DataSource = viewBll.GetDocGiaThongTin();

            if (dgvDocGia.Columns["MaDocGia"] != null)
            {
                dgvDocGia.Columns["MaDocGia"].HeaderText = "Mã ĐG";
                dgvDocGia.Columns["MaDocGia"].FillWeight = 20;
            }
            if (dgvDocGia.Columns["hoTen"] != null)
            {
                dgvDocGia.Columns["hoTen"].HeaderText = "Họ tên";
                dgvDocGia.Columns["hoTen"].FillWeight = 45;
            }
            if (dgvDocGia.Columns["ngaySinh"] != null)
            {
                dgvDocGia.Columns["ngaySinh"].HeaderText = "Ngày sinh";
                dgvDocGia.Columns["ngaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDocGia.Columns["ngaySinh"].FillWeight = 35;
            }
            DesignDGV(dgvDocGia);
        }

        private void dgvDocGia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // đảm bảo không click vào header
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                // Gán sang controls thông tin độc giả
                txtMaDG.Text = row.Cells["maDocGia"].Value.ToString();
                txtHoTen.Text = row.Cells["hoTen"].Value.ToString();

                if (row.Cells["ngaySinh"].Value != DBNull.Value)
                {
                    dtNgayMuon.Value = DateTime.Now; // ngày mượn mặc định
                    dtNgayHenTra.Value = DateTime.Now.AddDays(7); // hạn trả mặc định
                                                                  // nếu muốn load ngày sinh riêng thì bạn có thể thêm dtpNgaySinh
                                                                  // DateTime dt = Convert.ToDateTime(row.Cells["ngaySinh"].Value);
                                                                  // dtpNgaySinh.Value = dt;
                }
            }
        }

        private void LoadSach()
        {
            FunctionBLL funcBll = new FunctionBLL();
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

        private void dgvSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];

                // Lấy dữ liệu sách
                string maSach = row.Cells["maCuonSach"].Value.ToString();
                string tenSach = row.Cells["tenTuaSach"].Value.ToString();
                string theLoai = row.Cells["tacGia"].Value.ToString();

                // Kiểm tra trùng (nếu đã có trong danh sách mượn)
                foreach (DataGridViewRow r in dgvSachMuon.Rows)
                {
                    if (r.Cells["maCuonSach"].Value != null && r.Cells["maCuonSach"].Value.ToString() == maSach)
                    {
                        MessageBox.Show("Sách này đã có trong danh sách mượn!");
                        return;
                    }
                }

                // Thêm vào dgvSachMuon
                int index = dgvSachMuon.Rows.Add();
                dgvSachMuon.Rows[index].Cells["maCuonSach"].Value = maSach;
                dgvSachMuon.Rows[index].Cells["tenTuaSach"].Value = tenSach;
                dgvSachMuon.Rows[index].Cells["tacGia"].Value = theLoai;
            }
        }

        private void LoadMuonSach()
        {
            dgvSachMuon.Columns.Add("maCuonSach", "Mã sách");
            dgvSachMuon.Columns.Add("tenTuaSach", "Tên sách");
            dgvSachMuon.Columns.Add("tacGia", "Thể loại");
            dgvSachMuon.Columns["maCuonSach"].FillWeight = 18;
            dgvSachMuon.Columns["tenTuaSach"].FillWeight = 42;
            dgvSachMuon.Columns["tacGia"].FillWeight = 40;
            DesignDGV(dgvSachMuon);
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
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // khi hover chọn dòng
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            //căn giữa
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


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
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if (dgvSachMuon.CurrentRow != null && !dgvSachMuon.CurrentRow.IsNewRow)
            {
                int rowIndex = dgvSachMuon.CurrentRow.Index;
                dgvSachMuon.Rows.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sách trong danh sách mượn để xóa.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    // 1. Kiểm tra dữ liệu
                    if (string.IsNullOrWhiteSpace(txtMaDG.Text))
                    {
                        MessageBox.Show("Vui lòng chọn độc giả trước khi lưu.");
                        return;
                    }
                    if (dgvSachMuon.Rows.Count == 0)
                    {
                        MessageBox.Show("Danh sách sách mượn trống.");
                        return;
                    }

                    var user = Session.CurrentUser;
                    FunctionBLL funcBll = new FunctionBLL();
                    string maDocGia = txtMaDG.Text.Trim();
                    string maNhanVien = funcBll.GetMaNhanVien(user.maNguoi); // giả sử bạn có biến global CurrentUser
                    DateTime ngayHenTra = dtNgayHenTra.Value.Date;

                    // 2. Tạo DataTable dsSach phù hợp với type dbo.SachMuon_Type
                    DataTable dsSach = new DataTable();
                    dsSach.Columns.Add("maCuonSach", typeof(int)); // vì type trong SQL là INT

                    foreach (DataGridViewRow row in dgvSachMuon.Rows)
                    {
                        if (row.IsNewRow) continue;
                        dsSach.Rows.Add(Convert.ToInt32(row.Cells["maCuonSach"].Value));
                    }

                    // 3. Gọi trực tiếp stored procedure
                    using (SqlConnection conn = new SqlConnection(Session.ConnStr))
                    using (SqlCommand cmd = new SqlCommand("sp_MuonSach", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@maDocGia", maDocGia);
                        cmd.Parameters.AddWithValue("@maNhanVien", maNhanVien);
                        cmd.Parameters.Add("@ngayHenTra", SqlDbType.Date).Value = ngayHenTra;

                        var p4 = cmd.Parameters.AddWithValue("@dsSach", dsSach);
                        p4.SqlDbType = SqlDbType.Structured;
                        p4.TypeName = "dbo.SachMuon_Type";

                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // 4. Kết quả
                        if (dt.Rows.Count > 0)
                        {
                            int soPhieuMoi = Convert.ToInt32(dt.Rows[0]["SoPhieuMoi"]);
                            MessageBox.Show($"Lưu thành công! Số phiếu mới: {soPhieuMoi}");
                            dgvSachMuon.Rows.Clear();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Không lưu được phiếu mượn.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            finally
            {
                // Dù thành công hay lỗi thì vẫn load lại danh sách sách có sẵn
                LoadSach();
            }  
        }

        private void btnSearchSach_Click(object sender, EventArgs e)
        {
            string tinhTrang = "Có sẵn"; // hoặc lấy từ ComboBox
            string keyword = txtSearchSach.Text.Trim();
            dgvSach.DataSource = Funcbll.TimKiemSachTheoTinhTrang(tinhTrang, keyword);
        }

        private void btnSearchDG_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchDG.Text.Trim();
            dgvDocGia.DataSource = Funcbll.TimKiemDocGia(keyword);
        }
    }
}
