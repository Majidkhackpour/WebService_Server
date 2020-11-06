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
            CreateMap<CustomerLogBussines, CustomerLog>().ReverseMap();
            CreateMap<OrderBussines, Order>().ReverseMap();
            CreateMap<OrderDetailBussines, OrderDetails>().ReverseMap();
            CreateMap<ProductBussines, Product>().ReverseMap();
            CreateMap<ReceptionBussines, Reception>().ReverseMap();
            CreateMap<SafeBoxBussines, SafeBox>().ReverseMap();
            CreateMap<SmsLogBussines, SmsLog>().ReverseMap();
            CreateMap<SmsPanelsBussines, SmsPanels>().ReverseMap();
            CreateMap<UserBussines, Users>().ReverseMap();
            CreateMap<UserLogBussines, UserLog>().ReverseMap();
        }
    }
}
