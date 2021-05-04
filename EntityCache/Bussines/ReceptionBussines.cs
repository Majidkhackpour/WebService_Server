//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using EntityCache.Assistence;
//using Nito.AsyncEx;
//using Services;
//using Servicess.Interfaces.Building;

//namespace EntityCache.Bussines
//{
//    public class ReceptionBussines : IReception
//    {
//        public Guid Guid { get; set; }
//        public DateTime Modified { get; set; }
//        public bool Status { get; set; }
//        public Guid Receptor { get; set; }
//        public DateTime CreateDate { get; set; }
//        public string Description { get; set; }
//        public decimal NaqdPrice { get; set; }
//        public Guid NaqdSafeBoxGuid { get; set; }
//        public decimal BankPrice { get; set; }
//        public Guid BankSafeBoxGuid { get; set; }
//        public string FishNo { get; set; }
//        public decimal Check { get; set; }
//        public string CheckNo { get; set; }
//        public string SarResid { get; set; }
//        public string BankName { get; set; }
//        public Guid UserGuid { get; set; }
//        public decimal TotalPrice => NaqdPrice + BankPrice + Check;



//        public static async Task<List<ReceptionBussines>> GetAllAsync() => await UnitOfWork.Reception.GetAllAsync();
//        public static async Task<List<ReceptionBussines>> GetAllAsync(Guid receptioGuid) =>
//            await UnitOfWork.Reception.GetAllAsync(receptioGuid);
//        public static async Task<ReceptionBussines> GetAsync(Guid guid) => await UnitOfWork.Reception.GetAsync(guid);
//        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
//        {
//            var res = new ReturnedSaveFuncInfo();
//            var autoTran = string.IsNullOrEmpty(tranName);
//            if (autoTran) tranName = Guid.NewGuid().ToString();
//            try
//            {
//                if (autoTran)
//                { //BeginTransaction
//                }


//                var obj = await GetAsync(Guid);
//                var desc_ = "";
//                if (obj == null) desc_ = $"ثبت دریافت جدید به مبلغ {TotalPrice:N0}";
//                else desc_ = $"ویرایش اطلاعات دریافت";

//                var userLog = new UserLogBussines()
//                {
//                    Description = desc_,
//                    Type = EnLogType.Reception,
//                    UserGuid = UserGuid
//                };
//                await userLog.SaveAsync();

//                var log = await CustomerLogBussines.GetLogByParentAsync(Guid);
//                var desc = $"دریافت مبلغ {TotalPrice:N0} ریال در تاریخ {Calendar.MiladiToShamsi(CreateDate)} {Description}";
//                if (log == null)
//                {
//                    log = new CustomerLogBussines()
//                    {
//                        Guid = Guid.NewGuid(),
//                        Modified = DateTime.Now,
//                        Status = true,
//                        Date = DateTime.Now,
//                        Side = EnCustomerLogType.Receptipn,
//                        CustomerGuid = Receptor,
//                        Parent = Guid
//                    };

//                }

//                var fPrice = log.Price;

//                log.Description = desc;
//                log.Price = TotalPrice;
//                await log.SaveAsync();

//                var pe = await CustomerBussines.GetAsync(Receptor);
//                if (pe != null)
//                {
//                    pe.Account += fPrice;
//                    pe.Account -= TotalPrice;
//                    await pe.SaveAsync();
//                }

                

//                res.AddReturnedValue(await UnitOfWork.Reception.SaveAsync(this, tranName));
//                res.ThrowExceptionIfError();
//                if (autoTran)
//                {
//                    //CommitTransAction
//                }
//            }
//            catch (Exception ex)
//            {
//                if (autoTran)
//                {
//                    //RollBackTransAction
//                }
//                WebErrorLog.ErrorInstence.StartErrorLog(ex);
//                res.AddReturnedValue(ex);
//            }

//            return res;
//        }
//        public static ReceptionBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
//        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
//        {
//            var res = new ReturnedSaveFuncInfo();
//            var autoTran = string.IsNullOrEmpty(tranName);
//            if (autoTran) tranName = Guid.NewGuid().ToString();
//            try
//            {
//                if (autoTran)
//                { //BeginTransaction
//                }


//                var userLog = new UserLogBussines()
//                {
//                    Description = $"ثبت دریافت جدید به مبلغ {TotalPrice:N0}",
//                    Type = EnLogType.Reception,
//                    UserGuid = UserGuid
//                };
//                await userLog.SaveAsync();

//                var cust = await CustomerBussines.GetAsync(Receptor);
//                if (cust != null)
//                {
//                    cust.Account += TotalPrice;
//                    await cust.SaveAsync();
//                }

//                var log = await CustomerLogBussines.GetLogByParentAsync(Guid);
//                if (log != null)  await log.RemoveAsync();

//                res.AddReturnedValue(await UnitOfWork.Reception.RemoveAsync(Guid, tranName));
//                res.ThrowExceptionIfError();
//                if (autoTran)
//                {
//                    //CommitTransAction
//                }
//            }
//            catch (Exception ex)
//            {
//                if (autoTran)
//                {
//                    //RollBackTransAction
//                }
//                WebErrorLog.ErrorInstence.StartErrorLog(ex);
//                res.AddReturnedValue(ex);
//            }

//            return res;
//        }
//    }
//}
