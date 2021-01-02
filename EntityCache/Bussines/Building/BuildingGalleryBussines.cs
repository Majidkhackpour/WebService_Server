using System;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingGalleryBussines:IBuildingGallery
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public Guid BuildingGuid { get; set; }
        public string ImageName { get; set; }
    }
}
