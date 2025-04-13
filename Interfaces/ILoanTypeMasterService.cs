using MaverickBankReal.Models.DTOs;

namespace MaverickBankReal.Interfaces
{
    public interface ILoanTypeMasterService
    {
        Task<LoanTypeMasterDTO> GetLoanTypeDetailsAsync(int loanTypeId);
        Task<IEnumerable<LoanTypeMasterDTO>> GetAllLoanTypesAsync();
        Task<LoanTypeMasterDTO> AddLoanTypeAsync(LoanTypeMasterDTO loanTypeDTO);
        Task<LoanTypeMasterDTO> UpdateLoanTypeAsync(int loanTypeId, LoanTypeMasterDTO loanTypeDTO);
        Task<bool> DeleteLoanTypeAsync(int loanTypeId);
    }
}
