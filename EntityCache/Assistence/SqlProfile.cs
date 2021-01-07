using AutoMapper;
using EntityCache.Bussines;
using EntityCache.Bussines.Building;
using Persistence.Entities;
using Persistence.Entities.Building;

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
            CreateMap<PardakhtBussines, Pardakht>().ReverseMap();
            CreateMap<ErrorLogBussines, ErrorLog>().ReverseMap();
            CreateMap<StateBussines, States>().ReverseMap();
            CreateMap<CitiesBussiness, Cities>().ReverseMap();
            CreateMap<RegionBussines, Regions>().ReverseMap();
            CreateMap<BuildingUserBussines, BuildingUsers>().ReverseMap();
            CreateMap<PeopleGroupBussines, PeopleGroup>().ReverseMap();
            CreateMap<PeopleBussines, Peoples>().ReverseMap();
            CreateMap<HazineBussines, Hazine>().ReverseMap();
            CreateMap<BuildingAccountTypeBussines, BuildingAccountType>().ReverseMap();
            CreateMap<BuildingConditionBussines, BuildingCondition>().ReverseMap();
            CreateMap<BuildingTypeBussines, BuildingType>().ReverseMap();
            CreateMap<BuildingViewBussines, BuildingView>().ReverseMap();
            CreateMap<DocumentTypeBussines, DocumentType>().ReverseMap();
            CreateMap<FloorCoverBussines, FloorCover>().ReverseMap();
            CreateMap<KitchenServiceBussines, KitchenService>().ReverseMap();
            CreateMap<RentalAuthorityBussines, RentalAuthority>().ReverseMap();
            CreateMap<BuildingBusines, Building>().ReverseMap();
            CreateMap<BuildingGalleryBussines, BuildingGallery>().ReverseMap();
            CreateMap<BuildingRelatedOptionsBussines, BuildingRelatedOption>().ReverseMap();
            CreateMap<BuildingRequestBussines, BuildingRequest>().ReverseMap();
            CreateMap<BuildingRelatedRegionsBussines, BuildingRequestRegion>().ReverseMap();
            CreateMap<ContractBussines, Contract>().ReverseMap();
            CreateMap<ContractFinanceBussines, ContractFinance>().ReverseMap();
            CreateMap<BuildingReceptionBussines, BuildingReception>().ReverseMap();
            CreateMap<BuildingPardakhtBussines, BuildingPardakht>().ReverseMap();
            CreateMap<BuildingGardeshHesabBussines, BuildingGardeshHesab>().ReverseMap();
            CreateMap<SyncedDataBussines, SyncedData>().ReverseMap();
            CreateMap<AndroidsBussines, Androids>().ReverseMap();
            CreateMap<BuildingOptionBussines, BuildingOptions>().ReverseMap();
            CreateMap<BuildingPhoneBookBussines, BuildingPhoneBook>().ReverseMap();
        }
    }
}
