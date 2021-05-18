using AutoMapper;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Generators;
using Mantasflowers.Services.Services.Exceptions;
using Mantasflowers.Services.Services.HashMap;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashMapService _hashMapService;
        private readonly IMapper _mapper;

        public OrderService(
            IUnitOfWork unitOfWork,
            IHashMapService hashMapService,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hashMapService = hashMapService;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Order> CreateOrderAsync(PostCreateOrderRequest request)
        {
            var order = _mapper.Map<Domain.Entities.Order>(request);

            (string uniquePassword, string passwordHash) = PasswordGenerator.HashUniquePassword();

            order.UniquePassword = uniquePassword;

            try
            {
                order = await _unitOfWork.OrderRepository.CreateAsync(order);
                var hashMap = await _hashMapService.CreateHashMapAsync(passwordHash);
                hashMap.Order = order;
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

        public async Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(string uniquePassword)
        {
            var hashMap = await _hashMapService.GetHashMapAsync(uniquePassword);
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(hashMap.OrderId);

            var detailedOrderResponse = _mapper.Map<GetDetailedOrderResponse>(order);

            return detailedOrderResponse;
        }

        public async Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id)
        {
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(id);

            var detailedOrderResponse = _mapper.Map<GetDetailedOrderResponse>(order);

            return detailedOrderResponse;
        }
    }
}
