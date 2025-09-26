using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;


namespace GUI
{
    public partial class frm_Main : Form
    {

        private ViewBLL dal = new ViewBLL();
        private StoredProcedureBLL _spBll = new StoredProcedureBLL();
        private FunctionBLL _funcBll = new FunctionBLL();
        public frm_Main()
        {

            InitializeComponent();
            PanelInfoCard_Load();
            ShowDashboard(panelAccount);

        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            DesignDGV(dgvPhieuMuon);
            LoadComboBoxTacGia();
            LoadComboBoxTheLoai();
        }
        private void ShowDashboard(Panel dashboardPanel)
        {
            // Hide all dashboard panels
            panelBookManager.Visible = false;
            panelSearch.Visible = false;
            panelCreateAcc.Visible = false;
            panelStatic.Visible = false;
            panelAccount.Visible = false;

            dashboardPanel.Visible = true;

        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            PanelInfoCard_Load();
            ShowDashboard(panelAccount);
        }

        private void btnBookManager_Click(object sender, EventArgs e)
        {
            var tk = Session.CurrentUser;
            if (tk != null && tk.vaiTro == "guest")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PanelBookManager_Load();
            ShowDashboard(panelBookManager);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDanhSachCuonSach();
            ShowDashboard(panelSearch);
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            var tk = Session.CurrentUser;
            if (tk != null && tk.vaiTro == "guest")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PanelTaiKhoan_Load();
            ShowDashboard(panelCreateAcc);
        }

        private void btnStatic_Click(object sender, EventArgs e)
        {
            var tk = Session.CurrentUser;
            if (tk != null && tk.vaiTro == "guest")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtDenNgay.Value = DateTime.Now;
            dtTuNgay.Value = DateTime.Now.AddMonths(-1);
            //định dạng dateTimePicker
            dtTuNgay.Format = DateTimePickerFormat.Custom;
            dtTuNgay.CustomFormat = "dd/MM/yyyy";
            dtDenNgay.Format = DateTimePickerFormat.Custom;
            dtDenNgay.CustomFormat = "dd/MM/yyyy";
            ShowDashboard(panelStatic);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoadData.SetConnectionString("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True;TrustServerCertificate=True");
            this.Close();
        }
        private void PanelInfoCard_Load()
        {
            // Đổ dữ liệu thông tin cá nhân
            var tk = Session.CurrentUser;
            if (tk == null) return;

            lblId.Text = tk.maNguoi;
            lblHoTen.Text = tk.hoTen;
            lblEmail.Text =tk.email;
            lblGioiTinh.Text = tk.gioiTinh;
            lblSDT.Text =tk.SDT;
            lblCCCD.Text =tk.cccd;
            lblDiaChi.Text =tk.diaChi;
            lblNgaySinh.Text =(tk.ngaySinh.HasValue ? tk.ngaySinh.Value.ToString("dd/MM/yyyy") : "");
            lblChucVu.Text =tk.vaiTro;
            if (tk.vaiTro == "admin")
            {
                lbl_role.Text = "Vai trò: Quản trị viên";
            }
            else if (tk.vaiTro == "staff")
            {
                lbl_role.Text = "Vai trò: Nhân viên";
            }
            else
            {
                lbl_role.Text = "Vai trò: Độc giả";
            }
            grDoiMatKhau.Enabled = false;
        }
        
        private void PanelBookManager_Load()
        {
            var viewBLL = new ViewBLL();
            dgvPhieuMuon.DataSource = viewBLL.GetPhieuMuon();
            DesignDGV(dgvPhieuMuon);
        }

