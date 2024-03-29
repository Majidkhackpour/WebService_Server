﻿//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Threading.Tasks;
//using EntityCache.Assistence;
//using Nito.AsyncEx;
//using Services;
//using Servicess.Interfaces.Building;

//namespace EntityCache.Bussines
//{
//    public class PardakhtBussines:IPardakht
//    {
//        public Guid Guid { get; set; }
//        public DateTime Modified { get; set; }
//        public bool Status { get; set; }
//        public Guid Payer { get; set; }
//        public DateTime CreateDate { get; set; }
//        public string Description { get; set; }
//        public decimal NaqdPrice { get; set; }
//        public Guid NaqdSafeBoxGuid { get; set; }
//        public Guid BankSafeBoxGuid { get; set; }
//        public decimal BankPrice { get; set; }
//        public string FishNo { get; set; }
//        public decimal Check { get; set; }
//        public string CheckNo { get; set; }
//        public string SarResid { get; set; }
//        public string BankName { get; set; }
//        public Guid UserGuid { get; set; }
//        public decimal TotalPrice => NaqdPrice + BankPrice + Check;




//        public static async Task<List<PardakhtBussines>> GetAllAsync() => await UnitOfWork.Pardakht.GetAllAsync();
//        public static async Task<List<PardakhtBussines>> GetAllAsync(Guid receptioGuid) =>
//            await UnitOfWork.Pardakht.GetAllAsync(receptioGuid);
//        public static async Task<PardakhtBussines> GetAsync(Guid guid) => await UnitOfWork.Pardakht.GetAsync(guid);
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
//                if (obj == null) desc_ = $"ثبت پرداخت جدید به مبلغ {TotalPrice:N0}";
//                else desc_ = $"ویرایش اطلاعات پرداخت";

//                var userLog = new UserLogBussines()
//                {
//                    Description = desc_,
//                    Type = EnLogType.Pardakht,
//                    UserGuid = UserGuid
//                };
//                await userLog.SaveAsync();


//                var log = await CustomerLogBussines.GetLogByParentAsync(Guid);
//                var desc = $"پرداخت مبلغ {TotalPrice:N0} ریال در تاریخ {Calendar.MiladiToShamsi(CreateDate)} {Description}";
//                if (log == null)
//                {
//                    log = new CustomerLogBussines()
//                    {
//                        Guid = Guid.NewGuid(),
//                        Modified = DateTime.Now,
//                        Status = true,
//                        Date = DateTime.Now,
//                        Side = EnCustomerLogType.Pardakht,
//                        CustomerGuid = Payer,
//                        Parent = Guid
//                    };

//                }
//                var fPrice = log.Price;
//                log.Price = TotalPrice;
//                log.Description = desc;

//                await log.SaveAsync();


//                var pe = await CustomerBussines.GetAsync(Payer);
//                if (pe != null)
//                {
//                    pe.Account -= fPrice;
//                    pe.Account += TotalPrice;
//                    await pe.SaveAsync();
//                }



//                res.AddReturnedValue(await UnitOfWork.Pardakht.SaveAsync(this, tranName));
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
//        public static PardakhtBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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
//                    Description = $"ثبت پرداخت جدید به مبلغ {TotalPrice:N0}",
//                    Type = EnLogType.Pardakht,
//                    UserGuid = UserGuid
//                };
//                await userLog.SaveAsync();


//                var cust = await CustomerBussines.GetAsync(Payer);
//                if (cust != null)
//                {
//                    cust.Account -= TotalPrice;
//                    await cust.SaveAsync();
//                }

//                var log = await CustomerLogBussines.GetLogByParentAsync(Guid);
//                if (log != null) await log.RemoveAsync();

//                res.AddReturnedValue(await UnitOfWork.Pardakht.RemoveAsync(Guid, tranName));
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
