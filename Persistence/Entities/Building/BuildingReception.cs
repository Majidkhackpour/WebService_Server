﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities.Building
{
    [Table("Buildings_Reception")]
    public class BuildingReception : IReception
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public string HardSerial { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public long Number { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public Guid TafsilGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        public Guid UserGuid { get; set; }
        public long SanadNumber { get; set; }
        public decimal SumCheck { get; set; }
        public decimal SumHavale { get; set; }
        public decimal SumNaqd { get; set; }
        public decimal Sum { get; set; }
    }
}
