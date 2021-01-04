using System;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Department;

namespace Persistence.Entities
{
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
