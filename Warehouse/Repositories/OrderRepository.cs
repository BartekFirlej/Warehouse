using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<OrderResponse>> GetOrders();
        public Task<OrderResponse> GetOrder(int orderId);
        public Task<Order> CheckOrder(int orderId);
        public Task<OrderResponse> PostOrder(OrderRequest orderDetails);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly WarehouseDbContext _context;

        public OrderRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderResponse>> GetOrders()
        {
            return await _context.Orders
                .AsNoTracking()
                .Select(o => Order.OrderToResponseDTO(o))
                .ToListAsync();
        }

        public async Task<OrderResponse> GetOrder(int orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.OrderId == orderId)
                .Select(o => Order.OrderToResponseDTO(o))
                .FirstOrDefaultAsync();
        }

        public async Task<Order> CheckOrder(int orderId)
        {
            return await _context.Orders
                .AsNoTracking()
                .Where(o => o.OrderId == orderId)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderResponse> PostOrder(OrderRequest orderDetails)
        {
            var orderToAdd = Order.RequestDTOToOrder(orderDetails);
            var addedOrder = await _context.Orders.AddAsync(orderToAdd);
            await _context.SaveChangesAsync();
            return Order.OrderToResponseDTO(orderToAdd);
        }
    }
}
