using Nito.AsyncEx;
using Persistence.Migrations;
using Services;
using System;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using Persistence;

namespace EntityCache.Assistence
{
    public static class ClsCache
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
        public static ReturnedSaveFuncInfo TransactionDestiny(this SqlTransaction tr, bool isRollBack)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                ret.AddReturnedValue(isRollBack ? RollBackTran(tr) : CommitTran(tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            return ret;
        }
        private static ReturnedSaveFuncInfo CommitTran(this SqlTransaction tr, SqlConnection cn = null)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                tr?.Commit();
            }
            catch (Exception ex)
            {
                ret.AddReturnedValue(ex);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                ret.AddReturnedValue(CloseConnection(cn));
            }
            return ret;
        }
        private static ReturnedSaveFuncInfo RollBackTran(this SqlTransaction tr, SqlConnection cn = null)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                tr?.Rollback();
            }
            catch (Exception ex)
            {
                ret.AddReturnedValue(ex);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                ret.AddReturnedValue(CloseConnection(cn));
            }
            return ret;
        }
        public static ReturnedSaveFuncInfo CloseConnection(this SqlConnection cn)
        {
            var ret = new ReturnedSaveFuncInfo();
            try
            {
                if (cn == null) return ret;
                if (cn.State == System.Data.ConnectionState.Closed) return ret;
                cn?.Close();
            }
            catch (Exception ex)
            {
                ret.AddReturnedValue(ex);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return ret;
        }
    }
}
