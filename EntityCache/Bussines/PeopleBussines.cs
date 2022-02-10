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
    public class PeopleBussines
    {
        public async Task<ReturnedSaveFuncInfo> SaveAsync(WebPeople item, Guid customerGuid, SqlTransaction tr = null)
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
                //res.AddReturnedValue(await _tell.RemoveByParentAsync(item.Guid, tr));
                //if (res.HasError) return res;

                //if (item.TellList?.Count > 0)
                //{
                //    foreach (var t in item.TellList)
                //    {
                //        t.ParentGuid = item.Guid;
                //        t.Name = item.Name;
                //    }
                //    res.AddReturnedValue(await _tell.SaveRangeAsync(item.TellList, tr));
                //}

                res.AddReturnedValue(await SaveAsync_(item, customerGuid, tr));
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
        private async Task<ReturnedSaveFuncInfo> SaveAsync_(WebPeople item, Guid customerGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Peoples_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@code", item.Code);
                cmd.Parameters.AddWithValue("@nCode", item.NationalCode ?? "");
                cmd.Parameters.AddWithValue("@idCode", item.IdCode ?? "");
                cmd.Parameters.AddWithValue("@fName", item.FatherName ?? "");
                cmd.Parameters.AddWithValue("@pBirth", item.PlaceBirth ?? "");
                cmd.Parameters.AddWithValue("@dBirth", item.DateBirth ?? "");
                cmd.Parameters.AddWithValue("@address", item.Address ?? "");
                cmd.Parameters.AddWithValue("@issued", item.IssuedFrom ?? "");
                cmd.Parameters.AddWithValue("@postalCode", item.PostalCode ?? "");
                cmd.Parameters.AddWithValue("@groupGuid", item.GroupGuid);
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
