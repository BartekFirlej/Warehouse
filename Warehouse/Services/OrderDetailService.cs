using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IOrderDetailService
    {
        public Task<List<OrderDetailResponse>> GetOrderDetails();
        public Task<OrderDetailResponse> GetOrderDetail(int orderDetailId);
        public Task<OrderDetail> CheckOrderDetail(int orderDetailId);
        public Task<OrderDetailResponse> PostOrderDetail(OrderDetailRequest orderDetailDetails);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderService _orderService;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IOrderService orderService)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderService = orderService;
        }

        public async Task<List<OrderDetailResponse>> GetOrderDetails()
        {
            var orderDetails = await _orderDetailRepository.GetOrderDetails();
            if (!orderDetails.Any())
                throw new Exception("Not found any order details.");
            return orderDetails;
        }

        public async Task<OrderDetailResponse> GetOrderDetail(int orderDetailId)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetail(orderDetailId);
            if (orderDetail == null)
                throw new Exception(String.Format("Not found any order detail with id {0}.", orderDetailId));
            return orderDetail;
        }

        public async Task<OrderDetail> CheckOrderDetail(int orderDetailId)
        {
            var orderDetail = await _orderDetailRepository.CheckOrderDetail(orderDetailId);
            if (orderDetail == null)
                throw new Exception(String.Format("Not found any order detail with id {0}.", orderDetailId));
            return orderDetail;
        }

        public async Task<OrderDetailResponse> PostOrderDetail(OrderDetailRequest orderDetailDetails)
        {
            await _orderService.CheckOrder(orderDetailDetails.OrderId);
            return await _orderDetailRepository.PostOrderDetail(orderDetailDetails);
        }
    }
}
