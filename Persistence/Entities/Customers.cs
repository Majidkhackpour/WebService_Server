using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class Customers : ICustomers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string NationalCode { get; set; }
        [MaxLength(100)]
        public string AppSerial { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string Tell1 { get; set; }
        [MaxLength(50)]
        public string Tell2 { get; set; }
        [MaxLength(50)]
        public string Tell3 { get; set; }
        [MaxLength(50)]
        public string Tell4 { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid UserGuid { get; set; }
        public decimal Account { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string SiteUrl { get; set; }
        [MaxLength(100)]
        public string HardSerial { get; set; }
    }
}
