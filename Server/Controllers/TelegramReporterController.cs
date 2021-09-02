using System;
using System.Collections.Generic;
using EntityCache.ViewModels;
using Services;
using System.Web.Http;

namespace Server.Controllers
{
    public class TelegramReporterController : ApiController
    {
        [HttpPost]
        public ScrapperReportViewModel SendAsync(List<ScrapperReportViewModel> cls)
        {
            try
            {
                var str = GetTelegramMessage(cls);
                WebTelegramMessage.GetReporter_bot().Send(str);
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        private string GetTelegramMessage(List<ScrapperReportViewModel> cls)
        {
            var msg = "";
            try
            {
                msg = $"دریافت داده از دیوار \r\n" +
                      $"====================== \r\n \r\n";
                foreach (var item in cls)
                    msg += $"{item.Type.GetDisplay()} : {item.Count} \r\n";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return msg;
        }
    }
}