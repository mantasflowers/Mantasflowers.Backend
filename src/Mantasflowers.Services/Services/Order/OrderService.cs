using AutoMapper;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
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
            order.TemporaryPasswordHash = "stoppolice";

            try
            {
                order = await _unitOfWork.OrderRepository.CreateAsync(order);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
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
    }
}
