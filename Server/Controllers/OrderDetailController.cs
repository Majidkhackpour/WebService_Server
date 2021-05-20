using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace Server.Controllers
{
    public class OrderDetailController : ApiController
    {
        private ModelContext db = new ModelContext();
        [System.Web.Http.HttpPost]
        public OrderDetails SaveAsync(OrderDetails cls)
        {
            try
            {
                var a = db.OrderDetails.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.OrderDetails.Add(cls);
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
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("OrderDetail_GetAll/{orderGuid}")]
        public IEnumerable<OrderDetails> GetAsync(Guid orderGuid) => db.OrderDetails.Where(q => q.OrderGuid == orderGuid);
    }
}