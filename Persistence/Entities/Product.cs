using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_Product")]
    public class Product : IProduct
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        public decimal Price { get; set; }
        public decimal BckUpPrice { get; set; }
    }
}
