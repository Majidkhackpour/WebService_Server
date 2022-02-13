using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities.Building
{
    [Table("Buildings_BuildingNote")]
    public class BuildingNote : IBuildingNote
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingGuid { get; set; }
        public string Note { get; set; }
    }
}
