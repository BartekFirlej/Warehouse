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
        public Task<OrderMethodResponse> PostOrderMethod(OrderMethodRequest orderMethodDetails);
    }

    public class OrderMethodRepository : IOrderMethodRepository
    {
        private readonly WarehouseDbContext _context;

        public OrderMethodRepository(WarehouseDbContext context)
        {
            _context = context;
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

        public async Task<OrderMethodResponse> PostOrderMethod(OrderMethodRequest orderMethodDetails)
        {
            var orderMethodToAdd = OrderMethod.RequestDTOToOrderMethod(orderMethodDetails);
            var addedOrderMethod = await _context.OrderMethods.AddAsync(orderMethodToAdd);
            await _context.SaveChangesAsync();
            return OrderMethod.ReturnOrderMethodToResponseDTO(addedOrderMethod.Entity);
        }
    }
}
