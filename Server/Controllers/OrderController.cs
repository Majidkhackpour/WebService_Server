using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class OrderController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("Order_GetAll")]
        public IEnumerable<Order> GetAllAsync() => db.Order.ToList();

        [HttpGet]
        [Route("Order_Get/{guid}")]
        public Order GetAsync(Guid guid) => db.Order.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Order SaveAsync(Order cls)
        {
            try
            {
                var a = db.Order.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Order.Add(cls);
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

        [HttpGet]
        [Route("Order_NextCode")]
        public string NextCodeAsync() => (db.Order.Max(q => q.ContractCode) + 1).ToString();
    }
}
