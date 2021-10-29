using Nito.AsyncEx;
using Persistence.Migrations;
using Services;
using System;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using Persistence;

namespace EntityCache.Assistence
{
    public class ClsCache
    {
        public static void Init()
        {
            try
            {
                UpdateMigration();
                InserDefults();
                RunScripts();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void UpdateMigration()
        {
            try
            {
                var migratorConfig = new Configuration();
                var dbMigrator = new DbMigrator(migratorConfig);
                dbMigrator.Update();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void InserDefults()
        {
            try
            {
                AsyncContext.Run(AddDefaults.InsertDefaultDataAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void RunScripts()
        {
            try
            {
                var res = StartErtegha(Cache.ConnectionString);
                if (res.HasError) throw new ArgumentException("خطا در اجرای کوئری" + res.ErrorMessage);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static ReturnedSaveFuncInfo StartErtegha(string connectionString)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cn = new SqlConnection(connectionString);
                res.AddReturnedValue(DatabaseUtilities.Run(Properties.Resources.Ertegha, cn));
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
