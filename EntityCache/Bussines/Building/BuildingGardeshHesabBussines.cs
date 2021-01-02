using System;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingGardeshHesabBussines:IGardeshHesab
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public Guid PeopleGuid { get; set; }
        public decimal Price { get; set; }
        public EnAccountType Type { get; set; }
        public EnAccountBabat Babat { get; set; }
        public string Description { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
