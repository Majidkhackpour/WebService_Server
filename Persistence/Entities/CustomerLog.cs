using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class CustomerLog : ICustomerLog
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        [MaxLength(100)]
        public string SideName { get; set; }
        public string Description { get; set; }
    }
}
