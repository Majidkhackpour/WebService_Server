using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISmsPanelRepository : IRepository<SmsPanelsBussines>
    {
        Task<SmsPanelsBussines> GetCurrentAsync();
    }
}
