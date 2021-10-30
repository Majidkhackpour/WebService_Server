using Servicess.Interfaces.Department;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    [Table("Department_OrderDetail")]
    public class OrderDetails : IOrderDetail
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid PrdGuid { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
