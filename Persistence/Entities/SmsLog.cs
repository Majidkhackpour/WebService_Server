using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_SmsLog")]
    public class SmsLog : ISmsLog
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid UserGuid { get; set; }
        [MaxLength(100)]
        public string Sender { get; set; }
        [MaxLength(100)]
        public string Reciver { get; set; }
        public string Message { get; set; }
        public decimal Cost { get; set; }
        public long MessageId { get; set; }
        [MaxLength(100)]
        public string StatusText { get; set; }
    }
}
