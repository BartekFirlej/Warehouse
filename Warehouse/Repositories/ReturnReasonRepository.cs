using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IReturnReasonRepository
    {
        public Task<List<ReturnReasonResponse>> GetReturnReasons();
        public Task<ReturnReasonResponse> GetReturnReason(int returnReasonId);
        public Task<ReturnReason> CheckReturnReason(int returnReasonId);
        public Task<ReturnReasonResponse> PostReturnReason(ReturnReasonRequest returnReasonDetails);
    }

    public class ReturnReasonRepository : IReturnReasonRepository
    {
        private readonly WarehouseDbContext _context;

        public ReturnReasonRepository(WarehouseDbContext context)
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

        public async Task<ReturnReasonResponse> PostReturnReason(ReturnReasonRequest returnReasonDetails)
        {
            var returnReasonToAdd = ReturnReason.RequestDTOToProductType(returnReasonDetails);
            var addedReturnReason = await _context.ReturnReasons.AddAsync(returnReasonToAdd);
            await _context.SaveChangesAsync();
            return ReturnReason.ReturnReasonToResponseDTO(addedReturnReason.Entity);
        }
    }
}
