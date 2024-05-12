using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IOrderMethodService
    {
        public Task<List<OrderMethodResponse>> GetOrderMethods();
        public Task<OrderMethodResponse> GetOrderMethod(int orderMethodId);
        public Task<OrderMethod> CheckOrderMethod(int orderMethodId);
        public Task<OrderMethodResponse> PostOrderMethod(OrderMethodRequest orderMethodDetails);
    }

    public class OrderMethodService : IOrderMethodService
    {
        private readonly IOrderMethodRepository _orderMethodRepository;

        public OrderMethodService(IOrderMethodRepository orderMethodRepository)
        {
            _orderMethodRepository = orderMethodRepository;
        }

        public async Task<List<OrderMethodResponse>> GetOrderMethods()
        {
            var orderMethods = await _orderMethodRepository.GetOrderMethods();
            if (!orderMethods.Any())
                throw new Exception("Not found any order methods.");
            return orderMethods;
        }

        public async Task<OrderMethodResponse> GetOrderMethod(int orderMethodId)
        {
            var orderMethod = await _orderMethodRepository.GetOrderMethod(orderMethodId);
            if (orderMethod == null)
                throw new Exception(String.Format("Not found any order method with id {0}.", orderMethodId));
            return orderMethod;
        }

        public async Task<OrderMethod> CheckOrderMethod(int orderMethodId)
        {
            var orderMethod = await _orderMethodRepository.CheckOrderMethod(orderMethodId);
            if (orderMethod == null)
                throw new Exception(String.Format("Not found any order method with id {0}.", orderMethodId));
            return orderMethod;
        }

        public async Task<OrderMethodResponse> PostOrderMethod(OrderMethodRequest orderMethodDetails)
        {
            return await _orderMethodRepository.PostOrderMethod(orderMethodDetails);
        }
    }
}
