using EntityCache.Bussines;
using Server.Models;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebHesabBussines;

namespace Server.Controllers
{
    public class FloorCoverController : ApiController
    {
        [HttpPost]
        public async Task<WebFloorCover> SaveAsync(WebFloorCover cls)
        {
            try
            {
                var headers = Request.Headers?.ToList();
                if (headers == null || headers.Count <= 0) return null;
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                var res = await FloorCoverBussines.SaveAsync(cls, cusGuid);
                if (res.HasError) return null;
                Assistence.SaveLog(cusGuid, cls.Guid, EnTemp.FloorCover);
                return cls;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
