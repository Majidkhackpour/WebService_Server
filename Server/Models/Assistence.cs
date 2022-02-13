using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Persistence;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace Server.Models
{
    public class Assistence
    {
        private static ConcurrentDictionary<Guid, short> _dic = new ConcurrentDictionary<Guid, short>();
        public static bool CheckCustomer(Guid cusGuid)
        {
            var res = false;
            try
            {
                _dic.TryGetValue(cusGuid, out var counter);
                if (counter == 0 || counter >= 50)
                {
                    var count = GetCustomerCount(cusGuid);
                    res = count > 0;
                    counter = 0;
                    if (!res) return false;
                }

                counter++;
                _dic.TryAdd(cusGuid, counter);
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return res;
        }
        private static int GetCustomerCount(Guid cusGuid)
        {
            var res = 0;
            try
            {
                using (var cn = new SqlConnection(Cache.ConnectionString))
                {
                    using (var cmd = new SqlCommand("sp_CheckCustomerGuid", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cusGuid", cusGuid);
                        if (cn.State != ConnectionState.Open)
                            cn.Open();
                        var obj = cmd.ExecuteScalar();
                        cn.Close();
                        if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                            res = obj.ToString().ParseToInt();
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return res;
        }
        public static bool SaveLog(Guid cusGuid, Guid objectGuid, EnTemp tmp)
        {
            try
            {
                var db = new ModelContext();
                var log = new SyncedData()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    CustomerGuid = cusGuid,
                    Type = tmp,
                    ObjectGuid = objectGuid
                };
                db.SyncedData.Add(log);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}