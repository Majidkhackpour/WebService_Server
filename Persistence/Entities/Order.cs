using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class Order : IOrder
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid UserGuid { get; set; }
        [MaxLength(50)]
        public string ContractCode { get; set; }
        [MaxLength(50)]
        public string Version { get; set; }
        public int LearningCount { get; set; }
        public decimal Sum { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
