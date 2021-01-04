using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.ViewModels;
using Services;
using Servicess.Interfaces;

namespace EntityCache.Bussines
{
    public class ErrorLogBussines : IHasGuid
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; } = true;
        public string AndroidIme { get; set; }
        public string ClassName { get; set; }
        public string CpuSerial { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ExceptionError { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public bool Fatal { get; set; }
        public string FuncName { get; set; }
        public int GroupingID { get; set; }
        public string HardSerial { get; set; }
        public long LKSerial { get; set; }
        public int RefrencedID { get; set; }
        public string ScreenShot { get; set; }
        public ENSource Source { get; set; }
        public string StackTrace { get; set; }
        public string FlowStackTrace { get; set; }
        public string Time { get; set; }
        public string Version { get; set; }
        public string Ip { get; set; }
        public string Path { get; set; }
        public string LoggerVersion { get; set; }




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

                res.AddReturnedValue(await UnitOfWork.ErrorLog.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (!res.HasError)
                {
                    CustomerBussines cust = null;

                    if (!string.IsNullOrEmpty(AndroidIme))
                    {
                        var android = await AndroidsBussines.GetAsync(AndroidIme);
                        if (android != null)
                        {
                            cust = await CustomerBussines.GetAsync(android.CustomerGuid);
                            HardSerial = cust.HardSerial;
                        }
                    }
                    else cust = await CustomerBussines.GetAsync(HardSerial);

                    _ = Task.Run(() => SendToTelegramAsync(cust));
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
        private async Task SendToTelegramAsync(CustomerBussines cust)
        {
            try
            {
                var message = $"Source:✨ #{Source.GetDisplay()} ✨ \r\n" +
                              $"Version:✏ {Version} ✏ \r\n" +
                              $"=========================== \r\n" +
                              $"ClassName: #{ClassName.Replace(" ", "_")} \r\n" +
                              $"FunctionName: #{FuncName.Replace(" ", "_")} \r\n" +
                              $"Type: {ExceptionType.Replace(" ", "_")} \r\n" +
                              $"Message: {ExceptionMessage} \r\n" +
                              $"=========================== \r\n" +
                              $"HardSerial: {HardSerial} \r\n" +
                              $"Customer:😉 #{(cust?.Name ?? "").Replace(" ", "_")} 😉 \r\n" +
                              $"Company:🏫 #{(cust?.CompanyName ?? "").Replace(" ", "_")} 🏫 \r\n" +
                              $"Tell1:📱 {cust?.Tell1 ?? ""} 📱 \r\n" +
                              $"Tell2:📱 {cust?.Tell2 ?? ""} 📱 \r\n" +
                              $"IP:🌐 {Ip} 🌐 \r\n" +
                              $"Time:🕟 {Time} 🕟";

                WebTelegramMessage.GetErrorLog_bot().Send(message);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
