using System;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingUserBussines:IUsers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
        public EnSecurityQuestion SecurityQuestion { get; set; }
        public string AnswerQuestion { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
    }
}
