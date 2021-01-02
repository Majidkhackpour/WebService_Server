using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingGalleryPersistenceRepository:GenericRepository<BuildingGalleryBussines,BuildingGallery>,IBuildingGalleryRepository
    {
        private ModelContext _db;
        public BuildingGalleryPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
