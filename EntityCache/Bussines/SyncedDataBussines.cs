﻿using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Services.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class SyncedDataBussines : ISyncedData
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid ObjectGuid { get; set; }
        public string HardSerial { get; set; }
        public EnTemp Type { get; set; }



        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.SyncedData.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
