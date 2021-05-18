using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;
using Mantasflowers.Services.Generators;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class HashMapRepository : BaseRepository<HashMap>, IHashMapRepository
    {
        public HashMapRepository(DatabaseContext dbContext)
            : base(dbContext) { }

        public async Task<HashMap> FindOrDefaultAsync(string uniquePassword)
        {
            string passwordHash = PasswordGenerator.GetUniquePasswordHash(uniquePassword);

            var hashMap = await _dbContext.HashMap
                .SingleOrDefaultAsync(x => x.PasswordHash == passwordHash);

            return hashMap;
        }
    }
}
