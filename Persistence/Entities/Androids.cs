using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_Androids")]
    public class Androids : IAndroids
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid CustomerGuid { get; set; }
        public string IMEI { get; set; }
        public string Name { get; set; }
    }
}
