using System;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class ReceptionBussines : IReception
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal Price { get; set; }
        public EnReceptionType Type { get; set; }
        public string ResidNo { get; set; }
        public string PeygiriNo { get; set; }
        public Guid SafeBoxGuid { get; set; }
        public string Description { get; set; }
    }
}
