﻿using Services;
using Servicess.Interfaces.Building;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities.Building
{
    [Table("Buildings_Building")]
    public class Building : IBuilding
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public DateTime CreateDate { get; set; }
        public string Code { get; set; }
        public Guid OwnerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SellPrice { get; set; }
        public decimal VamPrice { get; set; }
        public decimal QestPrice { get; set; }
        public int Dang { get; set; }
        public Guid? DocumentType { get; set; }
        public EnTarakom? Tarakom { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public bool? Tabdil { get; set; }
        public bool? IsShortTime { get; set; }
        public bool? IsOwnerHere { get; set; }
        public decimal PishTotalPrice { get; set; }
        public decimal PishPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Masahat { get; set; }
        public int ZirBana { get; set; }
        public Guid CityGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string Address { get; set; }
        public Guid? BuildingConditionGuid { get; set; }
        public EnBuildingSide? Side { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid? BuildingViewGuid { get; set; }
        public Guid? FloorCoverGuid { get; set; }
        public Guid? KitchenServiceGuid { get; set; }
        public EnKhadamati? Water { get; set; }
        public EnKhadamati? Barq { get; set; }
        public EnKhadamati? Gas { get; set; }
        public EnKhadamati? Tell { get; set; }
        public int TedadTabaqe { get; set; }
        public int TabaqeNo { get; set; }
        public int VahedPerTabaqe { get; set; }
        public float ErtefaSaqf { get; set; }
        public float Hashie { get; set; }
        public float Lenght { get; set; }
        public float ReformArea { get; set; }
        public bool? BuildingPermits { get; set; }
        public float WidthOfPassage { get; set; }
        public string SaleSakht { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public string Image { get; set; }
        public AdvertiseType? AdvertiseType { get; set; }
        public string DivarTitle { get; set; }
        [MaxLength(250)] public string Hiting { get; set; }
        [MaxLength(250)] public string Colling { get; set; }
        public EnVillaType? VillaType { get; set; }
        public EnCommericallLicense? CommericallLicense { get; set; }
        public string SuitableFor { get; set; }
        public string WallCovering { get; set; }
        public int TreeCount { get; set; }
        public EnConstructionStage? ConstructionStage { get; set; }
        public EnBuildingParent? Parent { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public int VahedNo { get; set; }
        public Guid? ZoncanGuid { get; set; }
        public Guid? WindowGuid { get; set; }
    }
}
