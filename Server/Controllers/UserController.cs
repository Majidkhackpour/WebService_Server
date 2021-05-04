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
    public class UserController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("Users_GetAll")]
        public IEnumerable<Users> GetAllAsync() => db.Users.ToList();

        [HttpGet]
        [Route("Users_Get/{guid}")]
        public Users GetAsync(Guid guid) => db.Users.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Users SaveAsync(Users cls)
        {
            try
            {
                var a = db.Users.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Users.Add(cls);
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
        [Route("Users_CheckUserName/{guid},{userName}")]
        public bool CheckUserNameAsync(Guid guid, string userName)
        {
            try
            {
                var acc = db.Users.AsNoTracking()
                    .Where(q => q.UserName == userName && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        [HttpGet]
        [Route("User_Get/{userName}")]
        public Users GetAsync(string userName) => db.Users.FirstOrDefault(q => q.UserName == userName);
    }
}
