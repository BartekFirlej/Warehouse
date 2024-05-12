using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IOrderReturnService
    {
        public Task<List<OrderReturnResponse>> GetOrderReturns();
        public Task<OrderReturnResponse> GetOrderReturn(int orderReturnId);
        public Task<OrderReturn> CheckOrderReturn(int orderReturnId);
        public Task<OrderReturnResponse> PostOrderReturn(OrderReturnRequest orderReturnDetails);
    }

    public class OrderReturnService : IOrderReturnService
    {
        private readonly IOrderReturnRepository _orderReturnRepository;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IReturnReasonService _returnReasonService;

        public OrderReturnService(IOrderReturnRepository orderReturnRepository, IOrderDetailService orderDetailService, IReturnReasonService returnReasonService)
        {
            _orderReturnRepository = orderReturnRepository;
            _orderDetailService = orderDetailService;
            _returnReasonService = returnReasonService;
        }

        public async Task<List<OrderReturnResponse>> GetOrderReturns()
        {
            var orderReturns = await _orderReturnRepository.GetOrderReturns();
            if (!orderReturns.Any())
                throw new Exception("Not found any order returns.");
            return orderReturns;
        }

        public async Task<OrderReturnResponse> GetOrderReturn(int orderReturnId)
        {
            var orderReturn = await _orderReturnRepository.GetOrderReturn(orderReturnId);
            if (orderReturn == null)
                throw new Exception(String.Format("Not found any order return with id {0}.", orderReturnId));
            return orderReturn;
        }

        public async Task<OrderReturn> CheckOrderReturn(int orderReturnId)
        {
            var orderReturn = await _orderReturnRepository.CheckOrderReturn(orderReturnId);
            if (orderReturn == null)
                throw new Exception(String.Format("Not found any order return with id {0}.", orderReturnId));
            return orderReturn;
        }

        public async Task<OrderReturnResponse> PostOrderReturn(OrderReturnRequest orderReturnDetails)
        {
            await _orderDetailService.CheckOrderDetail(orderReturnDetails.OrderDetailId);
            await _returnReasonService.CheckReturnReason(orderReturnDetails.ReturnReasonId);
            return await _orderReturnRepository.PostOrderReturn(orderReturnDetails);
        }
    }
}
