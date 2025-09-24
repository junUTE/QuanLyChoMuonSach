using System;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace GUI
{
    public partial class frmLogin : Form
    {
        private readonly TaiKhoanBLL _taiKhoanService;

        public frmLogin()
        {
            InitializeComponent();
            _taiKhoanService = new TaiKhoanBLL();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            TaiKhoan tk = _taiKhoanService.Login(username, password);
            if (tk != null)
            {
                Session.SetUser(tk);   // giữ thông tin user đang đăng nhập

                string conn = "";
                switch (tk.vaiTro?.ToLower())
                {
                    case "admin":
                        conn = "Data Source=.;Initial Catalog=QLThuVien;User ID=lib_admin;Password=admin123;TrustServerCertificate=True";
                        break;
                    case "staff":
                        conn = "Data Source=.;Initial Catalog=QLThuVien;User ID=lib_staff;Password=staff123;TrustServerCertificate=True";
                        break;
                    case "guest":
                        conn = "Data Source=.;Initial Catalog=QLThuVien;User ID=lib_guest;Password=guest123;TrustServerCertificate=True";
                        break;
                    default:
                        MessageBox.Show("Không xác định được vai trò!", "Lỗi");
                        return;
                }

                // Áp dụng connection string mới
                LoadData.SetConnectionString(conn);

                frm_Main mainForm = new frm_Main();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
