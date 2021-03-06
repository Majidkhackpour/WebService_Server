﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class ReceptionController : ApiController
    {
        [HttpGet]
        [Route("Reception_GetAll")]
        public async Task<IEnumerable<ReceptionBussines>> GetAllAsync() => await ReceptionBussines.GetAllAsync();

        [HttpGet]
        [Route("Reception_Get/{guid}")]
        public async Task<ReceptionBussines> GetAsync(Guid guid) => await ReceptionBussines.GetAsync(guid);

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Status) res.AddReturnedValue(await cls.SaveAsync());
                else res.AddReturnedValue(await cls.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        
    }
}
