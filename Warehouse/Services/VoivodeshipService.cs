using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IVoivodeshipService
    {
        public Task<List<VoivodeshipResponse>> GetVoivodeships();
        public Task<VoivodeshipResponse> GetVoivodeship(int voivodeshipId);
        public Task<Voivodeship> CheckVoivodeship(int voivodeshipId);
        public Task<VoivodeshipResponse> PostVoivodeship(VoivodeshipRequest voivodeshipDetails);
    }

    public class VoivodeshipService : IVoivodeshipService
    {
        private readonly IVoivodeshipRepository _voivodeshipRepository;
        private readonly ICountryService _countryService;

        public VoivodeshipService(IVoivodeshipRepository voivodeshipRepository, ICountryService countryService)
        {
            _voivodeshipRepository = voivodeshipRepository;
            _countryService = countryService;
        }

        public async Task<List<VoivodeshipResponse>> GetVoivodeships()
        {
            var voivodeships = await _voivodeshipRepository.GetVoivodeships();
            if (!voivodeships.Any())
                throw new Exception("Not found any voivodeships.");
            return voivodeships;
        }

        public async Task<VoivodeshipResponse> GetVoivodeship(int voivodeshipId)
        {
            var voivodeship = await _voivodeshipRepository.GetVoivodeship(voivodeshipId);
            if (voivodeship == null)
                throw new Exception(String.Format("Not found any voivodeship with id {0}.", voivodeshipId));
            return voivodeship;
        }

        public async Task<Voivodeship> CheckVoivodeship(int voivodeshipId)
        {
            var voivodeship = await _voivodeshipRepository.CheckVoivodeship(voivodeshipId);
            if (voivodeship == null)
                throw new Exception(String.Format("Not found any voivodeship with id {0}.", voivodeshipId));
            return voivodeship;
        }

        public async Task<VoivodeshipResponse> PostVoivodeship(VoivodeshipRequest voivodeshipDetails)
        {
            await _countryService.CheckCountry(voivodeshipDetails.CountryId);
            return await _voivodeshipRepository.PostVoivodeship(voivodeshipDetails);
        }
    }
}
