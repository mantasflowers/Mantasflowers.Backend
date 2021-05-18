using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.HashMap
{
    public class HashMapService : IHashMapService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HashMapService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Entities.HashMap> CreateHashMapAsync(string passwordHash)
        {
            var hashMap = new Domain.Entities.HashMap { PasswordHash = passwordHash };

            hashMap = await _unitOfWork.HashMapRepository.CreateAsync(hashMap);

            return hashMap;
        }

        public async Task<Domain.Entities.HashMap> GetHashMapAsync(string uniquePassword)
        {
            var hashMap = await _unitOfWork.HashMapRepository
                .FindOrDefaultAsync(uniquePassword);

            if (hashMap == null)
            {
                throw new HashMapOrderNotFoundException("Order does not exist or password is incorrect");
            }

            return hashMap;
        }
    }
}
