using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_BackUpLogs")]
    public class BackUpLog : IBackUpLog
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CustomerGuid { get; set; }
        [MaxLength(500)]
        public string FileName { get; set; }
        public double FileLength { get; set; }
        [MaxLength(500)]
        public string URL { get; set; }
    }
}
