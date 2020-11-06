using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IProductRepository : IRepository<ProductBussines>
    {
        Task<string> NextCodeAsync();
    }
}
