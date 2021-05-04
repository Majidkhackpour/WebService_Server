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
    public class ProductController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("Products_GetAll")]
        public IEnumerable<Product> GetAllAsync() => db.Products.ToList();

        [HttpGet]
        [Route("Products_Get/{guid}")]
        public Product GetAsync(Guid guid) => db.Products.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Product SaveAsync(Product cls)
        {
            try
            {
                var a = db.Products.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Products.Add(cls);
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
        [Route("Products_NextCode")]
        public string NextCodeAsync() => ((db.Products.Max(q => q.Code) + 1)).ToString();
    }
}
