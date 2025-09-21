using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class StoredProcedureBLL
    {
        private readonly StoredProcedureDAL _dal;

        public StoredProcedureBLL()
        {
            _dal = new StoredProcedureDAL();
        }

        // Chỉnh sửa chi tiết phiếu mượn
        public bool ChinhSuaCT(int soPhieu, int maCuonSachCu, int maCuonSachMoi)
        {
            if (soPhieu <= 0 || maCuonSachCu <= 0 || maCuonSachMoi <= 0)
                return false;
            return _dal.ChinhSuaCT(soPhieu, maCuonSachCu, maCuonSachMoi);
        }

        // Xóa chi tiết phiếu mượn
        public bool XoaCT(int soPhieu, int maCuonSach)
        {
            if (soPhieu <= 0 || maCuonSach <= 0)
                return false;
            return _dal.XoaCT(soPhieu, maCuonSach);
        }

        // Thêm chi tiết phiếu mượn
        public bool ThemCT(int soPhieu, int maCuonSach)
        {
            if (soPhieu <= 0 || maCuonSach <= 0)
                return false;
            return _dal.ThemCT(soPhieu, maCuonSach);
        }

        // Mượn sách
        public int MuonSach(string maDocGia, string maNhanVien, DateTime ngayHenTra, DataTable dsSach)
        {
            if (string.IsNullOrWhiteSpace(maDocGia) ||
                string.IsNullOrWhiteSpace(maNhanVien) ||
                dsSach == null || dsSach.Rows.Count == 0)
                return 0;

            return _dal.MuonSach(maDocGia, maNhanVien, ngayHenTra, dsSach);
        }

        // Trả từng sách
        public bool TraTungSach(int soPhieu, int maCuonSach, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (soPhieu <= 0 || maCuonSach <= 0)
            {
                errorMessage = "Số phiếu hoặc mã cuốn sách không hợp lệ.";
                return false;
            }

            return _dal.TraTungSach(soPhieu, maCuonSach, out errorMessage);
        }

        // Hủy phiếu mượn
        public bool HuyPhieu(int soPhieu)
        {
            if (soPhieu <= 0)
                return false;
            return _dal.HuyPhieu(soPhieu);
        }

        // Chỉnh sửa phiếu mượn
        public bool ChinhSuaPhieuMuon(int soPhieu, string maNhanVien, DateTime ngayHenTra)
        {
            if (soPhieu <= 0 || string.IsNullOrWhiteSpace(maNhanVien))
                return false;
            return _dal.ChinhSuaPhieuMuon(soPhieu, maNhanVien, ngayHenTra);
        }

        // Danh sách phiếu quá hạn
        public DataTable DanhSachPhieuQuaHan()
        {
            return _dal.DanhSachPhieuQuaHan();
        }
    }
}
