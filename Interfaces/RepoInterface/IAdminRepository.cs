using MaverickBankReal.Models;

namespace MaverickBankReal.Interfaces.RepoInterface
{
    public interface IAdminRepository : IRepository<int,Admin>
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync();
        Task<IEnumerable<Loan>> GetLoansAsync();
        Task<IEnumerable<Account>> GetAccountsAsync();
    }
}
