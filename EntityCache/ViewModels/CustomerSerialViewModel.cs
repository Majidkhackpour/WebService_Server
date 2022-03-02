using System;

namespace EntityCache.ViewModels
{
    public class CustomerSerialViewModel
    {
        public Guid ProductGuid { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public bool IsChecked { get; set; }
    }
}
