using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities.Building
{
    [Table("Buildings_BuildingRelatedNumber")]
    public class BuildingRelatedNumber : IBuildingRelatedNumber
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public string Number { get; set; }
    }
}
