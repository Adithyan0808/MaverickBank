using AutoMapper;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;
using MaverickBankReal.Interfaces;

namespace MaverickBankReal.Services
{
    public class LoanStatusMasterService : ILoanStatusMasterService
    {
        private readonly ILoanStatusMasterRepository _loanStatusMasterRepository;
        private readonly IMapper _mapper;

        public LoanStatusMasterService(ILoanStatusMasterRepository loanStatusMasterRepository, IMapper mapper)
        {
            _loanStatusMasterRepository = loanStatusMasterRepository;
            _mapper = mapper;
        }
         public async Task<LoanStatusMasterDTO> GetLoanStatusDetailsAsync(int loanStatusId)
        {
            var loanStatus = await _loanStatusMasterRepository.GetById(loanStatusId);
            return _mapper.Map<LoanStatusMasterDTO>(loanStatus);
        }

        public async Task<IEnumerable<LoanStatusMasterDTO>> GetAllLoanStatusesAsync()
        {
            var loanStatuses = await _loanStatusMasterRepository.GetAll();
            return _mapper.Map<IEnumerable<LoanStatusMasterDTO>>(loanStatuses);
        }

        public async Task<LoanStatusMasterDTO> AddLoanStatusAsync(LoanStatusMasterDTO loanStatusDTO)
        {
            var loanStatus = _mapper.Map<LoanStatusMaster>(loanStatusDTO);
            var addedLoanStatus = await _loanStatusMasterRepository.Add(loanStatus);
            return _mapper.Map<LoanStatusMasterDTO>(addedLoanStatus);
        }

        public async Task<LoanStatusMasterDTO> UpdateLoanStatusAsync(int loanStatusId, LoanStatusMasterDTO loanStatusDTO)
        {
            var loanStatus = _mapper.Map<LoanStatusMaster>(loanStatusDTO);
            loanStatus.LoanStatusID = loanStatusId; // Ensure the ID is set
            var updatedLoanStatus = await _loanStatusMasterRepository.Update(loanStatusId, loanStatus);
            return _mapper.Map<LoanStatusMasterDTO>(updatedLoanStatus);
        }

        public async Task<bool> DeleteLoanStatusAsync(int loanStatusId)
        {
            try
            {
                await _loanStatusMasterRepository.Delete(loanStatusId);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
