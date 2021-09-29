using System;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.ViewModels;
using Services;

namespace Server.Controllers
{
    public class WhatsappBuildingController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public async Task<ReturnedSaveFuncInfo> SendAsync(WebWhatsappBuilding cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tel = new WebWhatsappBuilding()
                {
                   Message = cls.Message,
                   ApiCode = cls.ApiCode,
                   Number = cls.Number
                };
                _ = Task.Run(() => tel.SendAsync());
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