using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IOrderDetailRepository
    {
        public Task<List<OrderDetailResponse>> GetOrderDetails();
        public Task<OrderDetailResponse> GetOrderDetail(int orderDetailId);
        public Task<OrderDetail> CheckOrderDetail(int orderDetailId);
        public Task<OrderDetailResponse> PostOrderDetail(OrderDetailRequest orderDetailDetails);
    }

    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly WarehouseDbContext _context;

        public OrderDetailRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetailResponse>> GetOrderDetails()
        {
            return await _context.OrderDetails
                .AsNoTracking()
                .Select(o => OrderDetail.OrderDetailToResponseDTO(o))
                .ToListAsync();
        }

        public async Task<OrderDetailResponse> GetOrderDetail(int orderDetailId)
        {
            return await _context.OrderDetails
                .AsNoTracking()
                .Where(o => o.OrderDetailId == orderDetailId)
                .Select(o => OrderDetail.OrderDetailToResponseDTO(o))
                .FirstOrDefaultAsync();
        }

        public async Task<OrderDetail> CheckOrderDetail(int orderDetailId)
        {
            return await _context.OrderDetails
                .AsNoTracking()
                .Where(o => o.OrderDetailId == orderDetailId)
                .FirstOrDefaultAsync();
        }

        public async Task<OrderDetailResponse> PostOrderDetail(OrderDetailRequest orderDetailDetails)
        {
            var orderDetailToAdd = OrderDetail.RequestDTOToOrderDetail(orderDetailDetails);
            var addedOrderDetail = await _context.OrderDetails.AddAsync(orderDetailToAdd);
            await _context.SaveChangesAsync();
            return OrderDetail.OrderDetailToResponseDTO(addedOrderDetail.Entity);
        }
    }
}
