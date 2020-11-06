using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Department;

namespace Persistence.Entities
{
    public class Reception : IReception
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal Price { get; set; }
        public EnReceptionType Type { get; set; }
        [MaxLength(50)]
        public string ResidNo { get; set; }
        [MaxLength(50)]
        public string PeygiriNo { get; set; }
        public Guid SafeBoxGuid { get; set; }
        public string Description { get; set; }
    }
}
