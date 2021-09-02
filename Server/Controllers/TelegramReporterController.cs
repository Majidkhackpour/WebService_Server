using EntityCache.ViewModels;
using Services;
using System.Web.Http;

namespace Server.Controllers
{
    public class TelegramReporterController : ApiController
    {
        [HttpGet]
        [Route("TelegramReporter_Send/{msg}")]
        public ScrapperReportViewModel SendReportAsync(string msg)
        {
            WebTelegramMessage.GetReporter_bot().Send(msg);
            return null;
        }
    }
}