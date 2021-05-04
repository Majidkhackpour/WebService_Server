using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Persistence.Entities;
using Persistence.Model;
using Services;
using Services.Access;

namespace EntityCache.Assistence
{
    public class AddDefaults
    {
        public static async Task InsertDefaultDataAsync()
        {
            var dbContext = new ModelContext();

            #region Users

            var allusers = dbContext.Users.ToList();
            var access = new AccessLevel();
            if (allusers == null || allusers.Count <= 0)
            {
                var user = new Users()
                {
                    Guid = Guid.NewGuid(),
                    Name = "کاربر پیش فرض",
                    UserName = "Admin",
                    IsBlock = false,
                    Email = "Arad_enj@yahoo.com",
                    Mobile = "09382420272",
                    Type = EnUserType.Manager,
                    Status = true
                };
                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes("2211");
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                user.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
