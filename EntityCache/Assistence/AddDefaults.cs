using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Persistence;
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
            var res = new ReturnedSaveFuncInfo();

            #region Users

            var allusers = await UserBussines.GetAllAsync();
            var access = new AccessLevel();
            if (allusers == null || allusers.Count <= 0)
            {
                var user = new UserBussines()
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
                res.AddReturnedValue(await user.SaveAsync());
                res.ThrowExceptionIfError();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
