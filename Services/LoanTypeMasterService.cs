using AutoMapper;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Services
{
    public class LoanTypeMasterService : ILoanTypeMasterService
    {
        private readonly ILoanTypeMasterRepository _loanTypeMasterRepository;
        private readonly IMapper _mapper;

        public LoanTypeMasterService(ILoanTypeMasterRepository loanTypeMasterRepository, IMapper mapper)
        {
            _loanTypeMasterRepository = loanTypeMasterRepository;
            _mapper = mapper;
        }
        public async Task<LoanTypeMasterDTO> GetLoanTypeDetailsAsync(int loanTypeId)
        {
            var loanType = await _loanTypeMasterRepository.GetById(loanTypeId);
            return _mapper.Map<LoanTypeMasterDTO>(loanType);
        }

        public async Task<IEnumerable<LoanTypeMasterDTO>> GetAllLoanTypesAsync()
        {
            var loanTypes = await _loanTypeMasterRepository.GetAll();
            return _mapper.Map<IEnumerable<LoanTypeMasterDTO>>(loanTypes);
        }

        public async Task<LoanTypeMasterDTO> AddLoanTypeAsync(LoanTypeMasterDTO loanTypeDTO)
        {
            var loanType = _mapper.Map<LoanTypeMaster>(loanTypeDTO);
            var addedLoanType = await _loanTypeMasterRepository.Add(loanType);
            return _mapper.Map<LoanTypeMasterDTO>(addedLoanType);
        }

        public async Task<LoanTypeMasterDTO> UpdateLoanTypeAsync(int loanTypeId, LoanTypeMasterDTO loanTypeDTO)
        {
            var loanType = _mapper.Map<LoanTypeMaster>(loanTypeDTO);
            loanType.LoanTypeID = loanTypeId; // Ensure the ID is set
            var updatedLoanType = await _loanTypeMasterRepository.Update(loanTypeId, loanType);
            return _mapper.Map<LoanTypeMasterDTO>(updatedLoanType);
        }

        public async Task<bool> DeleteLoanTypeAsync(int loanTypeId)
        {
            try
            {
                await _loanTypeMasterRepository.Delete(loanTypeId);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
