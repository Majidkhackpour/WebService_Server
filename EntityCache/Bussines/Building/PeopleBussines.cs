﻿using System;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class PeopleBussines:IPeoples
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string IdCode { get; set; }
        public string FatherName { get; set; }
        public string PlaceBirth { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public string IssuedFrom { get; set; }
        public string PostalCode { get; set; }
        public Guid GroupGuid { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
    }
}
