﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EntityCache.Bussines.Building;
using Services;

namespace Server.Controllers
{
    public class BuildingController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBusines cls) => await cls.SaveAsync();

        [Route("PostImage")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> PostImage()
        {
            var dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    var response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        var maxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> allowedFileExtensions = new List<string> { ".jpg", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!allowedFileExtensions.Contains(extension))
                        {
                            var message = "Please Upload image of type .jpg,.gif,.png.";
                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        if (postedFile.ContentLength > maxContentLength)
                        {
                            var message = "Please Upload a file upto 1 mb.";
                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        var filePath = HttpContext.Current.Server.MapPath("~/BuildingImages/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                    }

                    var message1 = "Image Updated Successfully.";
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = "Please Upload a image.";
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = "some Message";
                dict.Add("error", res);
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }
    }
}
