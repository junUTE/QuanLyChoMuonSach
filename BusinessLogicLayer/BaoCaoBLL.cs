using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL _dal;

        public BaoCaoBLL()
        {
            _dal = new BaoCaoDAL();
        }

        public DataTable DanhSachPhieuQuaHan()
        {
            return _dal.DanhSachPhieuQuaHan();
        }
    }
}
