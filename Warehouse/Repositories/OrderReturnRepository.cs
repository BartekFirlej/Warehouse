using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IOrderReturnRepository
    {
        public Task<List<OrderReturnResponse>> GetOrderReturns();
        public Task<OrderReturnResponse> GetOrderReturn(int orderReturnId);
        public Task<OrderReturn> CheckOrderReturn(int orderReturnId);
        public Task<OrderReturnResponse> PostOrderReturn(OrderReturnRequest orderReturnDetails);
    }

    public class OrderReturnRepository : IOrderReturnRepository
    {
        private readonly WarehouseDbContext _context;

        public OrderReturnRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderReturnResponse>> GetOrderReturns()
        {
            return await _context.OrderReturns
                .AsNoTracking()
                .Select(o => OrderReturn.OrderReturnToResponseDTO(o))
                .ToListAsync();
        }

        public async Task<OrderReturnResponse> GetOrderReturn(int orderReturnId)
        {
            return await _context.OrderReturns
                .AsNoTracking()
                .Where(o => o.ReturnId == orderReturnId)
                .Select(o => OrderReturn.OrderReturnToResponseDTO(o))
                .FirstOrDefaultAsync();
        }

        public async Task<OrderReturn> CheckOrderReturn(int orderReturnId)
        {
            return await _context.OrderReturns
                .AsNoTracking()
                .Where(o => o.ReturnId == orderReturnId)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderReturnResponse> PostOrderReturn(OrderReturnRequest orderReturnDetails)
        {
            var orderReturnToAdd = OrderReturn.RequestDTOToOrderReturn(orderReturnDetails);
            var addedOrderReturn = await _context.OrderReturns.AddAsync(orderReturnToAdd);
            await _context.SaveChangesAsync();
            return OrderReturn.OrderReturnToResponseDTO(addedOrderReturn.Entity);
        }
    }
}
