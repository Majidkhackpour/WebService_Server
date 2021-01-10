using System;
using Services.Interfaces;

namespace EntityCache.ViewModels
{
    public class WebTelegramBuilding : ITelegramBuilding
    {
        public Guid BuildingGuid { get; set; }
        public string BotApi { get; set; }
        public string Channel { get; set; }
        public string Content { get; set; }
    }
}
