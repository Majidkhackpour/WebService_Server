using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class AndroidsBussines : IAndroids
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid CustomerGuid { get; set; }
        public string IMEI { get; set; }
        public string Name { get; set; }


        public static async Task<AndroidsBussines> GetAsync(string imei) => await UnitOfWork.Android.GetAsync(imei);
    }
}
