using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingUserPersistenceRepository:GenericRepository<BuildingUserBussines,BuildingUsers>,IBuildingUsersRepository
    {
        private ModelContext _db;
        public BuildingUserPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
