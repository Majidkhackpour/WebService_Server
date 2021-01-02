using System;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingRelatedOptionsBussines:IBuildingRelatedOptions
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
    }
}
