using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_Customers")]
    public class Customers : ICustomers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        [Display(Name = "عنوان")]
        [MaxLength(500)]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Name { get; set; }
        [Display(Name = "نام مجموعه")]
        [MaxLength(500)]
        public string CompanyName { get; set; }
        [Display(Name = "کد ملی")]
        [MaxLength(50)]
        public string NationalCode { get; set; }
        [Display(Name = "سریال نرم افزار")]
        [MaxLength(100)]
        public string AppSerial { get; set; }
        [Display(Name = "آدرس")]
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string PostalCode { get; set; }
        [Display(Name = "تلفن 1")]
        [MaxLength(50)]
        public string Tell1 { get; set; }
        [Display(Name = "تلفن 2")]
        [MaxLength(50)]
        public string Tell2 { get; set; }
        [Display(Name = "تلفن 3")]
        [MaxLength(50)]
        public string Tell3 { get; set; }
        [Display(Name = "تلفن 4")]
        [MaxLength(50)]
        public string Tell4 { get; set; }
        [Display(Name = "پست الکترونیک")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid UserGuid { get; set; }
        public decimal Account { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [Display(Name = "آدرس سایت")]
        [MaxLength(50)]
        public string SiteUrl { get; set; }
        [Display(Name = "مشخصه فنی")]
        [MaxLength(100)]
        public string HardSerial { get; set; }
        [MaxLength(500)]
        public string LkSerial { get; set; }
        public bool isBlock { get; set; }
        public bool isWebServiceBlock { get; set; }
    }
}
