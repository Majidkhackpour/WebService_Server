using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Department;

namespace Persistence.Entities
{
    [Table("Department_Scrapper")]
    public class Scrapper : IScrapper
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime DateM { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string BuildingType { get; set; }
        public int Masahat { get; set; }
        public string SaleSakht { get; set; }
        public int RoomCount { get; set; }
        public bool Evelator { get; set; }
        public bool Parking { get; set; }
        public bool Store { get; set; }
        public bool Balcony { get; set; }
        public decimal RahnPrice { get; set; }
        public decimal EjarePrice { get; set; }
        public decimal SellPrice { get; set; }
        public string RentalAuthority { get; set; }
        public int TabaqeCount { get; set; }
        public int TabaqeNo { get; set; }
        public string Description { get; set; }
        public int VahedPerTabaqe { get; set; }
        public string BuildingSide { get; set; }
        public string ImagesList { get; set; }
        public AdvertiseType Type { get; set; }
        public string FloorCover { get; set; }
        public string Colling { get; set; }
        public string Hitting { get; set; }
        public EnBuildingParent Parent { get; set; }
    }
}
