using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.HashMap
{
    public interface IHashMapService
    {
        Task<Domain.Entities.HashMap> CreateHashMapAsync(string passwordHash);

        Task<Domain.Entities.HashMap> GetHashMapAsync(string uniquePassword);
    }
}
