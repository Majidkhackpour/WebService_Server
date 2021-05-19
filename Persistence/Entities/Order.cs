using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_Order")]
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
        public decimal Sum { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
