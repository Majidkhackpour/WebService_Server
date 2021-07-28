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
                    Guid = Guid.Parse("34593FF9-606D-4CFA-8B3C-1A2919BF11FF"),
                    Name = "کاربر پیش فرض",
                    UserName = "Admin",
                    IsBlock = false,
                    Email = "Arad_enj@yahoo.com",
                    Mobile = "09382420272",
                    Type = EnUserType.Manager,
                    Status = true,
                    Modified = DateTime.Now
                };
                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes("2211");
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                user.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                dbContext.Users.Add(user);
            }
            #endregion

            #region Products
            var allKol = dbContext.Products.ToList();
            if (allKol == null || allKol.Count <= 0)
            {
                var kol = DefaultProducts.SetDef();
                foreach (var prd in kol)
                    dbContext.Products.Add(prd);
            }
            #endregion

            #region Customer
            var allCus = dbContext.Customers.ToList();
            if (allCus == null || allCus.Count <= 0)
            {
                var prd = new Customers()
                {
                    Guid = Guid.NewGuid(),
                    HardSerial = "265155255",
                    Modified = DateTime.Now,
                    Address = "مشهد- محمدیه 5/5- پلاک9",
                    Name = "مجید خاکپور",
                    Status = true,
                    UserGuid = Guid.Parse("34593FF9-606D-4CFA-8B3C-1A2919BF11FF"),
                    CreateDate = DateTime.Now,
                    UserName = "",
                    Description = "",
                    Account = 0,
                    AppSerial = "7225368797445068625332",
                    CompanyName = "املاک آراد",
                    Email = "arad_enj@yahoo.com",
                    ExpireDate = new DateTime(2022, 05, 05, 20, 26, 17),
                    LkSerial = "",
                    NationalCode = "0860439021",
                    Password = "",
                    PostalCode = "",
                    SiteUrl = "",
                    Tell1 = "09382420272",
                    Tell2 = "09011804993",
                    Tell3 = "09154751439",
                    Tell4 = "",
                    isBlock = false,
                    isWebServiceBlock = false
                };
                var prd_ = new Androids()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Name = "Emulator A50",
                    CustomerGuid = prd.Guid,
                    IMEI = "7e8a55a609e7ec3f"
                };
                dbContext.Customers.Add(prd);
                dbContext.Androids.Add(prd_);
            }
            #endregion

            #region Users

            var allPanels = dbContext.SmsPanels.ToList();
            if (allPanels == null || allPanels.Count <= 0)
            {
                var prd = new SmsPanels()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Name = "SmsSender",
                    IsCurrent = true,
                    API = "38782F7144637944703643765069305A514C796B5A413D3D",
                    Sender = "10000100007766"
                };
                dbContext.SmsPanels.Add(prd);
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
