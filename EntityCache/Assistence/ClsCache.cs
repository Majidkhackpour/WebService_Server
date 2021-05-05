using AutoMapper;
using Nito.AsyncEx;
using Persistence.Migrations;
using Services;
using System;
using System.Data.Entity.Migrations;

namespace EntityCache.Assistence
{
    public class ClsCache
    {
        public static void Init()
        {
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
    }
}
