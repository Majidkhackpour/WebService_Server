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
    public class CustomersController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("Customer_GetAll")]
        public IEnumerable<Customers> GetAllAsync() => db.Customers.ToList();

        [HttpGet]
        [Route("Customer_Get/{guid}")]
        public Customers GetAsync(Guid guid) => db.Customers.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Customers SaveAsync(Customers cls)
        {
            try
            {
                var a = db.Customers.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Customers.Add(cls);
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
        [Route("Customer_GetByName/{name}")]
        public Customers GetAsync(string name) => db.Customers.FirstOrDefault(q => q.Name == name);

        [HttpGet]
        [Route("Customer_GetByHardSerial/{hSerial}")]
        public Customers GetByHardSerialAsync(string hSerial) =>
            db.Customers.FirstOrDefault(q => q.HardSerial == hSerial);
    }
}
