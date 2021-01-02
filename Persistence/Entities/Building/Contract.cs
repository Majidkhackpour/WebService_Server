using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    public class Contract:IContract
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public string HardSerial { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime DateM { get; set; }
        public long Code { get; set; }
        public bool IsTemp { get; set; }
        public Guid FirstSideGuid { get; set; }
        public Guid SecondSideGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Shobe { get; set; }
        public string SarResid { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public decimal SarQofli { get; set; }
        public decimal Delay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        public Guid BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
    }
}
