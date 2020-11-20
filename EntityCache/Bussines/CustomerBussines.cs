using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class CustomerBussines : ICustomers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string NationalCode { get; set; }
        public string AppSerial { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Tell1 { get; set; }
        public string Tell2 { get; set; }
        public string Tell3 { get; set; }
        public string Tell4 { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid UserGuid { get; set; }
        public decimal Account { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SiteUrl { get; set; }
        public string HardSerial { get; set; }


        public static async Task<CustomerBussines> GetAsync(Guid guid) => await UnitOfWork.Customers.GetAsync(guid);
        public static CustomerBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<List<CustomerBussines>> GetAllAsync() => await UnitOfWork.Customers.GetAllAsync();
        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var obj = await GetAsync(Guid);
                var desc = "";
                if (obj == null) desc = $"ثبت {Name} به عنوان مشتری جدید";
                else
                {
                    if(Status) desc = $"ویرایش اطلاعات {Name}";
                    else desc = $"حذف اطلاعات {Name}";
                }

                var userLog = new UserLogBussines()
                {
                    Description = desc,
                    Type = EnLogType.Customers,
                    UserGuid = UserGuid
                };
                await userLog.SaveAsync();

                res.AddReturnedValue(await UnitOfWork.Customers.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Customers.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
