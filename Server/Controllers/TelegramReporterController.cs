using EntityCache.ViewModels;
using Persistence.Model;
using Services;
using System;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class TelegramReporterController : ApiController
    {
        private ModelContext db = new ModelContext();
        [HttpPost]
        public ScrapperReportViewModel SendAsync(WebTelegramReporter cls)
        {
            try
            {
                var msg = "";
                if (cls == null) return null;

                if (cls.Source == ENSource.Scrapper)
                    msg = SendScrapperErrorToTelegramAsync(cls);
                else if (cls.Source == ENSource.Building)
                    msg = SendToTelegramAsync(cls);

                WebTelegramMessage.GetReporter_bot().Send(msg);
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        private string SendScrapperErrorToTelegramAsync(WebTelegramReporter err)
        {
            try
            {
                return $"Source:✨ #{err.Source.GetDisplay()} ✨ \r\n" +
                              $"=========================== \r\n" +
                              $"#{err.Message} \r\n" +
                              $"=========================== \r\n" +
                              $"Date: {Calendar.MiladiToShamsi(err.Date)} \r\n" +
                              $"Time:🕟 {err.Time} 🕟";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        private string SendToTelegramAsync(WebTelegramReporter err)
        {
            try
            {
                var cust = db.Customers.FirstOrDefault(q => q.Guid == err.CustomerGuid);
                return $"Source:✨ #{err.Source.GetDisplay()} ✨ \r\n" +
                              $"=========================== \r\n" +
                              $"Customer:😉 #{(cust?.Name ?? "").Replace(" ", "_")} 😉 \r\n" +
                              $"Company:🏫 #{(cust?.CompanyName ?? "").Replace(" ", "_")} 🏫 \r\n" +
                              $"Tell1:📱 {cust?.Tell1 ?? ""} 📱 \r\n" +
                              $"Tell2:📱 {cust?.Tell2 ?? ""} 📱 \r\n" +
                              $"=========================== \r\n" +
                              $"{err.Message} \r\n" +
                              $"=========================== \r\n" +
                              $"Date: {Calendar.MiladiToShamsi(err.Date)} \r\n" +
                              $"Time:🕟 {err.Time} 🕟";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
    }
}