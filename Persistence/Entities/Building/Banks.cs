﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities.Building
{
    [Table("Buildings_Banks")]
    public class Banks : IBank
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shobe { get; set; }
        public string CodeShobe { get; set; }
        public string HesabNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateM { get; set; }
    }
}