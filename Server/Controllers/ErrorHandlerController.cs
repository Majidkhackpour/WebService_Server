using System;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class ErrorHandlerController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(WebErrorLog cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var errorLog = new ErrorLogBussines()
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
                res.AddReturnedValue(await errorLog.SaveAsync());
            }
            catch (Exception ex)
            {
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
