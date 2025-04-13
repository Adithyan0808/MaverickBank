using MaverickBankReal.Models.DTOs;

namespace MaverickBankReal.Interfaces
{
    public interface ILoanStatusMasterService
    {
        Task<LoanStatusMasterDTO> GetLoanStatusDetailsAsync(int loanStatusId);
        Task<IEnumerable<LoanStatusMasterDTO>> GetAllLoanStatusesAsync();
        Task<LoanStatusMasterDTO> AddLoanStatusAsync(LoanStatusMasterDTO loanStatusDTO);
        Task<LoanStatusMasterDTO> UpdateLoanStatusAsync(int loanStatusId, LoanStatusMasterDTO loanStatusDTO);
        Task<bool> DeleteLoanStatusAsync(int loanStatusId);
    }
}
