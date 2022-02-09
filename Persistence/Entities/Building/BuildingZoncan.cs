using Services;
using Services.Interfaces.Building;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities.Building
{
    [Table("Buildings_BuildingZoncan")]
    public class BuildingZoncan : IBuildingZoncan
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
    }
}
