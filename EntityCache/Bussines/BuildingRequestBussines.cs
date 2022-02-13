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
    public class BuildingRequestBussines
    {
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBuildingRequest item, Guid customerGuid, SqlTransaction tr = null)
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
                res.AddReturnedValue(await SaveAsync_(item, customerGuid, tr));

                res.AddReturnedValue(await BuildingRequestRegionBussines.RemoveRangeAsync(item.Guid, customerGuid, tr));
                if (res.HasError) return res;

                if (item.RegionList.Count > 0)
                {
                    foreach (var op in item.RegionList)
                        op.RequestGuid = item.Guid;
                    res.AddReturnedValue(await BuildingRequestRegionBussines.SaveRangeAsync(item.RegionList, customerGuid, tr));
                    if (res.HasError) return res;
                }
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
        private static async Task<ReturnedSaveFuncInfo> SaveAsync_(WebBuildingRequest item, Guid customerGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingRequest_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@createDtae", item.CreateDate);
                cmd.Parameters.AddWithValue("@modif", DateTime.Now);
                cmd.Parameters.AddWithValue("@askerGuid", item.AskerGuid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@sellPrice1", item.SellPrice1);
                cmd.Parameters.AddWithValue("@sellPrice2", item.SellPrice2);
                cmd.Parameters.AddWithValue("@hasVam", item.HasVam);
                cmd.Parameters.AddWithValue("@rahn1", item.RahnPrice1);
                cmd.Parameters.AddWithValue("@rahn2", item.RahnPrice2);
                cmd.Parameters.AddWithValue("@ejare1", item.EjarePrice1);
                cmd.Parameters.AddWithValue("@ejare2", item.EjarePrice2);
                cmd.Parameters.AddWithValue("@peopleCount", item.PeopleCount);
                cmd.Parameters.AddWithValue("@hasOwner", item.HasOwner);
                cmd.Parameters.AddWithValue("@shortDate", item.ShortDate);
                cmd.Parameters.AddWithValue("@rentalGuid", item.RentalAutorityGuid);
                cmd.Parameters.AddWithValue("@cityGuid", item.CityGuid);
                cmd.Parameters.AddWithValue("@typeGuid", item.BuildingTypeGuid);
                cmd.Parameters.AddWithValue("@masahat1", item.Masahat1);
                cmd.Parameters.AddWithValue("@masahat2", item.Masahat2);
                cmd.Parameters.AddWithValue("@roomCount", item.RoomCount);
                cmd.Parameters.AddWithValue("@accTypeGuid", item.BuildingAccountTypeGuid);
                cmd.Parameters.AddWithValue("@conditionGuid", item.BuildingConditionGuid);
                cmd.Parameters.AddWithValue("@shortDesc", item.ShortDesc ?? "");
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
