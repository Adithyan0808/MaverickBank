using MaverickBankReal.Models;

namespace MaverickBankReal.Interfaces.RepoInterface
{
    public interface ICustomerRepository : IRepository<int, Customer>
    {
   
        Task<IEnumerable<Transaction>> GetTransactionsByCustomerIdAsync(int customerId);
        Task<Loan> ApplyForLoanAsync(Loan loan);
        Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(int customerId);
        Task<IEnumerable<Account>> GetAccountsByCustomerIdAsync(int customerId);
    }
}
