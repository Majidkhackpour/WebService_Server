using EntityCache.Assistence;
using Persistence;
using Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingReviewBussines
    {
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBuildingReview item, Guid customerGuid, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }
                var cmd = new SqlCommand("sp_BuildingReview_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Guid", item.Guid);
                cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                cmd.Parameters.AddWithValue("@BuildingGuid", item.BuildingGuid);
                cmd.Parameters.AddWithValue("@UserGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@CustomerGuid", item.CustometGuid);
                cmd.Parameters.AddWithValue("@Date", item.Date);
                cmd.Parameters.AddWithValue("@Report", item.Report ?? "");
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
    }
}
