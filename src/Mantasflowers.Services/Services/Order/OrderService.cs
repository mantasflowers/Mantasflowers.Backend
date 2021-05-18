using AutoMapper;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using shortid;
using shortid.Configuration;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Order> CreateOrderAsync(PostCreateOrderRequest request)
        {
            var order = _mapper.Map<Domain.Entities.Order>(request);

            (string uniquePassword, string passwordHash) = HashUniquePassword();

            order.TemporaryPasswordHash = passwordHash;

            try
            {
                order = await _unitOfWork.OrderRepository.CreateAsync(order);
            }
            catch (ArgumentNullException)
            {
                throw new FailedToAddDatabaseResourceException("Failed to create order");
            }

            return order;
        }

        public async Task<Domain.Entities.Order> GetDetailedOrderAsync(Guid id)
        {
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(id);

            return order;
        }

        public async Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id)
        {
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(id);

            var detailedOrderResponse = _mapper.Map<GetDetailedOrderResponse>(order);

            return detailedOrderResponse;
        }

        private static (string, string) HashUniquePassword(
            bool useNumbers = true, 
            bool useSpecialCharacters = false, 
            int length = 9
            )
        {
            var options = new GenerationOptions
            {
                UseNumbers = useNumbers,
                UseSpecialCharacters = useSpecialCharacters,
                Length = length
            };
            string uniquePassword = ShortId.Generate(options);

            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: uniquePassword,
                salt: new byte[] { 0x00 },
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (uniquePassword, passwordHash);
        }
    }
}
