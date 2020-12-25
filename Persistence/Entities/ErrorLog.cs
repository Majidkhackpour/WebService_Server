using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces;

namespace Persistence.Entities
{
    public class ErrorLog : IHasGuid
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; } = true;

        [MaxLength(200)]
        public string AndroidIme { get; set; }
        [MaxLength(100)]
        public string ClassName { get; set; }
        [MaxLength(100)]
        public string CpuSerial { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ExceptionError { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public bool Fatal { get; set; }
        [MaxLength(200)]
        public string FuncName { get; set; }
        public int GroupingID { get; set; }
        [MaxLength(100)]
        public string HardSerial { get; set; }
        public long LKSerial { get; set; }
        public int RefrencedID { get; set; }
        [MaxLength(200)]
        public string ScreenShot { get; set; }
        public ENSource Source { get; set; }
        public string StackTrace { get; set; }
        public string FlowStackTrace { get; set; }
        [MaxLength(50)]
        public string Time { get; set; }
        [MaxLength(10)]
        public string Version { get; set; }
        [MaxLength(50)]
        public string Ip { get; set; }
        [MaxLength(200)]
        public string Path { get; set; }
        [MaxLength(200)]
        public string LoggerVersion { get; set; }
    }
}
