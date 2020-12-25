using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ICustomerRepository : IRepository<CustomerBussines>
    {
        Task<CustomerBussines> GetAsync(string name);
        Task<CustomerBussines> GetByHardSerialAsync(string hSerial);
    }
}
