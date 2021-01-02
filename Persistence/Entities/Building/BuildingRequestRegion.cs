using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    public class BuildingRequestRegion:IBuildingRequestRegion
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public string HardSerial { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
    }
}
