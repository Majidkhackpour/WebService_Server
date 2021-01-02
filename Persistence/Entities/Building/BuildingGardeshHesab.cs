using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    public class BuildingGardeshHesab : IGardeshHesab
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public string HardSerial { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid PeopleGuid { get; set; }
        public decimal Price { get; set; }
        public EnAccountType Type { get; set; }
        public EnAccountBabat Babat { get; set; }
        public string Description { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
