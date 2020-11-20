using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class UserLogBussines : IUserLog
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public DateTime Date { get; set; } = DateTime.Now;
        public Guid UserGuid { get; set; }
        public EnLogType Type { get; set; }
        public string Description { get; set; }




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


                res.AddReturnedValue(await UnitOfWork.UserLog.SaveAsync(this, tranName));
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

        public static async Task<List<UserLogBussines>> GetAllAsync(Guid userGuid) =>
            await UnitOfWork.UserLog.GetAllAsync(userGuid);
    }
}
