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
    public partial class frmAddMember : Form
    {
        private readonly StoredProcedureBLL _bll;
        public frmAddMember()
        {
            InitializeComponent();
            _bll = new StoredProcedureBLL();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string errorMessage;

            // Lấy giá trị từ combobox
            string gioiTinh = cbbGioiTinh.SelectedItem?.ToString() ?? "Nam";

            bool result = _bll.ThemDocGia(
                txtHoTen.Text.Trim(),
                gioiTinh, // <-- dùng combobox thay vì textbox
                dateNgaySinh.Value,
                txtDiaChi.Text.Trim(),
                txtSDT.Text.Trim(),
                txtEmail.Text.Trim(),
                txtCCCD.Text.Trim(),
                out errorMessage
            );

            if (result)
            {
                MessageBox.Show("Thêm độc giả thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: " + errorMessage, "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
      



        private void frmAddMember_Load(object sender, EventArgs e)
        {
            dateNgaySinh.CustomFormat = "dd/MM/yyyy";
        }

       
    }
}
