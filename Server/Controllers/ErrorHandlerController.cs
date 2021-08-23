using EntityCache.ViewModels;
using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.Controllers
{
    public class ErrorHandlerController : ApiController
    {
        private ModelContext db = new ModelContext();
        [HttpPost]
        public ErrorLog SaveAsync(WebErrorLog cls)
        {
            var errorLog = new ErrorLog();
            try
            {
                errorLog = new ErrorLog()
                {
                    Guid = cls.Guid,
                    Status = true,
                    Description = cls.Description,
                    Date = DateTime.Now,
                    Modified = DateTime.Now,
                    AndroidIme = cls.AndroidIme,
                    ClassName = cls.ClassName,
                    CpuSerial = cls.CpuSerial,
                    ExceptionError = cls.ExceptionError,
                    ExceptionMessage = cls.ExceptionMessage,
                    ExceptionType = cls.ExceptionType,
                    Fatal = cls.Fatal,
                    FlowStackTrace = cls.FlowStackTrace,
                    FuncName = cls.FuncName,
                    GroupingID = cls.GroupingID,
                    HardSerial = cls.HardSerial,
                    Ip = cls.Ip,
                    LKSerial = cls.LKSerial,
                    LoggerVersion = cls.LoggerVersion,
                    Path = cls.Path,
                    RefrencedID = cls.RefrencedID,
                    ScreenShot = cls.ScreenShot,
                    Source = cls.Source,
                    StackTrace = cls.StackTrace,
                    Time = cls.Time,
                    Version = cls.Version
                };
                db.ErrorLog.Add(errorLog);
                db.SaveChanges();
                SendToTelegram(errorLog);
            }
            catch
            {
            }

            return errorLog;
        }

        private void SendToTelegram(ErrorLog err)
        {
            try
            {
                Customers cust = null;

                if (!string.IsNullOrEmpty(err.AndroidIme))
                {
                    var android = db.Androids.FirstOrDefault(q => q.IMEI == err.AndroidIme);
                    if (android != null)
                    {
                        cust = db.Customers.FirstOrDefault(q => q.Guid == android.CustomerGuid);
                        err.HardSerial = cust?.HardSerial;
                    }
                }
                else cust = db.Customers.FirstOrDefault(q => q.HardSerial == err.HardSerial);

                _ = Task.Run(() => SendToTelegramAsync(err, cust));
            }
            catch
            {
            }

        }
        private void SendToTelegramAsync(ErrorLog err, Customers cust)
        {
            try
            {
                var message = $"Source:✨ #{err.Source.GetDisplay()} ✨ \r\n" +
                              $"Version:✏ {err.Version} ✏ \r\n" +
                              $"=========================== \r\n" +
                              $"ClassName: #{err.ClassName.Replace(" ", "_")} \r\n" +
                              $"FunctionName: #{err.FuncName.Replace(" ", "_")} \r\n" +
                              $"Type: {err.ExceptionType.Replace(" ", "_")} \r\n" +
                              $"Message: {err.ExceptionMessage} \r\n" +
                              $"Description: {err.Description}\r\n" +
                              $"=========================== \r\n" +
                              $"HardSerial: {err.HardSerial} \r\n" +
                              $"Customer:😉 #{(cust?.Name ?? "").Replace(" ", "_")} 😉 \r\n" +
                              $"Company:🏫 #{(cust?.CompanyName ?? "").Replace(" ", "_")} 🏫 \r\n" +
                              $"Tell1:📱 {cust?.Tell1 ?? ""} 📱 \r\n" +
                              $"Tell2:📱 {cust?.Tell2 ?? ""} 📱 \r\n" +
                              $"IP:🌐 {err.Ip} 🌐 \r\n" +
                              $"Date: {Calendar.MiladiToShamsi(err.Date)} \r\n" +
                              $"Time:🕟 {err.Time} 🕟";

                WebTelegramMessage.GetErrorLog_bot().Send(message);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
