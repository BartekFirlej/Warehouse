using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IOrderService
    {
        public Task<List<OrderResponse>> GetOrders();
        public Task<OrderResponse> GetOrder(int orderId);
        public Task<Order> CheckOrder(int orderId);
        public Task<OrderResponse> PostOrder(OrderRequest orderDetails);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerService _customerService;
        private readonly IOrderMethodService _orderMethodService;

        public OrderService(IOrderRepository orderRepository, ICustomerService customerService, IOrderMethodService orderMethodService)
        {
            _orderRepository = orderRepository;
            _customerService = customerService;
            _orderMethodService = orderMethodService;
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            if (!orders.Any())
                throw new Exception("Not found any orders.");
            return orders;
        }

        public async Task<OrderResponse> GetOrder(int orderId)
        {
            var order = await _orderRepository.GetOrder(orderId);
            if (order == null)
                throw new Exception(String.Format("Not found any order with id {0}.", orderId));
            return order;
        }

        public async Task<Order> CheckOrder(int orderId)
        {
            var order = await _orderRepository.CheckOrder(orderId);
            if (order == null)
                throw new Exception(String.Format("Not found any order with id {0}.", orderId));
            return order;
        }

        public async Task<OrderResponse> PostOrder(OrderRequest orderDetails)
        {
            await _customerService.CheckCustomer(orderDetails.CustomerId);
            await _orderMethodService.CheckOrderMethod(orderDetails.OrderMethodId);
            return await _orderRepository.PostOrder(orderDetails);
        }
    }
}
