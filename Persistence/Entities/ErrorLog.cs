using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces;

namespace Persistence.Entities
{
    [Table("Department_ErrorLog")]
    public class ErrorLog : IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime Modified { get; set; }
        [Display(Name = "وضعیت")]
        public bool Status { get; set; } = true;
        [Display(Name = "آی ام ای دستگاه")]
        [MaxLength(200)]
        public string AndroidIme { get; set; }
        [Display(Name = "نام کلاس")]
        [MaxLength(100)]
        public string ClassName { get; set; }
        [Display(Name = "شناسه مشتری")]
        [MaxLength(100)]
        public string CpuSerial { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public DateTime Date { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        
        public string ExceptionError { get; set; }
        [Display(Name = "متن خطا")]
        public string ExceptionMessage { get; set; }
        [Display(Name = "نوع خطا")]
        public string ExceptionType { get; set; }

        public bool Fatal { get; set; }
        [Display(Name = "نام تابع")]
        [MaxLength(200)]
        public string FuncName { get; set; }

        public int GroupingID { get; set; }
        [Display(Name = "مشخصه فنی")]
        [MaxLength(100)]
        public string HardSerial { get; set; }
        
        public long LKSerial { get; set; }

        public int RefrencedID { get; set; }

        [MaxLength(200)]
        public string ScreenShot { get; set; }
        [Display(Name = "مرجع")]
        public ENSource Source { get; set; }

        public string StackTrace { get; set; }

        public string FlowStackTrace { get; set; }
        [Display(Name = "زمان")]
        [MaxLength(50)]
        public string Time { get; set; }
        [Display(Name = "نسخه")]
        [MaxLength(10)]
        public string Version { get; set; }
        [Display(Name = "آدرس آی پی")]
        [MaxLength(50)]
        public string Ip { get; set; }
        [Display(Name = "مسیر")]
        [MaxLength(200)]
        public string Path { get; set; }
        [MaxLength(200)]
        public string LoggerVersion { get; set; }
    }
}
