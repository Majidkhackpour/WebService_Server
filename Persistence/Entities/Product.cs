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
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public DateTime Modified { get; set; }
        [Display(Name = "وضعیت حذف / فعال")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public bool Status { get; set; }
        [MaxLength(200)]
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Name { get; set; }
        [MaxLength(50)]
        [Display(Name = "کد محصول")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Code { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public decimal Price { get; set; }
        [Display(Name = "هزینه پشتیبانی")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public decimal BckUpPrice { get; set; }
        [Display(Name = "واحد")]
        [Required(ErrorMessage = "لطفا {0} را پر کنید")]
        public string Unit { get; set; }
    }
}
