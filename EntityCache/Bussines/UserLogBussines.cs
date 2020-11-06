using System;
using Services;
using Servicess.Interfaces.Department;

namespace EntityCache.Bussines
{
    public class UserLogBussines : IUserLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public Guid UserGuid { get; set; }
        public EnLogType Type { get; set; }
        public string Description { get; set; }
    }
}
