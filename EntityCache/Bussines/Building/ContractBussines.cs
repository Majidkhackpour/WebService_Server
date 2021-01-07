using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class ContractBussines:IContract
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public DateTime DateM { get; set; }
        public long Code { get; set; }
        public bool IsTemp { get; set; }
        public Guid FirstSideGuid { get; set; }
        public Guid SecondSideGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Shobe { get; set; }
        public string SarResid { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public decimal SarQofli { get; set; }
        public decimal Delay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        public Guid BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
        private ContractFinanceBussines _finance;
        public ContractFinanceBussines Finance
        {
            get
            {
                if (_finance != null) return _finance;
                _finance = ContractFinanceBussines.Get(Guid, Status);
                return _finance;
            }
            set => _finance = value;
        }



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
                if (Finance != null)
                {
                    var list = await ContractFinanceBussines.GetAsync(Guid, Status);
                    if (list != null)
                    {
                        res.AddReturnedValue(
                            await UnitOfWork.ContractFinance.RemoveAsync(list.Guid,
                                tranName));
                        res.ThrowExceptionIfError();
                    }

                    Finance.HardSerial = HardSerial;
                    res.AddReturnedValue(
                        await UnitOfWork.ContractFinance.SaveAsync(Finance, tranName));
                    res.ThrowExceptionIfError();
                }
                res.AddReturnedValue(await UnitOfWork.Contract.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                var temp = new SyncedDataBussines()
                {
                    HardSerial = HardSerial,
                    ObjectGuid = Guid,
                    Type = EnTemp.Contract
                };
                res.AddReturnedValue(await temp.SaveAsync());
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
