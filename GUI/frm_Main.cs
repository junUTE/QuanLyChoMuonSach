using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;


namespace GUI
{
    public partial class frm_Main : Form
    {

        private PhieuMuonDAL dal = new PhieuMuonDAL();
        public frm_Main()
        {

            InitializeComponent();
            PanelInfoCard_Load();
            ShowDashboard(panelInfoCard);
        }
        private void ShowDashboard(Panel dashboardPanel)
        {
            // Hide all dashboard panels
            panelInfoCard.Visible = false;
            panelBookManager.Visible = false;
            panelSearch.Visible = false;
            panelCreateAcc.Visible = false;
            panelStatic.Visible = false;
            panelAccount.Visible = false;

            if (dashboardPanel == panelInfoCard)
                lbTaiKhoan.Text = "Thông tin cá nhân";
            else if (dashboardPanel == panelBookManager)
                lbTaiKhoan.Text = "Quản lý sách";
            else if (dashboardPanel == panelSearch)
                lbTaiKhoan.Text = "Tra cứu sách";
            else if (dashboardPanel == panelCreateAcc)
                lbTaiKhoan.Text = "Tạo tài khoản";
            else if (dashboardPanel == panelStatic)
                lbTaiKhoan.Text = "Thống kê";
            else if (dashboardPanel == panelAccount)
                lbTaiKhoan.Text = "Tài khoản";
            // Show the selected dashboard panel
            dashboardPanel.Visible = true;

        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            PanelInfoCard_Load();
            ShowDashboard(panelInfoCard);
        }

        private void btnBookManager_Click(object sender, EventArgs e)
        {
            PanelBookManager_Load();
            ShowDashboard(panelBookManager);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {

        }

        private void btnStatic_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PanelInfoCard_Load()
        {
            // Đổ dữ liệu thông tin cá nhân
            var tk = Session.CurrentUser;
            if (tk == null) return;

            lblId.Text = "ID: " + tk.maNguoi;
            lblHoTen.Text ="Họ tên: " + tk.hoTen;
            lblEmail.Text ="Email: " + tk.email;
            lblSDT.Text ="SDT: " + tk.SDT;
            lblCCCD.Text ="CCCD: " + tk.cccd;
            lblDiaChi.Text ="Địa chỉ:" + tk.diaChi;
            lblNgaySinh.Text ="Ngày sinh: " + (tk.ngaySinh.HasValue ? tk.ngaySinh.Value.ToString("dd/MM/yyyy") : "");
            lblChucVu.Text ="Vai tro: " + tk.vaiTro;
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            DesignDGV(dgvPhieuMuon);
        }
        private void PanelBookManager_Load()
        {
            var viewBLL = new ViewBLL();
            dgvPhieuMuon.DataSource = viewBLL.GetPhieuMuon();
            DesignDGV(dgvPhieuMuon);
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

        }

        private void btnSuaPhieu_Click(object sender, EventArgs e)
        {

        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {

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
    }
}
