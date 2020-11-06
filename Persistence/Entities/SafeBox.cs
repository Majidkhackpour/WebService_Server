using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class SafeBox : ISafeBox
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public EnSafeBox Type { get; set; }
    }
}
