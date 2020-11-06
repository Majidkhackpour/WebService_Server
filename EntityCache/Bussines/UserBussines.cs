using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class UserBussines : IUsers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = false;
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsBlock { get; set; }
        public EnUserType Type { get; set; }


        public static async Task<UserBussines> GetAsync(Guid guid) => await UnitOfWork.User.GetAsync(guid);
        public static UserBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<List<UserBussines>> GetAllAsync() => await UnitOfWork.User.GetAllAsync();
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

                res.AddReturnedValue(await UnitOfWork.User.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.User.ChangeStatusAsync(this, status, tranName));
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
        public static async Task<UserBussines> GetAsync(string userName) => await UnitOfWork.User.GetAsync(userName);
        public static async Task<bool> CheckUserNameAsync(Guid guid, string userName) => await UnitOfWork.User.CheckUserNameAsync(guid, userName);
    }
}
