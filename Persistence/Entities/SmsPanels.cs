using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    [Table("Department_SmsPanel")]
    public class SmsPanels : ISmsPanels
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Sender { get; set; }
        [MaxLength(500)]
        public string API { get; set; }
        public bool IsCurrent { get; set; }
    }
}
