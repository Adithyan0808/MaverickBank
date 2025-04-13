using MaverickBankReal.Models;

namespace MaverickBankReal.Interfaces.RepoInterface
{
    public interface IEmployeeRepository : IRepository<int, BankEmployee>
    {
        Task<IEnumerable<Transaction>> GetTransactionsByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Loan>> GetLoansByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Account>> GetAccountsByEmployeeIdAsync(int employeeId);
    }
}
