using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class ContractFinanceBussines:IContractFinance
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public Guid ConGuid { get; set; }
        public EnContractBabat fBabat { get; set; }
        public EnContractBabat sBabat { get; set; }
        public decimal FirstDiscount { get; set; }
        public decimal SecondDiscount { get; set; }
        public decimal FirstAddedValue { get; set; }
        public decimal SecondAddedValue { get; set; }
        public decimal FirstTotalPrice { get; set; }
        public decimal SecondTotalPrice { get; set; }


        public static async Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.ContractFinance.GetAsync(parentGuid, status);
        public static ContractFinanceBussines Get(Guid parentGuid, bool status) =>
            AsyncContext.Run(() => GetAsync(parentGuid, status));
    }
}
