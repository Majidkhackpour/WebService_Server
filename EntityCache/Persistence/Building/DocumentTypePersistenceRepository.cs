using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class DocumentTypePersistenceRepository:GenericRepository<DocumentTypeBussines,DocumentType>,IDocumentTypeRepository
    {
        private ModelContext _db;
        public DocumentTypePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
