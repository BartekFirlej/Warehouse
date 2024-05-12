using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IVoivodeshipRepository
    {
        public Task<List<VoivodeshipResponse>> GetVoivodeships();
        public Task<VoivodeshipResponse> GetVoivodeship(int voivodeshipId);
        public Task<Voivodeship> CheckVoivodeship(int voivodeshipId);
        public Task<VoivodeshipResponse> PostVoivodeship(VoivodeshipRequest voivodeshipDetails);
    }

    public class VoivodeshipRepository : IVoivodeshipRepository
    {
        private readonly WarehouseDbContext _context;

        public VoivodeshipRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<VoivodeshipResponse>> GetVoivodeships()
        {
            return await _context.Voivodeships
               .AsNoTracking()
               .Select(v => Voivodeship.VoivodeshipToResponseDTO(v))
               .ToListAsync();
        }

        public async Task<VoivodeshipResponse> GetVoivodeship(int voivodeshipId)
        {
            return await _context.Voivodeships
                .AsNoTracking()
                .Where(v => v.VoivodeshipId == voivodeshipId)
                .Select(v => Voivodeship.VoivodeshipToResponseDTO(v))
                .FirstOrDefaultAsync();
        }

        public async Task<Voivodeship> CheckVoivodeship(int voivodeshipId)
        {
            return await _context.Voivodeships
                .AsNoTracking()
                .Where(v => v.VoivodeshipId == voivodeshipId)
                .FirstOrDefaultAsync();
        }

        public async Task<VoivodeshipResponse> PostVoivodeship(VoivodeshipRequest voivodeshipDetails)
        {
            var voiovdeshipToAdd = Voivodeship.RequestDTOToVoivodeship(voivodeshipDetails);
            var addedVoivodeship = await _context.Voivodeships.AddAsync(voiovdeshipToAdd);
            await _context.SaveChangesAsync();
            return Voivodeship.VoivodeshipToResponseDTO(addedVoivodeship.Entity);
        }
    }
}
