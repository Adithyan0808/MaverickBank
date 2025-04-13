using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDTO> GetAdminDetailsAsync(int adminId);
        Task UpdateAdminDetailsAsync(int adminId, AdminDTO adminDTO);
        Task<IEnumerable<TransactionDTO>> GetTransactionsAsync();
        Task<IEnumerable<LoanDTO>> GetLoansAsync();
        Task<IEnumerable<AccountDTO>> GetAccountsAsync();
    }
}
