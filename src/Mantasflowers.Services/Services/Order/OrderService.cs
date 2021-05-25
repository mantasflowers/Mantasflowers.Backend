using AutoMapper;
using Mantasflowers.Contracts.Order.Request;
using Mantasflowers.Contracts.Order.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Generators;
using Mantasflowers.Services.Mapping;
using Mantasflowers.Services.Services.Exceptions;
using Mantasflowers.Services.Services.HashMap;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Mantasflowers.Services.Mapping.OrderMappings;

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

        public async Task<Domain.Entities.Order> GetDetailedOrderAsync(string paymentIntentId)
        {
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(paymentIntentId);

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

        public async Task<Domain.Entities.UserOrder> LinkUserToOrderAsync(Guid userId, Domain.Entities.Order order)
        {
            var userOrder = new Domain.Entities.UserOrder
            {
                UserId = userId,
                Order = order
            };

            try
            {
                userOrder = await _unitOfWork.UserOrderRepository.CreateAsync(userOrder);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex) when
            (ex is DbUpdateException || ex is ArgumentNullException)
            {
                throw new FailedToAddDatabaseResourceException("Failed to link user to order");
            }

            return userOrder;
        }

        public async Task<GetOrdersResponse> GetPaginatedOrdersAsync(GetOrdersRequest request)
        {
            Expression<Func<Domain.Entities.Order, bool>> statusFilter =
                (x => request.Statuses.Contains(x.Status));

            if (!OrderSortingMapping.TryGetValue(request.OrderBy, out var orderByPropertyName))
            {
                throw new MappingException($"No entity property mapping found for '{nameof(request.OrderBy)}'");
            }

            var paginatedOrders = await _unitOfWork.OrderRepository.GetPaginatedFilteredOrderedListAsync(request.Page,
                request.PageSize,
                statusFilter,
                orderByPropertyName,
                request.OrderDescending);

            var paginatedProductsResponse = _mapper.Map<GetOrdersResponse>(paginatedOrders,
                o => o.AfterMap((source, destination) =>
                {
                    destination.OrderedBy = request.OrderBy;
                    destination.OrderDescending = request.OrderDescending;
                }));

            return paginatedProductsResponse;
        }

        public async Task<GetUserOrdersResponse> GetUserOrdersAsync(Guid userId)
        {
            var userOrders = await _unitOfWork.UserOrderRepository.GetUserOrdersByUserId(userId);

            IList<Domain.Entities.Order> orders = new List<Domain.Entities.Order>();
            foreach (var userOrder in userOrders)
            {
                orders.Add(userOrder.Order);
            }

            var response = new GetUserOrdersResponse();
            response.UserOrders = _mapper.Map(orders, response.UserOrders);

            return response;
        }

        public async Task<GetDetailedOrderResponse> UpdateOrderStatusAsync(Guid id, UpdateOrderStatusRequest request)
        {
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(id);

            if (order == null)
            {
                throw new OrderNotFoundException($"Order {id} not found");
            }

            _mapper.Map(request, order);

            if (request.RowVersion != null)
            {
                _unitOfWork.OrderRepository.UpdateOriginalInternalRowVersion(order, request.RowVersion);
            }

            _unitOfWork.OrderRepository.Update(order);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrentEntityUpdateException($"Concurrent update on order {order.Id} was detected");
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException($"Failed to update order {order.Id}");
            }

            var response = _mapper.Map<GetDetailedOrderResponse>(order);

            return response;
        }
    }
}
