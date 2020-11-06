using System;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SmsPanelsBussines : ISmsPanels
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string API { get; set; }
    }
}
