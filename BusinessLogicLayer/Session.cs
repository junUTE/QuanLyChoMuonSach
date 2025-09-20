using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public static class Session
    {
        // Người dùng hiện tại sau khi login
        public static TaiKhoan CurrentUser { get; private set; }
        public static string ConnStr { get; set; }

        // Thiết lập user sau khi đăng nhập
        public static void SetUser(TaiKhoan tk)
        {
            CurrentUser = tk;
        }

        // Xoá user khi logout
        public static void Clear()
        {
            CurrentUser = null;
        }

        // Kiểm tra đã login chưa
        public static bool IsLoggedIn()
        {
            return CurrentUser != null;
        }
    }
}
