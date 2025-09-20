using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CTPhieuMuonBLL
    {
        private readonly CTPhieuMuonDAL _dal;

        public CTPhieuMuonBLL()
        {
            _dal = new CTPhieuMuonDAL();
        }

        public void ChinhSuaCT(int soPhieu, int maCuonSachCu, int maCuonSachMoi)
        {
            _dal.ChinhSuaCT(soPhieu, maCuonSachCu, maCuonSachMoi);
        }

        public void XoaCT(int soPhieu, int maCuonSach)
        {
            _dal.XoaCT(soPhieu, maCuonSach);
        }

        public void ThemCT(int soPhieu, int maCuonSach)
        {
            _dal.ThemCT(soPhieu, maCuonSach);
        }
    }
}
