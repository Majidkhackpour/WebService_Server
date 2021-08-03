using System;
using Persistence.Entities;
using Persistence.Model;
using Server.Models;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EntityCache.ViewModels;
using Services;

namespace Server.Controllers
{
    public class BackUpManagerController : ApiController
    {
        private ModelContext db = new ModelContext();
        [MimeMultipart]
        public async Task<UploadFiles> Post()
        {
            try
            {
                var uploadPath = HttpContext.Current.Server.MapPath("~/BackUpFiles");
                Customers cus = null;
                if (Request.Content.IsMimeMultipartContent())
                {
                    var hddSerial = Request.Headers.GetValues("hddSerial").FirstOrDefault();
                    if (!string.IsNullOrEmpty(hddSerial))
                    {
                        cus = db.Customers.FirstOrDefault(q => q.HardSerial == hddSerial);
                        if (cus == null) return null;
                        if (cus.isBlock || cus.isWebServiceBlock) return null;
                    }
                }

                var multipartFormDataStreamProvider = new UploadFileMultiparProvider(uploadPath);

                await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

                var localFileName = multipartFormDataStreamProvider
                    .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

                var x = new UploadFiles
                {
                    FilePath = localFileName,
                    FileName = Path.GetFileName(localFileName),
                    FileLength = new FileInfo(localFileName).Length
                };
                var url = $"https://aarad.ir/BackUpFiles/{x.FileName}";
                db.BackUpLog.Add(new BackUpLog()
                {
                    Guid = Guid.NewGuid(),
                    CustomerGuid = cus?.Guid ?? Guid.Empty,
                    CreateDate = DateTime.Now,
                    FileName = x.FileName,
                    FileLength = (double)x.FileLength / 1000000,
                    URL = url
                });
                db.SaveChanges();

                var msg = $"Customer:😉 #{(cus?.Name ?? "").Replace(" ", "_")} 😉 \r\n" +
                          $"Company:🏫 #{(cus?.CompanyName ?? "").Replace(" ", "_")} 🏫 \r\n" +
                          $"HardSerial: {cus?.HardSerial} \r\n" +
                          $"Tell1:📱 {cus?.Tell1 ?? ""} 📱 \r\n" +
                          $"Tell2:📱 {cus?.Tell2 ?? ""} 📱 \r\n" +
                          $"=========================== \r\n" +
                          $"FileName:✏ {x.FileName} ✏ \r\n" +
                          $"FileLength:✨ #{(double)x.FileLength / 1000000} MB ✨ \r\n" +
                          $"URL: {url}";
                WebTelegramMessage.GetBackUpLog_bot().Send(msg);
                return x;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}