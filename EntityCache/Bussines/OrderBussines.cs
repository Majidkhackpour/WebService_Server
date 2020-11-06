using System;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class OrderBussines : IOrder
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string ContractCode { get; set; }
        public string Version { get; set; }
        public int LearningCount { get; set; }
        public decimal Sum { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
