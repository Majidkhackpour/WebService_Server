using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IAndroidsRepository : IRepository<AndroidsBussines>
    {
        Task<AndroidsBussines> GetAsync(string imei);
    }
}
