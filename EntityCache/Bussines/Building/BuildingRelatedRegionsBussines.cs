﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines.Building
{
    public class BuildingRelatedRegionsBussines:IBuildingRequestRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public bool Status { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }


        public static async Task<List<BuildingRelatedRegionsBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.BuildingRelatedRegions.GetAllAsync(parentGuid, status);
        public static List<BuildingRelatedRegionsBussines> GetAll(Guid parentGuid, bool status) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid, status));
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
                res.AddReturnedValue(await UnitOfWork.BuildingRelatedRegions.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
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
