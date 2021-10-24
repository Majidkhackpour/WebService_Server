using Persistence.Entities.Building;
using Persistence.Model;
using Server.Models;
using Services;
using Services.AndroidViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

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
                var headers = Request.Headers?.ToList();
                if (headers == null || headers.Count <= 0) return null;
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                db.Buildings.AddOrUpdate(cls);
                db.SaveChanges();
                Assistence.SaveLog(cusGuid, cls.Guid, EnTemp.Building);
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
        [Route("Buildings_GetLastList/{_type}")]
        public IEnumerable<BuildingListViewModel> GetLastList(EnRequestType _type)
        {
            var list = new List<BuildingListViewModel>();
            try
            {
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return list;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return list;
                List<Building> buList = null;
                switch (_type)
                {
                    case EnRequestType.Rahn:
                        buList = db.Buildings.AsNoTracking().Where(q => q.CustomerGuid == cusGuid && q.RahnPrice1 > 0)
                            ?.OrderByDescending(q => q.CreateDate)?.Take(50).ToList();
                        break;
                    case EnRequestType.Forush:
                        buList = db.Buildings.AsNoTracking().Where(q => q.CustomerGuid == cusGuid && q.SellPrice > 0)
                            ?.OrderByDescending(q => q.CreateDate)?.Take(50).ToList();
                        break;
                    case EnRequestType.PishForush:
                        buList = db.Buildings.AsNoTracking().Where(q => q.CustomerGuid == cusGuid && q.PishPrice > 0)
                            ?.OrderByDescending(q => q.CreateDate)?.Take(50).ToList();
                        break;
                    case EnRequestType.Mosharekat:
                        buList = db.Buildings.AsNoTracking().Where(q => q.CustomerGuid == cusGuid && !string.IsNullOrEmpty(q.MosharekatDesc))
                            ?.OrderByDescending(q => q.CreateDate)?.Take(50).ToList();
                        break;
                }
                if (!(buList?.Any() ?? false)) return list;
                foreach (var bu in buList)
                {
                    var city = db.Cities.AsNoTracking().FirstOrDefault(q => q.Guid == bu.CityGuid && q.CustomerGuid == cusGuid);
                    var stateName = db.States.AsNoTracking().FirstOrDefault(q => q.Guid == city.StateGuid)?.Name ?? "";
                    var cityName = city?.Name ?? "";
                    var regionName = db.Regions.AsNoTracking().FirstOrDefault(q => q.Guid == bu.RegionGuid && q.CustomerGuid == cusGuid)?.Name ?? "";
                    var accTypeName = db.BuildingAccountTypes.AsNoTracking().FirstOrDefault(q => q.CustomerGuid == cusGuid && q.Guid == bu.BuildingAccountTypeGuid)?.Name ?? "";
                    var typeName = db.BuildingTypes.AsNoTracking().FirstOrDefault(q => q.CustomerGuid == cusGuid && q.Guid == bu.BuildingTypeGuid)?.Name ?? "";
                    var a = new BuildingListViewModel()
                    {
                        Guid = bu.Guid,
                        ImageName = bu.Image,
                        Metrazh = $"{bu.Masahat} متر",
                        Address = $"{stateName} - {cityName} - {regionName}",
                        SaleSakht = bu.SaleSakht,
                        SellPrice = $"{(bu.SellPrice / 10):N0} تومان",
                        RoomCount = bu.RoomCount > 0 ? $"{bu.RoomCount} خواب" : "بدون خواب",
                        PishPrice = $"{(bu.PishPrice / 10):N0} تومان",
                        TabaqeCount = bu.TabaqeNo > 0 ? $"طبقه {bu.TabaqeNo} از {bu.TedadTabaqe}" : "یک طبقه",
                        PishTotalPrice = $"{(bu.PishTotalPrice / 10):N0} تومان",
                        Date = bu.CreateDate.GetTelegramDate(),
                        EjarePrice = $"{(bu.EjarePrice1 / 10):N0} تومان",
                        RahnPrice = $"{(bu.RahnPrice1 / 10):N0} تومان",
                        Type = $"{accTypeName} - {typeName}"
                    };
                    list.Add(a);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        [HttpGet]
        [Route("Buildings_GetViewByGuid/{guid},{hSerial}")]
        public BuildingViewModel GetViewByGuid(Guid guid, string hSerial)
        {
            BuildingViewModel res = null;
            try
            {
                var cust = db.Customers.AsNoTracking().FirstOrDefault(q => q.HardSerial == hSerial);
                if (cust == null) return res;
                var bu = db.Buildings.AsNoTracking().FirstOrDefault(q => q.Guid == guid && q.CustomerGuid == cust.Guid);
                if (bu == null) return res;
                var city = db.Cities.AsNoTracking().FirstOrDefault(q => q.Guid == bu.CityGuid && q.CustomerGuid == cust.Guid);
                var stateName = db.States.AsNoTracking().FirstOrDefault(q => q.Guid == city.StateGuid)?.Name ?? "";
                var regionName = db.Regions.AsNoTracking().FirstOrDefault(q => q.Guid == bu.RegionGuid && q.CustomerGuid == cust.Guid)?.Name ?? "";
                var owner = db.Peoples.AsNoTracking().FirstOrDefault(q => q.Guid == bu.OwnerGuid && q.CustomerGuid == cust.Guid);
                var user = db.BuildingUsers.AsNoTracking().FirstOrDefault(q => q.Guid == bu.UserGuid && q.CustomerGuid == cust.Guid);
                var userTell = db.BuildingPhoneBooks.AsNoTracking().FirstOrDefault(q => q.ParentGuid == user.Guid && q.CustomerGuid == cust.Guid);

                res = new BuildingViewModel
                {
                    Address = bu?.Address ?? "-",
                    Code = bu?.Code ?? "-",
                    FloorCoverName = db.FloorCovers.AsNoTracking()
                                         .FirstOrDefault(
                                             q => q.Guid == bu.FloorCoverGuid && q.CustomerGuid == cust.Guid)?.Name ??
                                     "-",
                    CityName = city?.Name ?? "",
                    StateName = stateName,
                    RegionName = regionName,
                    DocumentName = db.DocumentTypes.AsNoTracking()
                                       .FirstOrDefault(q => q.Guid == bu.DocumentType && q.CustomerGuid == cust.Guid)
                                       ?.Name ?? "-",
                    KitchenServiceName = db.KitchenServices.AsNoTracking()
                                             .FirstOrDefault(q =>
                                                 q.Guid == bu.KitchenServiceGuid && q.CustomerGuid == cust.Guid)
                                             ?.Name ?? "-",
                    Masahat = $"{bu.Masahat} متر مربع",
                    SideName = bu.Side.GetDisplay(),
                    TypeName = db.BuildingTypes.AsNoTracking()
                                   .FirstOrDefault(q => q.Guid == bu.BuildingTypeGuid && q.CustomerGuid == cust.Guid)
                                   ?.Name ?? "-",
                    ViewName = db.BuildingViews.AsNoTracking()
                                   .FirstOrDefault(q => q.Guid == bu.BuildingViewGuid && q.CustomerGuid == cust.Guid)
                                   ?.Name ?? "-",
                    OwnerName = owner?.Name ?? "-",
                    OwnerAddress = owner?.Address ?? "-",
                    AdvisorName = user?.Name ?? "-",
                    AdvisorTell = userTell?.Tell ?? "-",
                    VahedPerTabaqe = bu.VahedPerTabaqe > 0 ? $"{bu.VahedPerTabaqe} طبقه" : "ثبت نشده"
                };

                if (owner != null)
                {
                    var ownerTells = db.BuildingPhoneBooks.AsNoTracking().Where(q => q.ParentGuid == owner.Guid && q.CustomerGuid == cust.Guid).ToList();
                    if (!(ownerTells?.Any() ?? false))
                    {
                        if (ownerTells.Count >= 2)
                        {
                            res.OwnerTell1 = ownerTells[0]?.Tell ?? "-";
                            res.OwnerTell2 = ownerTells[1]?.Tell ?? "-";
                        }
                        else if (ownerTells.Count >= 1)
                        {
                            res.OwnerTell1 = ownerTells[0]?.Tell ?? "-";
                            res.OwnerTell2 = "-";
                        }
                        else
                        {
                            res.OwnerTell1 = "-";
                            res.OwnerTell2 = "-";
                        }
                    }
                    else
                    {
                        res.OwnerTell1 = "-";
                        res.OwnerTell2 = "-";
                    }
                }
                else
                {
                    res.OwnerTell1 = "-";
                    res.OwnerTell2 = "-";
                }

                if (!string.IsNullOrEmpty(bu.ShortDesc)) res.Description = bu.ShortDesc;
                else bu.ShortDesc = "ندارد";

                if (bu.SellPrice > 0) res.Price = $"{bu.SellPrice:N0} ریال فروش";
                else if (bu.RahnPrice1 > 0 || bu.EjarePrice1 > 0)
                {
                    if (bu.RahnPrice1 > 0 && bu.EjarePrice1 > 0)
                        res.Price = $"{bu.RahnPrice1:N0} ریال رهن \r\n \r\n {bu.EjarePrice1:N0} ریال اجاره";
                    else if (bu.RahnPrice1 > 0) res.Price = $"{bu.RahnPrice1:N0} ریال رهن";
                    else if (bu.EjarePrice1 > 0) res.Price = $"{bu.EjarePrice1:N0} ریال اجاره";
                }
                else res.Price = "-";

                res.RoomCount = bu.RoomCount > 0 ? $"{bu.RoomCount} خواب" : "بدون خواب";
                res.TabaqeCount = bu.TabaqeNo > 0 ? $"طبقه {bu.TabaqeNo} از {bu.TedadTabaqe}" : "یک طبقه";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
