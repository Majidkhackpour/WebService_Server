using System;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class OrderDetailBussines : IOrderDetail
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid PrdGuid { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
