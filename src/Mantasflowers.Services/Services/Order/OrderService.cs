using AutoMapper;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.Repositories;
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

        public async Task<GetDetailedOrderResponse> GetDetailedOrderInfoAsync(Guid id)
        {
            var order = await _orderRepository.GetDetailedOrderAsync(id);

            var detailedOrderResponse = _mapper.Map<GetDetailedOrderResponse>(order);

            return detailedOrderResponse;
        }
    }
}
