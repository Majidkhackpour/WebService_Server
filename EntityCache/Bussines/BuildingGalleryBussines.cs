﻿using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingGalleryBussines
    {
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, Guid customerGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingGallery_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", masterGuid);
                cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBuildingGallery item, Guid customerGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingGallery_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@cusGuid", customerGuid);
                cmd.Parameters.AddWithValue("@imageName", item.ImageName ?? "");
                cmd.Parameters.AddWithValue("@modif", DateTime.Now);
                cmd.Parameters.AddWithValue("@buGuid", item.BuildingGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<WebBuildingGallery> items, Guid customerGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                {
                    res.AddReturnedValue(await SaveAsync(item, customerGuid, tr));
                    if (res.HasError) return res;
                }
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
