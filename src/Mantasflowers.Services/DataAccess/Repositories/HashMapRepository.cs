using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class HashMapRepository : BaseRepository<HashMap>, IHashMapRepository
    {
        public HashMapRepository(DatabaseContext dbContext)
            : base(dbContext) { }
    }
}
