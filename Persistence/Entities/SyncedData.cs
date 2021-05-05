using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_SyncedData")]
    public class SyncedData : ISyncedData
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid ObjectGuid { get; set; }
        public string HardSerial { get; set; }
        public EnTemp Type { get; set; }
    }
}
