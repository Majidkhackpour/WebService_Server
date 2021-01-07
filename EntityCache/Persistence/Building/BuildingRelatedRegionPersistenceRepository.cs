using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;
using Services;

namespace EntityCache.Persistence.Building
{
    public class BuildingRelatedRegionPersistenceRepository:GenericRepository<BuildingRelatedRegionsBussines,BuildingRequestRegion>,IBuildingRelatedRegionsRepository
    {
        private ModelContext _db;
        public BuildingRelatedRegionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
        public async Task<List<BuildingRelatedRegionsBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = _db.BuildingRequestRegions.AsNoTracking()
                    .Where(q => q.RequestGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<BuildingRelatedRegionsBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
