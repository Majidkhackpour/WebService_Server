using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Building;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class Reception 
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid Receptor { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal NaqdPrice { get; set; }
        public Guid NaqdSafeBoxGuid { get; set; }
        public decimal BankPrice { get; set; }
        public Guid BankSafeBoxGuid { get; set; }
        [MaxLength(100)]
        public string FishNo { get; set; }
        public decimal Check { get; set; }
        [MaxLength(100)]
        public string CheckNo { get; set; }
        [MaxLength(20)]
        public string SarResid { get; set; }
        [MaxLength(100)]
        public string BankName { get; set; }
        public Guid UserGuid { get; set; }
    }
}
