using System;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingConditionBussines:IBuildingCondition
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
    }
}
