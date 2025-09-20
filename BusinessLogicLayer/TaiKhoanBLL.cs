using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public class TaiKhoanBLL
    {
        private readonly TaiKhoanDAL _dao;

        public TaiKhoanBLL()
        {
            _dao = new TaiKhoanDAL();
        }

        // Đăng nhập
        public TaiKhoan Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            try
            {
                return _dao.Login(username, password);
            }
            catch
            {
                return null;
            }
        }

        // Lấy vai trò theo mã người
        public string GetRole(string maNguoi)
        {
            if (string.IsNullOrWhiteSpace(maNguoi))
                return null;

            return _dao.GetRole(maNguoi);
        }
    }
}
