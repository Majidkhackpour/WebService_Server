using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    [Table("Department_Pardakht")]
    public class Pardakht 
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid Payer { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal NaqdPrice { get; set; }
        public Guid NaqdSafeBoxGuid { get; set; }
        public Guid BankSafeBoxGuid { get; set; }
        public decimal BankPrice { get; set; }
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
