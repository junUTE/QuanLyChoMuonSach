using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class PhieuMuonBLL
    {
        private readonly PhieuMuonDAL _dal;

        public PhieuMuonBLL()
        {
            _dal = new PhieuMuonDAL();
        }

        // Gọi sp_MuonSach
        public int MuonSach(string maDocGia, string maNhanVien, DateTime ngayHenTra, DataTable dsSach)
        {
            if (string.IsNullOrWhiteSpace(maDocGia) || string.IsNullOrWhiteSpace(maNhanVien))
                throw new ArgumentException("Mã độc giả hoặc nhân viên trống");
            if (dsSach == null || dsSach.Rows.Count == 0)
                throw new ArgumentException("Danh sách sách mượn rỗng");

            return _dal.MuonSach(maDocGia, maNhanVien, ngayHenTra, dsSach);
        }

        // Gọi sp_TraTungSach
        public bool TraTungSach(int soPhieu, int maCuonSach)
        {
            if (soPhieu <= 0 || maCuonSach <= 0)
                throw new ArgumentException("Tham số không hợp lệ");

            return _dal.TraTungSach(soPhieu, maCuonSach);
        }

        // Gọi sp_HuyPhieuMuon
        public bool HuyPhieu(int soPhieu)
        {
            if (soPhieu <= 0)
                throw new ArgumentException("Số phiếu không hợp lệ");

            return _dal.HuyPhieu(soPhieu);
        }

        // Gọi sp_ChinhSuaPhieuMuon
        public bool ChinhSuaPhieu(int soPhieu, string maNhanVien, DateTime ngayHenTra)
        {
            if (soPhieu <= 0 || string.IsNullOrWhiteSpace(maNhanVien))
                throw new ArgumentException("Tham số không hợp lệ");

            return _dal.ChinhSuaPhieuMuon(soPhieu, maNhanVien, ngayHenTra);
        }
    }
}
