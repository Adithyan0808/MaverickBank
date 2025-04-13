using MaverickBankReal.Context;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public class AdminRepository : Repository<int,Admin> , IAdminRepository
    {
        public AdminRepository(BankDbContext context) : base(context) { }

        public override async Task<IEnumerable<Admin>> GetAll()
        {
            var admins =  await _context.Admins
                            .Include(a => a.User)
                            .ToListAsync();
            if(admins==null)
                throw new Exception("No Admin found");
            return admins;
        }

        public override async Task<Admin> GetById(int id)
        {
            var admin =  await _context.Admins
                            .Include(a => a.User)
                            .FirstOrDefaultAsync(a => a.AdminID == id);
            if(admin==null)
                throw new Exception("Admin not found");
            return admin;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync()
        {
            var transaction =  await _context.Transactions
                .Include(t => t.SourceAccount).ThenInclude(a => a.Customer)
                .Include(t => t.DestinationAccount).ThenInclude(a => a.Customer)
                .ToListAsync();
            if (transaction == null)
                throw new Exception("No transactions found");
            return transaction;
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            var loan =  await _context.Loans
                            .ToListAsync();
            if (loan == null)
                throw new Exception("No loans found");
            return loan;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            var accounts =  await _context.Accounts
                                .ToListAsync();
            if (accounts == null)
                throw new Exception("No accounts found");
            return accounts;
        }


    }
}
