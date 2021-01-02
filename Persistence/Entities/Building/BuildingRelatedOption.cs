using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    public class BuildingRelatedOption : IBuildingRelatedOptions
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public string HardSerial { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
    }
}
