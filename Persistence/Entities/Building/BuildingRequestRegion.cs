using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    [Table("Buildings_BuildingRequestRegions")]
    public class BuildingRequestRegion:IBuildingRequestRegion
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public DateTime Modified { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
    }
}
