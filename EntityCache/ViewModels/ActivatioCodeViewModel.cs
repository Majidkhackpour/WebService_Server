using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.ViewModels
{
    public class ActivatioCodeViewModel
    {
        public Guid CustomerGuid { get; set; }
        public string AppSerial { get; set; }
        public string HardSerial { get; set; }
        public string CustomerName { get; set; }
        public string ExpireDateSh { get; set; }
        public int Term { get; set; } = 12;
        public string Description { get; set; } = "";
        public string ActivationCode { get; set; } = "";

        public static async Task<ActivatioCodeViewModel> GenerateAsync(Guid cusGuid)
        {
            var item = new ActivatioCodeViewModel();
            try
            {
                var customer = await CustomerBussines.GetAsync(cusGuid);
                if (customer == null || customer.Guid == Guid.Empty) return item;
                item.CustomerGuid = customer.Guid;
                item.CustomerName = customer.Name;
                item.AppSerial = customer.AppSerial;
                item.HardSerial = customer.HardSerial;
                item.ExpireDateSh = customer.ExpireDateSh;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
    }
}
