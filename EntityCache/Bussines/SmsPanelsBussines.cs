using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SmsPanelsBussines : ISmsPanels
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string API { get; set; }
        public bool IsCurrent { get; set; }

        public static async Task<SmsPanelsBussines> GetAsync(Guid guid) => await UnitOfWork.SmsPanel.GetAsync(guid);
        public static SmsPanelsBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<List<SmsPanelsBussines>> GetAllAsync() => await UnitOfWork.SmsPanel.GetAllAsync();
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

                res.AddReturnedValue(await UnitOfWork.SmsPanel.SaveAsync(this, tranName));
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
        public static async Task<SmsPanelsBussines> GetCurrentAsync() => await UnitOfWork.SmsPanel.GetCurrentAsync();
    }
}
