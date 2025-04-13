using MaverickBankReal.Models;
using MaverickBankReal.Models.DTOs;
namespace MaverickBankReal.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomerDetailsAsync(int customerId);
        Task<IEnumerable<TransactionDTO>> GetTransactionsByCustomerIdAsync(int customerId);
        Task<LoanDTO> ApplyForLoanAsync(LoanDTO loan);
        Task<IEnumerable<LoanDTO>> GetLoansByCustomerIdAsync(int customerId);
        Task<IEnumerable<AccountDTO>> GetAccountsByCustomerIdAsync(int customerId);
        Task<CustomerDTO> UpdateCustomerAsync(int customerId , CustomerDTO customerDTO);
    }
}
