using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines.Building;

namespace EntityCache.Core.Building
{
    public interface IBuildingRelatedRegionsRepository:IRepository<BuildingRelatedRegionsBussines>
    {
        Task<List<BuildingRelatedRegionsBussines>> GetAllAsync(Guid parentGuid, bool status);
    }
}
