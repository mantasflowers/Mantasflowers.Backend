using AutoMapper;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.Repositories;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.Order> CreateOrderAsync(PostCreateOrderRequest request)
        {
            var order = _mapper.Map<Domain.Entities.Order>(request);
            order.TemporaryPasswordHash = "stoppolice";

            try
            {
                order = await _orderRepository.CreateAsync(order);
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException("Failed to create order");
            }

            order = await _orderRepository.GetDetailedOrderAsync(order.Id); // Is there a better solution?

            return order;
        }

        public async Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id)
        {
            var order = await _orderRepository.GetDetailedOrderAsync(id);

            var detailedOrderResponse = _mapper.Map<GetDetailedOrderResponse>(order);

            return detailedOrderResponse;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _orderRepository.BeginTransactionAsync();
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _orderRepository.CreateExecutionStrategy();
        }
    }
}
