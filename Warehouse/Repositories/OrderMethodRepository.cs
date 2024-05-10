using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IOrderMethodRepository
    {
        public Task<List<OrderMethodResponse>> GetOrderMethods();
        public Task<OrderMethodResponse> GetOrderMethod(int orderMethodId);
        public Task<OrderMethod> CheckOrderMethod(int orderMethodId);
        public Task<OrderMethod> PostOrderMethod(OrderMethodRequest orderMethodDetails);
    }

    public class OrderMethodRepository : IOrderMethodRepository
    {
        private readonly WarehouseDbContext _context;

        public OrderMethodRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReturnReasonResponse>> GetReturnReasons()
        {
            return await _context.ReturnReasons
               .AsNoTracking()
               .Select(r => ReturnReason.ReturnReasonToResponseDTO(r))
               .ToListAsync();
        }

        public async Task<ReturnReasonResponse> GetReturnReason(int returnReasonId)
        {
            return await _context.ReturnReasons
                .AsNoTracking()
                .Where(r => r.ReturnReasonId == returnReasonId)
                .Select(r => ReturnReason.ReturnReasonToResponseDTO(r))
                .FirstOrDefaultAsync();
        }

        public async Task<ReturnReason> CheckReturnReason(int returnReasonId)
        {
            return await _context.ReturnReasons
                .AsNoTracking()
                .Where(r => r.ReturnReasonId == returnReasonId)
                .FirstOrDefaultAsync();
        }

        public async Task<ReturnReason> PostReturnReason(RetunReasonRequest returnReasonDetails)
        {
            var returnReasonToAdd = new ReturnReason
            {
                ReasonDescription = returnReasonDetails.ReasonDescription
            };
            await _context.ReturnReasons.AddAsync(returnReasonToAdd);
            await _context.SaveChangesAsync();
            return returnReasonToAdd;
        }

        public async Task<List<OrderMethodResponse>> GetOrderMethods()
        {
            return await _context.OrderMethods
               .AsNoTracking()
               .Select(o => OrderMethod.ReturnOrderMethodToResponseDTO(o))
               .ToListAsync();
        }

        public async Task<OrderMethodResponse> GetOrderMethod(int orderMethodId)
        {
            return await _context.OrderMethods
               .AsNoTracking()
               .Select(o => OrderMethod.ReturnOrderMethodToResponseDTO(o))
               .Where(o => o.OrderMethodId == orderMethodId)
               .FirstOrDefaultAsync();
        }

        public async Task<OrderMethod> CheckOrderMethod(int orderMethodId)
        {
            return await _context.OrderMethods
               .AsNoTracking()
               .Where(o => o.OrderMethodId == orderMethodId)
               .FirstOrDefaultAsync();
        }

        public async Task<OrderMethod> PostOrderMethod(OrderMethodRequest orderMethodDetails)
        {
            var orderMethodToAdd = new OrderMethod
            {
                MethodName = orderMethodDetails.MethodName
            };
            await _context.OrderMethods.AddAsync(orderMethodToAdd);
            await _context.SaveChangesAsync();
            return orderMethodToAdd;
        }
    }
}
