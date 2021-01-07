using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingPhoneBookPersistenceRepository : GenericRepository<BuildingPhoneBookBussines, BuildingPhoneBook>, IBuildingPhoneBookRepository
    {
        private ModelContext _db;
        public BuildingPhoneBookPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
