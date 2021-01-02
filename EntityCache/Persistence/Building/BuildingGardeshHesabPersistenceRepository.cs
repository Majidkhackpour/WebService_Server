using System.Diagnostics;
using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingGardeshHesabPersistenceRepository:GenericRepository<BuildingGardeshHesabBussines,BuildingGardeshHesab>,IBuildingGardeshHesabRepository
    {
        private ModelContext _db;
        public BuildingGardeshHesabPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
