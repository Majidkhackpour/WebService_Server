using System;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines.Building;
using EntityCache.ViewModels;
using Services;

namespace Server.Controllers
{
    public class TelegramBuildingController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SendAsync(WebTelegramBuilding cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tel = new WebTelegramMessage()
                {
                    ChatID = cls.Channel,
                    ApiKey = cls.BotApi,
                    ContactType = EnTelegramType.Channel
                };
                _ = Task.Run(() => tel.SendAsync(cls.Content));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
