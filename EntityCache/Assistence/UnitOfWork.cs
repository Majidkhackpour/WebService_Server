using EntityCache.Core;
using EntityCache.Core.Building;
using EntityCache.Persistence;
using EntityCache.Persistence.Building;
using Persistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext();

        private static ICustomerRepository _customerRepository;
        private static ICustomerLogRepository _customerLogRepository;
        private static IOrderRepository _orderRepository;
        private static IOrderDetailRepository _orderDetRepository;
        private static IProductRepository _productRepository;
        private static IReceptionRepository _receptionRepository;
        private static ISafeBoxRepository _safeBoxRepository;
        private static ISmsLogRepository _smsLogRepository;
        private static ISmsPanelRepository _smsPanelRepository;
        private static IUserRepository _userRepository;
        private static IUserLogRepository _userLogRepository;
        private static IPardakhtRepository _pardakhtRepository;
        private static IErrorLogRepository _errorLogRepository;
        private static IStateRepository _stateRepository;
        private static ICitiesRepository _cityRepository;
        private static IRegionRepository _regionRepository;
        private static IBuildingUsersRepository _buildingUserRepository;
        private static IPeopleGroupRepository _peopleGroupRepository;
        private static IPeoplesRepository _peopleRepository;
        private static IHazineRepository _hazineRepository;
        private static IBuildingAccountTypeRepository _accTypeRepository;
        private static IBuildingConditionRepository _conditionRepository;
        private static IBuildingTypeRepository _typeRepository;
        private static IBuildingViewRepository _viewRepository;
        private static IDocumentTypeRepository _docTypeRepository;
        private static IFloorCoverRepository _floorCoverRepository;
        private static IKitchenServiceRepository _kitchenServiceRepository;
        private static IRentalAuthorityRepository _rentalRepository;
        private static IBuildingRepository _buildingRepository;
        private static IBuildingGalleryRepository _galleryRepository;
        private static IBuildingRelatedOptionsRepository _relatedOptionRepository;
        private static IBuildingRequestRepository _requestRepository;
        private static IBuildingRelatedRegionsRepository _relatedRegionRepository;
        private static IContractRepository _contractRepository;
        private static IContractFinanceRepository _financeRepository;
        private static IBuildingReceptionRepository _buildingReceptionRepository;
        private static IBuildingPardakhtRepository _buildingPardakhtRepository;
        private static IBuildingGardeshHesabRepository _buildingGardeshRepository;
        private static ISyncedDataRepository _syncedDataRepository;
        private static IAndroidsRepository _androidRepository;


        public static void Dispose() => db?.Dispose();
        public static void Set_Save() => db.SaveChanges();


        public static ICustomerRepository Customers => _customerRepository ??
                                                (_customerRepository =
                                                    new CustomerPersistenceRepository(db));


        public static ICustomerLogRepository CustomersLog => _customerLogRepository ??
                                                       (_customerLogRepository =
                                                           new CustomerLogPersistenceRepository(db));


        public static IOrderRepository Order => _orderRepository ??
                                                             (_orderRepository =
                                                                 new OrderPersistenceRepository(db));


        public static IOrderDetailRepository OrderDetail => _orderDetRepository ??
                                                (_orderDetRepository =
                                                    new OrderDetailPersistenceRepository(db));


        public static IProductRepository Product => _productRepository ??
                                                            (_productRepository =
                                                                new ProductPersistenceRepository(db));


        public static IReceptionRepository Reception => _receptionRepository ??
                                                    (_receptionRepository =
                                                        new ReceptionPersistenceRepository(db));


        public static ISafeBoxRepository SafeBox => _safeBoxRepository ??
                                                        (_safeBoxRepository =
                                                            new SafeBoxPersistenceRepository(db));


        public static ISmsLogRepository SmsLog => _smsLogRepository ??
                                                    (_smsLogRepository =
                                                        new SmsLogPersistenceRepository(db));


        public static ISmsPanelRepository SmsPanel => _smsPanelRepository ??
                                                  (_smsPanelRepository =
                                                      new SmsPanelPersistenceRepository(db));


        public static IUserRepository User => _userRepository ??
                                                  (_userRepository =
                                                      new UserPersistenceRepository(db));


        public static IUserLogRepository UserLog => _userLogRepository ??
                                                      (_userLogRepository =
                                                          new UserLogPersistenceRepository(db));


        public static IPardakhtRepository Pardakht => _pardakhtRepository ??
                                                    (_pardakhtRepository =
                                                        new PardakhtPersistenceRepository(db));


        public static IErrorLogRepository ErrorLog => _errorLogRepository ??
                                                      (_errorLogRepository =
                                                          new ErrorLogPersistenceRepository(db));



        public static IStateRepository State => _stateRepository ??
                                                      (_stateRepository =
                                                          new StatePersistenceRepository(db));


        public static ICitiesRepository City => _cityRepository ??
                                                      (_cityRepository =
                                                          new CitiesPersistenceRepository(db));


        public static IRegionRepository Region => _regionRepository ??
                                                      (_regionRepository =
                                                          new RegionPersistenceRepository(db));


        public static IBuildingUsersRepository BuildingUser => _buildingUserRepository ??
                                                      (_buildingUserRepository =
                                                          new BuildingUserPersistenceRepository(db));


        public static IPeopleGroupRepository PeopleGroup => _peopleGroupRepository ??
                                                      (_peopleGroupRepository =
                                                          new PeopleGroupPersistenceRepository(db));


        public static IPeoplesRepository People => _peopleRepository ??
                                                      (_peopleRepository =
                                                          new PeoplePersistenceRepository(db));


        public static IHazineRepository Hazine => _hazineRepository ??
                                                      (_hazineRepository =
                                                          new HazinePersistenceRepository(db));


        public static IBuildingAccountTypeRepository BuildingAccountType => _accTypeRepository ??
                                                      (_accTypeRepository =
                                                          new BuildingAccountTypePersistenceRepository(db));


        public static IBuildingConditionRepository BuildingCondition => _conditionRepository ??
                                                      (_conditionRepository =
                                                          new BuildingConditionPersistenceRepository(db));


        public static IBuildingTypeRepository BuildingType => _typeRepository ??
                                                      (_typeRepository =
                                                          new BuildingTypePersistenceRepository(db));


        public static IBuildingViewRepository BuildingView => _viewRepository ??
                                                      (_viewRepository =
                                                          new BuildingViewPersistenceRepository(db));


        public static IDocumentTypeRepository DocumentType => _docTypeRepository ??
                                                      (_docTypeRepository =
                                                          new DocumentTypePersistenceRepository(db));


        public static IFloorCoverRepository FloorCover => _floorCoverRepository ??
                                                      (_floorCoverRepository =
                                                          new FloorCoverPersistenceRepository(db));


        public static IKitchenServiceRepository KitchenService => _kitchenServiceRepository ??
                                                      (_kitchenServiceRepository =
                                                          new KitchenServicePersistenceRepository(db));


        public static IRentalAuthorityRepository RentalAuthority => _rentalRepository ??
                                                      (_rentalRepository =
                                                          new RentalAuthorityPersistenceRepository(db));


        public static IBuildingRepository Building => _buildingRepository ??
                                                      (_buildingRepository =
                                                          new BuildingPersistenceRepository(db));


        public static IBuildingGalleryRepository BuildingGallery => _galleryRepository ??
                                                      (_galleryRepository =
                                                          new BuildingGalleryPersistenceRepository(db));


        public static IBuildingRelatedOptionsRepository BuildingRelatedOptions => _relatedOptionRepository ??
                                                      (_relatedOptionRepository =
                                                          new BuildingRelatedOptionPersistenceRepository(db));


        public static IBuildingRequestRepository BuildingRequest => _requestRepository ??
                                                      (_requestRepository =
                                                          new BuildingRequestPersistenceRepository(db));


        public static IBuildingRelatedRegionsRepository BuildingRelatedRegions => _relatedRegionRepository ??
                                                      (_relatedRegionRepository =
                                                          new BuildingRelatedRegionPersistenceRepository(db));



        public static IContractRepository Contract => _contractRepository ??
                                                      (_contractRepository =
                                                          new ContractPersistenceRepository(db));


        public static IContractFinanceRepository ContractFinance => _financeRepository ??
                                                      (_financeRepository =
                                                          new ContractFinancePersistenceRepository(db));


        public static IBuildingReceptionRepository BuildingReception => _buildingReceptionRepository ??
                                                      (_buildingReceptionRepository =
                                                          new BuildingReceptionPersistenceRepository(db));


        public static IBuildingPardakhtRepository BuildingPardakht => _buildingPardakhtRepository ??
                                                      (_buildingPardakhtRepository =
                                                          new BuildingPardakhtPersistenceRepository(db));


        public static IBuildingGardeshHesabRepository BuildingGardeshHesab => _buildingGardeshRepository ??
                                                      (_buildingGardeshRepository =
                                                          new BuildingGardeshHesabPersistenceRepository(db));


        public static ISyncedDataRepository SyncedData => _syncedDataRepository ??
                                                                              (_syncedDataRepository =
                                                                                  new SyncedDataPersistenceRepository(db));


        public static IAndroidsRepository Android => _androidRepository ??
                                                          (_androidRepository =
                                                              new AndroidPersistenceRepository(db));
    }
}
