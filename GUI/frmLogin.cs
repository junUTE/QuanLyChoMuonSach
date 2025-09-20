using System;
using System.Windows.Forms;
using BusinessLogicLayer;
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
