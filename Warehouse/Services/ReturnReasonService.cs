using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IReturnReasonService
    {
        public Task<List<ReturnReasonResponse>> GetReturnReasons();
        public Task<ReturnReasonResponse> GetReturnReason(int returnReasonId);
        public Task<ReturnReason> CheckReturnReason(int returnReasonId);
        public Task<ReturnReasonResponse> PostReturnReason(RetunReasonRequest returnReasonDetails);
    }

    public class ReturnReasonService : IReturnReasonService
    {
        private readonly IReturnReasonRepository _returnReasonRepository;

        public ReturnReasonService(IReturnReasonRepository returnReasonRepository)
        {
            _returnReasonRepository = returnReasonRepository;
        }

        public async Task<List<ReturnReasonResponse>> GetReturnReasons()
        {
            var returnReasons = await _returnReasonRepository.GetReturnReasons();
            if (!returnReasons.Any())
                throw new Exception("Not found any return reasons.");
            return returnReasons;
        }

        public async Task<ReturnReasonResponse> GetReturnReason(int returnReasonId)
        {
            var returnReason = await _returnReasonRepository.GetReturnReason(returnReasonId);
            if (returnReason == null)
                throw new Exception(String.Format("Not found any return reason with id {0}.", returnReasonId));
            return returnReason;
        }

        public async Task<ReturnReason> CheckReturnReason(int returnReasonId)
        {
            var returnReason = await _returnReasonRepository.CheckReturnReason(returnReasonId);
            if (returnReason == null)
                throw new Exception(String.Format("Not found any return reason with id {0}.", returnReasonId));
            return returnReason;
        }

        public async Task<ReturnReasonResponse> PostReturnReason(RetunReasonRequest returnReasonDetails)
        {
            var addedReturnReason = await _returnReasonRepository.PostReturnReason(returnReasonDetails);
            return ReturnReason.ReturnReasonToResponseDTO(addedReturnReason);
        }
    }
}
