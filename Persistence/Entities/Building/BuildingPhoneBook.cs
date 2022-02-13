using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities.Building
{
    [Table("Buildings_PhoneBook")]
    public class BuildingPhoneBook : IPhoneBook
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        [Key, Column(Order = 1)]
        public Guid CustomerGuid { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public string Tell { get; set; }
        public string Title { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
