using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    public class BuildingReception:IReception
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public string HardSerial { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid Receptor { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal NaqdPrice { get; set; }
        public decimal BankPrice { get; set; }
        public string FishNo { get; set; }
        public decimal Check { get; set; }
        public string CheckNo { get; set; }
        public string SarResid { get; set; }
        public string BankName { get; set; }
    }
}
