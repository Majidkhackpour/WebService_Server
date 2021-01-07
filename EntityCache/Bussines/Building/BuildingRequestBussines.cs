using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingRequestBussines:IBuildingRequest
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid AskerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SellPrice1 { get; set; }
        public decimal SellPrice2 { get; set; }
        public bool? HasVam { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public short? PeopleCount { get; set; }
        public bool? HasOwner { get; set; }
        public bool? ShortDate { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public Guid CityGuid { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public int Masahat1 { get; set; }
        public int Masahat2 { get; set; }
        public int RoomCount { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public string ShortDesc { get; set; }
        private List<BuildingRelatedRegionsBussines> _regList;
        public List<BuildingRelatedRegionsBussines> RegionList
        {
            get
            {
                if (_regList != null) return _regList;
                _regList = AsyncContext.Run(() => BuildingRelatedRegionsBussines.GetAllAsync(Guid, Status));
                return _regList;
            }
            set => _regList = value;
        }



        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }
                res.AddReturnedValue(await UnitOfWork.BuildingRequest.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                var temp = new SyncedDataBussines()
                {
                    HardSerial = HardSerial,
                    ObjectGuid = Guid,
                    Type = EnTemp.Requests
                };
                res.AddReturnedValue(await temp.SaveAsync());
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
