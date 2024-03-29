﻿using Services;
using Services.Interfaces.Building;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities.Building
{
    [Table("Buildings_BuildingWindow")]
    public class BuildingWindow : IBuildingWindow
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public string Name { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
    }
}
