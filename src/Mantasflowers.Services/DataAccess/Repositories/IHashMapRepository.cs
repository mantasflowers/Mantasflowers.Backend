using Mantasflowers.Domain.Entities;
using System.Threading.Tasks;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public interface IHashMapRepository : IBaseRepository<HashMap>
    {
        Task<HashMap> FindOrDefaultAsync(string uniquePassword);
    }
}
