using AutoMapper;
using EntityCache.Bussines;
using Persistence.Entities;

namespace EntityCache.Assistence
{
    public class SqlProfile : Profile
    {
        public SqlProfile()
        {
            CreateMap<CustomerBussines, Customers>().ReverseMap();
        }
    }
}
