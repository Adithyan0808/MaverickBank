using MaverickBankReal.Context;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public class EmployeeRepository : Repository<int,BankEmployee>, IEmployeeRepository
    {
        public EmployeeRepository(BankDbContext context) : base(context) { }

        public override async Task<IEnumerable<BankEmployee>> GetAll()
        {
            var Employees =  await _context.BankEmployees
                                .Include(e => e.User)
                                .Include(e => e.Branch)
                                .ToListAsync();
            if (Employees == null)
                throw new Exception("No Employee found");
            return Employees;
        }

        public override async Task<BankEmployee> GetById(int id)
        {
            var Employee = await _context.BankEmployees
                            .Include(e => e.User)
                            .Include(e => e.Branch)
                            .FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (Employee == null)
                throw new Exception("Employee not found");
            return Employee;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Transactions
                .Include(t => t.SourceAccount).ThenInclude(a => a.Customer)
                .Include(t => t.DestinationAccount).ThenInclude(a => a.Customer)
                .Where(t => t.SourceAccount.BranchID == employeeId || t.DestinationAccount.BranchID == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoansByEmployeeIdAsync(int employeeId)
        {
            return await _context.Loans
                .Where(l => l.Customer.Accounts.Any(a => a.BranchID == employeeId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Accounts
                .Where(a => a.BranchID == employeeId)
                .ToListAsync();
        }




    }
}
