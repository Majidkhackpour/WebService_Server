using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class SmsLogBussines : ISmsLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public DateTime Date { get; set; } = DateTime.Now;
        public Guid UserGuid { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }
        public string Message { get; set; }
        public decimal Cost { get; set; }
        public long MessageId { get; set; }
        public string StatusText { get; set; }


        public static async Task<SmsLogBussines> GetAsync(Guid guid) => await UnitOfWork.SmsLog.GetAsync(guid);
        public static SmsLogBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<List<SmsLogBussines>> GetAllAsync() => await UnitOfWork.SmsLog.GetAllAsync();
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

                res.AddReturnedValue(await UnitOfWork.SmsLog.SaveAsync(this, tranName));
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
        public static async Task<SmsLogBussines> GetAsync(long messageId) => await UnitOfWork.SmsLog.GetAsync(messageId);
    }
}
