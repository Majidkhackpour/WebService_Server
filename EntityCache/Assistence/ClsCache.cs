using System;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using AutoMapper;
using Nito.AsyncEx;
using Persistence;
using Persistence.Migrations;
using Services;

namespace EntityCache.Assistence
{
    public class ClsCache
    {
        public static void Init()
        {
            var config = new MapperConfiguration(c => { c.AddProfile(new SqlProfile()); });
            Mappings.Default = new Mapper(config);
            UpdateMigration();
            InserDefults();
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
        private static bool CheckConnectionString(string con)
        {
            try
            {
                var cn = new SqlConnection(con);
                cn.Open();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public static void InserDefults()
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
    }
}
