using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetEmployeeDetailsAsync(int employeeId);
        Task UpdateEmployeeDetailsAsync(int employeeId, EmployeeDTO employeeDTO);
        Task<IEnumerable<TransactionDTO>> GetTransactionsAsync(int employeeId);
        Task<IEnumerable<LoanDTO>> GetLoansAsync(int employeeId);
        Task<IEnumerable<AccountDTO>> GetAccountsAsync(int employeeId);
    }
}
