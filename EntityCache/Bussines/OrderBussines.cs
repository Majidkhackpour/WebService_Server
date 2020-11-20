using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class OrderBussines : IOrder
    {
        private List<OrderDetailBussines> _detList;
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string ContractCode { get; set; }
        public int LearningCount { get; set; }
        public decimal Sum { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public List<OrderDetailBussines> DetList
        {
            get
            {
                if (_detList == null)
                    _detList = OrderDetailBussines.GetAll(Guid);
                _detList = _detList.GroupBy(x => x.Guid)
                    .Select(x => x.First()).ToList();
                return _detList;
            }
            set => _detList = value;
        }


        public static async Task<List<OrderBussines>> GetAllAsync() => await UnitOfWork.Order.GetAllAsync();
        public static async Task<OrderBussines> GetAsync(Guid guid) => await UnitOfWork.Order.GetAsync(guid);
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

                var list = await OrderDetailBussines.GetAllAsync(Guid);
                if (list != null && list.Count > 0) await OrderDetailBussines.RemoveRangeAsync(list, tranName);

                if (DetList != null && DetList.Count > 0) await OrderDetailBussines.SaveRangeAsync(DetList, tranName);


                var cust = await CustomerBussines.GetAsync(CustomerGuid);
                if (cust != null)
                {
                    var order = await GetAsync(Guid);
                    if (order != null)
                    {
                        cust.Account -= order.Total;
                        cust.Account += Total;
                    }
                    else cust.Account += Total;

                    await cust.SaveAsync();
                }

                var log = await CustomerLogBussines.GetLogByParentAsync(Guid);
                var description =
                    $"فاکتور فروش به شماره {ContractCode} به مبلغ {Total:N0} در تاریخ {Calendar.MiladiToShamsi(Date)}";
                if (log == null)
                {
                    log = new CustomerLogBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Status = true,
                        CustomerGuid = CustomerGuid,
                        Modified = DateTime.Now,
                        Date = DateTime.Now,
                        Parent = Guid,
                        Side = EnCustomerLogType.Order
                    };
                }

                log.Price = Total;
                log.Description = description;

                await log.SaveAsync();


                res.AddReturnedValue(await UnitOfWork.Order.SaveAsync(this, tranName));
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
        public static OrderBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var list = await OrderDetailBussines.GetAllAsync(Guid);
                if (list != null && list.Count > 0) await OrderDetailBussines.RemoveRangeAsync(list, tranName);


                var cust = await CustomerBussines.GetAsync(CustomerGuid);
                if (cust != null)
                {
                    cust.Account -= Total;
                    await cust.SaveAsync();
                }

                var log = await CustomerLogBussines.GetLogByParentAsync(Guid);
                if (log != null) await log.RemoveAsync();

                res.AddReturnedValue(await UnitOfWork.Order.RemoveAsync(Guid, tranName));
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
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Order.NextCodeAsync();
    }
}
