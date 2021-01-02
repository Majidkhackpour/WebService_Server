using System;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingRelatedRegionsBussines:IBuildingRequestRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
    }
}
