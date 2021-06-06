using Persistence.Entities.Building;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Services.AndroidViewModels;

namespace Server.Controllers
{
    public class BuildingController : ApiController
    {
        private ModelContext db = new ModelContext();
        [HttpPost]
        public Building SaveAsync(Building cls)
        {
            try
            {
                var cust = db.Customers.AsNoTracking().FirstOrDefault(q => q.HardSerial == cls.HardSerial);
                cls.CustomerGuid = cust?.Guid ?? Guid.Empty;
                var a = db.Buildings.AsNoTracking().FirstOrDefault(q => q.Guid == cls.Guid && q.CustomerGuid == cust.Guid);
                if (a == null) db.Buildings.Add(cls);
                else db.Entry(cls).State = EntityState.Modified;
                db.SaveChanges();
                return cls;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

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

        [HttpGet]
        [Route("Buildings_GetLastList/{hSerial}")]
        public IEnumerable<BuildingListViewModel> GetLastList(string hSerial)
        {
            var list = new List<BuildingListViewModel>();
            try
            {
                var cust = db.Customers.FirstOrDefault(q => q.HardSerial == hSerial);
                if (cust == null) return list;
                var buList = db.Buildings.Where(q => q.CustomerGuid == cust.Guid)?.OrderByDescending(q => q.CreateDate)?.Take(50);
                if (!(buList?.Any() ?? false)) return list;
                foreach (var bu in buList)
                {
                    var city = db.Cities.FirstOrDefault(q => q.Guid == bu.CityGuid) ?? new Cities();
                    var stateName = db.States.FirstOrDefault(q => q.Guid == city.StateGuid)?.Name ?? "";
                    var cityName = city?.Name ?? "";
                    var regionName = db.Regions.FirstOrDefault(q => q.Guid == bu.RegionGuid)?.Name ?? "";
                    var a = new BuildingListViewModel()
                    {
                        Guid = bu.Guid,
                        ImageName = bu.Image,
                        Metrazh = $"{bu.Masahat} متر",
                        RoomCount = $"{bu.RoomCount} خواب",
                        TabaqeCount = $"طبقه {bu.TabaqeNo} از {bu.TedadTabaqe}",
                        Address = $"{stateName} - {cityName} - {regionName} - {bu.Address}"
                    };
                    if (bu.SellPrice > 0) a.Price = $"{bu.SellPrice:N0} ریال فروش";
                    else if (bu.RahnPrice1 > 0 || bu.EjarePrice1 > 0)
                    {
                        if (bu.RahnPrice1 > 0 && bu.EjarePrice1 > 0)
                            a.Price = $"{bu.RahnPrice1:N0} ریال رهن - {bu.EjarePrice1:N0} ریال اجاره";
                        else if (bu.RahnPrice1 > 0) a.Price = $"{bu.RahnPrice1:N0} ریال رهن";
                        else if (bu.EjarePrice1 > 0) a.Price = $"{bu.EjarePrice1:N0} ریال اجاره";
                    }
                    else a.Price = "-";
                    list.Add(a);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
