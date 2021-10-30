using System;
using Services;

namespace EntityCache.ViewModels
{
    public class ProductGardeshViewModel
    {
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public Guid OrderGuid { get; set; }
        public string ContractCode { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