        private void PanelTaiKhoan_Load()
        {
            // Đổ dữ liệu tài khoản
            dgvTaiKhoan.DataSource = _spBll.DsTaiKhoan();
            if (dgvTaiKhoan.Columns["maNguoi"] != null)
            {
                dgvTaiKhoan.Columns["maNguoi"].HeaderText = "Mã người";
                dgvTaiKhoan.Columns["maNguoi"].FillWeight = 10;
            }
            if (dgvTaiKhoan.Columns["userName"] != null)
            {
                dgvTaiKhoan.Columns["userName"].HeaderText = "Tên đăng nhập";
                dgvTaiKhoan.Columns["userName"].FillWeight = 20;
            }
            if (dgvTaiKhoan.Columns["hoTen"] != null)
            {
                dgvTaiKhoan.Columns["hoTen"].HeaderText = "Họ tên";
                dgvTaiKhoan.Columns["hoTen"].FillWeight = 25;
            }
            if (dgvTaiKhoan.Columns["vaiTro"] != null)
            {
                dgvTaiKhoan.Columns["vaiTro"].HeaderText = "Vai trò";
                dgvTaiKhoan.Columns["vaiTro"].FillWeight = 15;
            }
            if (dgvTaiKhoan.Columns["hanTaiKhoan"] != null)
            {
                dgvTaiKhoan.Columns["hanTaiKhoan"].HeaderText = "Hạn TK";
                dgvTaiKhoan.Columns["hanTaiKhoan"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvTaiKhoan.Columns["hanTaiKhoan"].FillWeight = 15;
            }
            if (dgvTaiKhoan.Columns["SDT"] != null)
                dgvTaiKhoan.Columns["SDT"].FillWeight = 15;
            if (dgvTaiKhoan.Columns["email"] != null)
                dgvTaiKhoan.Columns["email"].FillWeight = 20;

            DesignDGV(dgvTaiKhoan);
        }

        private void LoadThongKe()
        {
            try
            {
                // Lấy ngày từ DateTimePicker
                DateTime tuNgay = dtTuNgay.Value.Date;
                DateTime denNgay = dtDenNgay.Value.Date;

                // Khởi tạo BLL
                var bll = new FunctionBLL();

                // ================== Phiếu mượn ==================
                txtPMDangMuon.Text = bll.GetSoPhieuDangMuon(tuNgay, denNgay).ToString();
                txtPMDaTra.Text = bll.GetSoPhieuDaTra(tuNgay, denNgay).ToString();
                txtPMTreHan.Text = bll.GetSoPhieuTreHan(tuNgay, denNgay).ToString();
                txtTongPhieu.Text = bll.GetTongPhieu(tuNgay, denNgay).ToString();

                // ================== Sách ==================
                txtSachDangMuon.Text = bll.GetSoSachDangMuon(tuNgay, denNgay).ToString();
                txtSachBiHong.Text = bll.GetSoSachHong(tuNgay, denNgay).ToString();
                txtSachBiMat.Text = bll.GetSoSachMat(tuNgay, denNgay).ToString();
                txtTongSach.Text = bll.GetTongSach().ToString();

                // ================== Độc giả ==================
                txtDGDangMuon.Text = bll.GetSoDocGiaDangMuon(tuNgay, denNgay).ToString();
                txtDGViPham.Text = bll.GetSoDocGiaViPham(tuNgay, denNgay).ToString();
                txtTongDG.Text = bll.GetTongDocGia().ToString();

                bll.DanhSachPhieuQuaHan();
                dgvPhieuQuaHan.DataSource = bll.GetDanhSachPhieuQuaHan(tuNgay,denNgay);
                if (dgvPhieuQuaHan.Columns["soPhieu"] != null)
                {
                    dgvPhieuQuaHan.Columns["soPhieu"].HeaderText = "Số phiếu";
                    dgvPhieuQuaHan.Columns["soPhieu"].FillWeight = 8;
                }
                if (dgvPhieuQuaHan.Columns["MaDocGia"] != null)
                {
                    dgvPhieuQuaHan.Columns["MaDocGia"].HeaderText = "Mã ĐG";
                    dgvPhieuQuaHan.Columns["MaDocGia"].FillWeight = 8;
                }
                if (dgvPhieuQuaHan.Columns["hoTen"] != null)
                {
                    dgvPhieuQuaHan.Columns["hoTen"].HeaderText = "Họ tên";
                    dgvPhieuQuaHan.Columns["hoTen"].FillWeight = 11;
                }
                if (dgvPhieuQuaHan.Columns["ngayMuon"] != null)
                {
                    dgvPhieuQuaHan.Columns["ngayMuon"].HeaderText = "Ngày mượn";
                    dgvPhieuQuaHan.Columns["ngayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvPhieuQuaHan.Columns["ngayMuon"].FillWeight = 18;
                }
                if (dgvPhieuQuaHan.Columns["ngayHenTra"] != null)
                {
                    dgvPhieuQuaHan.Columns["ngayHenTra"].HeaderText = "Ngày hẹn trả";
                    dgvPhieuQuaHan.Columns["ngayHenTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvPhieuQuaHan.Columns["ngayHenTra"].FillWeight = 18;
                }
                if (dgvPhieuQuaHan.Columns["soNgayTre"] != null)
                {
                    dgvPhieuQuaHan.Columns["soNgayTre"].HeaderText = "Số ngày trễ";
                    dgvPhieuQuaHan.Columns["soNgayTre"].FillWeight = 8;
                }
                DesignDGV(dgvPhieuQuaHan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load thống kê: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Thiết lập header và định dạng cột cụ thể
            if (dgv.Columns["soPhieu"] != null)
            {
                dgv.Columns["soPhieu"].HeaderText = "Số phiếu";
                dgv.Columns["soPhieu"].FillWeight = 7; 
            }

            if (dgv.Columns["MaDocGia"] != null)
            {
                dgv.Columns["MaDocGia"].HeaderText = "Mã ĐG";
                dgv.Columns["MaDocGia"].FillWeight = 10; 
            }

            if (dgv.Columns["hoTen"] != null)
            {
                dgv.Columns["hoTen"].HeaderText = "Họ tên";
                dgv.Columns["hoTen"].FillWeight = 20; 
            }
            if (dgv.Columns["SDT"] != null)
                dgv.Columns["SDT"].FillWeight = 13;
            if (dgv.Columns["NgayMuon"] != null)
            {
                dgv.Columns["NgayMuon"].HeaderText = "Ngày mượn";
                dgv.Columns["NgayMuon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["NgayMuon"].FillWeight = 11;
            }

            if (dgv.Columns["NgayHenTra"] != null)
            {
                dgv.Columns["NgayHenTra"].HeaderText = "Ngày hẹn trả";
                dgv.Columns["NgayHenTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["NgayHenTra"].FillWeight = 11;
            }

            if (dgv.Columns["ngayTra"] != null)
            {
                dgv.Columns["ngayTra"].HeaderText = "Ngày trả";
                dgv.Columns["ngayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv.Columns["ngayTra"].FillWeight = 11;
            }

            if (dgv.Columns["TrangThai"] != null)
            {
                dgv.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgv.Columns["TrangThai"].FillWeight = 12;
            }
        }



        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn.");
                return;
            }

            int soPhieu = Convert.ToInt32(dgvPhieuMuon.CurrentRow.Cells["soPhieu"].Value);
            string trangThai = dgvPhieuMuon.CurrentRow.Cells["trangThai"].Value?.ToString();

            // Kiểm tra trạng thái
            if (trangThai == "Đã trả")
            {
                MessageBox.Show("Phiếu này đã trả xong, không thể hủy.");
                return;
            }
            else if (trangThai == "Đã hủy")
            {
                MessageBox.Show("Phiếu này đã được hủy trước đó.");
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn hủy phiếu số {soPhieu}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                bool result = _spBll.HuyPhieu(soPhieu);

                if (result)
                {
                    MessageBox.Show("Hủy phiếu thành công.");
                    PanelBookManager_Load(); // reload lại danh sách
                }
                else
                {
                    MessageBox.Show("Không thể hủy phiếu. Vui lòng kiểm tra lại.");
                }
            }
        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn.");
                return;
            }
            string trangThai = dgvPhieuMuon.CurrentRow.Cells["trangThai"].Value.ToString();

            if (trangThai == "Đã trả" || trangThai == "Quá hạn")
            {
                MessageBox.Show("Phiếu này đã hoàn tất. Không thể trả thêm sách.");
                return;
            }

            // Lấy maPhieu từ dòng hiện tại
            int soPhieu = Convert.ToInt32(dgvPhieuMuon.CurrentRow.Cells["soPhieu"].Value);

            using (frmEdit f = new frmEdit(soPhieu)) // truyền maPhieu vào form Trả sách
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PanelBookManager_Load(); // reload lại
                }
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn.");
                return;
            }
            string trangThai = dgvPhieuMuon.CurrentRow.Cells["trangThai"].Value.ToString();

            if (trangThai == "Đã trả" || trangThai == "Đã hủy")
            {
                MessageBox.Show("Phiếu này đã hoàn tất. Không thể trả thêm sách.");
                return;
            }

            // Lấy maPhieu từ dòng hiện tại
            int soPhieu = Convert.ToInt32(dgvPhieuMuon.CurrentRow.Cells["soPhieu"].Value);

            using (frmTraSach f = new frmTraSach(soPhieu)) // truyền maPhieu vào form Trả sách
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PanelBookManager_Load(); // reload lại
                }
            }
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            using (frmMuonSach f = new frmMuonSach())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PanelBookManager_Load(); // hàm reload lại DataGridView phiếu mượn
                }
            }
        }
        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSort.SelectedItem == null) return;

            string selected = cbbSort.SelectedItem.ToString();
            DataTable dt = null;

            dgvPhieuMuon.DataSource =
                            selected == "Mới nhất"
                            ? dal.GetAllOrderByNgayMuonDesc()
                            : dal.GetAllOrderByNgayMuonAsc();

            if (dt != null)
            {
                dgvPhieuMuon.DataSource = dt;
            }
        }
        private void LoadPhieu(string keyword = "")
        {
            // Gọi BLL/DAL để lấy dữ liệu từ DB
            var Phieu = new FunctionBLL();
            var data = Phieu.TimKiemPhieuMuon(keyword);
            dgvPhieuMuon.DataSource = data;
            
            DesignDGV(dgvPhieuMuon);
        }
        private void btnSearchPhieu_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadPhieu(keyword);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchSach_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchSach.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
                keyword = null;

            dgvDanhSach_CuonSach.DataSource = _funcBll.TimKiemCuonSach_ChiTiet(keyword);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            dgvDanhSach_CuonSach.DataSource = _spBll.DanhSachCuonSachSapXep();
            DesignDGV_DS_CuonSach();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string tacGia = cbbTacGia.Text.Trim();
            string theLoai = cbbTheLoai.Text.Trim();

            // nếu để trống thì coi như NULL
            if (string.IsNullOrEmpty(tacGia)) tacGia = null;
            if (string.IsNullOrEmpty(theLoai)) theLoai = null;

            dgvDanhSach_CuonSach.DataSource = _spBll.XemCuonSach_Filter(tacGia, theLoai);
            DesignDGV_DS_CuonSach();
        }
        private void LoadDanhSachCuonSach()
        {
            try
            {
                DataTable dt = _spBll.DanhSachCuonSach();
                dgvDanhSach_CuonSach.DataSource = dt;
                DesignDGV_DS_CuonSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }
        private void DesignDGV_DS_CuonSach()
        {
            if (dgvDanhSach_CuonSach.Columns["maCuonSach"] != null)
            {
                dgvDanhSach_CuonSach.Columns["maCuonSach"].HeaderText = "Mã sách";
                dgvDanhSach_CuonSach.Columns["maCuonSach"].FillWeight = 7;
            }

            if (dgvDanhSach_CuonSach.Columns["tenTuaSach"] != null)
            {
                dgvDanhSach_CuonSach.Columns["tenTuaSach"].HeaderText = "Tên tựa sách";
                dgvDanhSach_CuonSach.Columns["tenTuaSach"].FillWeight = 25;
            }
            if (dgvDanhSach_CuonSach.Columns["tacGia"] != null)
            {
                dgvDanhSach_CuonSach.Columns["tacGia"].HeaderText = "Tác giả";
                dgvDanhSach_CuonSach.Columns["tacGia"].FillWeight = 15;
            }
            if (dgvDanhSach_CuonSach.Columns["theLoai"] != null)
            {
                dgvDanhSach_CuonSach.Columns["theLoai"].HeaderText = "Thể loại";
                dgvDanhSach_CuonSach.Columns["theLoai"].FillWeight = 10;
            }
            if (dgvDanhSach_CuonSach.Columns["nhaXuatBan"] != null)
            {
                dgvDanhSach_CuonSach.Columns["nhaXuatBan"].HeaderText = "Nhà xuất bản";
                dgvDanhSach_CuonSach.Columns["nhaXuatBan"].FillWeight = 15;
            }
            if (dgvDanhSach_CuonSach.Columns["viTri"] != null)
            {
                dgvDanhSach_CuonSach.Columns["viTri"].HeaderText = "Vị trí";
                dgvDanhSach_CuonSach.Columns["viTri"].FillWeight = 10;
            }
            if (dgvDanhSach_CuonSach.Columns["tinhTrang"] != null)
            {
                dgvDanhSach_CuonSach.Columns["tinhTrang"].HeaderText = "Tình trạng";
                dgvDanhSach_CuonSach.Columns["tinhTrang"].FillWeight = 15;
            }

            DesignDGV(dgvDanhSach_CuonSach);
        }
        private void LoadComboBoxTacGia()
        {
            cbbTacGia.Properties.Items.Clear();
            DataTable dt = _funcBll.LayDanhSachTacGia();
            foreach (DataRow row in dt.Rows)
            {
                cbbTacGia.Properties.Items.Add(row["tacGia"].ToString());
            }
            cbbTacGia.SelectedIndex = -1;
        }

        private void LoadComboBoxTheLoai()
        {
            cbbTheLoai.Properties.Items.Clear();
            DataTable dt = _funcBll.LayDanhSachTheLoai();
            foreach (DataRow row in dt.Rows)
            {
                cbbTheLoai.Properties.Items.Add(row["theLoai"].ToString());
            }
            cbbTheLoai.SelectedIndex = -1;
        }

        private void btnTimKiemTaiKhoan_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            dgvTaiKhoan.DataSource = _funcBll.TimKiemTaiKhoan(keyword);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }

        private void btnCTPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn.");
                return;
            }
            // Lấy maPhieu từ dòng hiện tại
            int soPhieu = Convert.ToInt32(dgvPhieuMuon.CurrentRow.Cells["soPhieu"].Value);
            frmCTPhieu f = new frmCTPhieu(soPhieu);
            f.ShowDialog();
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản.");
                return;
            }

            // Lấy thông tin từ dòng hiện tại
            string userName = dgvTaiKhoan.CurrentRow.Cells["userName"].Value.ToString();
            string vaiTro = dgvTaiKhoan.CurrentRow.Cells["vaiTro"].Value.ToString();

            // Nếu là admin thì không cho xóa
            if (vaiTro.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được phép xóa tài khoản admin!");
                return;
            }

            // Hỏi xác nhận
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản '{userName}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            // Gọi BLL để xóa
            string errorMessage;
            bool result = _spBll.XoaTaiKhoan(userName, out errorMessage);

            if (result)
            {
                MessageBox.Show("Xóa tài khoản thành công!");
                // Reload lại danh sách tài khoản
                PanelTaiKhoan_Load();
            }
            else
            {
                MessageBox.Show("Không thể xóa tài khoản: " + errorMessage);
            }
        }

        private void btnTaoTaiKhoan_Click_1(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string maNguoi = txtIdNguoi.Text.Trim();
            string userName = txtUsername.Text.Trim();
            string pass = txtPass.Text;
            string confirmPass = txtConfirmPass.Text;

            // Kiểm tra dữ liệu cơ bản
            if (string.IsNullOrEmpty(maNguoi) || string.IsNullOrEmpty(userName)
                || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != confirmPass)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string errorMessage;

            bool success = _spBll.TaoTaiKhoanDocGia(maNguoi, userName, pass, out errorMessage);

            if (success)
            {
                MessageBox.Show("Tạo tài khoản độc giả thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trắng textbox sau khi tạo
                txtIdNguoi.Clear();
                txtUsername.Clear();
                txtPass.Clear();
                txtConfirmPass.Clear();
                PanelTaiKhoan_Load(); // reload lại danh sách tài khoản
            }
            else
            {
                MessageBox.Show("Tạo tài khoản thất bại: " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            grDoiMatKhau.Enabled = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var tk = Session.CurrentUser;
            string userName = tk.userName;
            string oldPassword = txtOldPassWord.Text.Trim();
            string newPassword = txtNewPassWord.Text.Trim();

            string errorMessage;
            var bll = new StoredProcedureBLL();

            if (bll.DoiMatKhau(userName, oldPassword, newPassword, out errorMessage))
            {
                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData.SetConnectionString("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True;TrustServerCertificate=True");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại: " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNguoi_Click(object sender, EventArgs e)
        {
            using (frmAddMember f = new frmAddMember())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    PanelTaiKhoan_Load(); 
                }
            }
        }

        private void btnDsMember_Click(object sender, EventArgs e)
        {
            frmDSThanhVien frm = new frmDSThanhVien();
            frm.ShowDialog();
        }
    }
}
