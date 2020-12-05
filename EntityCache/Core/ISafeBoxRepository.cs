using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISafeBoxRepository : IRepository<SafeBoxBussines>
    {
        Task<SafeBoxBussines> GetAsync(string name);
    }
}
