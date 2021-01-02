﻿using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class ContractPersistenceRepository:GenericRepository<ContractBussines,Contract>,IContractRepository
    {
        private ModelContext _db;
        public ContractPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
