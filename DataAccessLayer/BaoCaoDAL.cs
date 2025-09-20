using System.Data;

namespace DataAccessLayer
{
    public class BaoCaoDAL
    {
        public DataTable DanhSachPhieuQuaHan()
        {
            return LoadData.ExecuteQuery("EXEC sp_DanhSachPhieuQuaHan");
        }
    }
}
