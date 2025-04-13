using MaverickBankReal.Context;
using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Interfaces.RepoInterface;

namespace MaverickBankReal.Repo
{
    public class CustomerRepository : Repository<int, Customer> , ICustomerRepository
    {
        public CustomerRepository(BankDbContext context) : base(context)
        {
        }

        public override async Task<Customer> GetById(int id)
        {
            var customer =  await _context.Customers
                            .Include(c => c.User)
                            .Include(c => c.Accounts)
                            .FirstOrDefaultAsync(c => c.CustomerID == id);
            if (customer == null)
                throw new Exception("Customer not found");
            return customer;
        }

        public override async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers
                                   .Include(c => c.User)
                                   .Include(c => c.Accounts)
                                   .ToListAsync();
            if (customers == null)
                throw new Exception("No customers found");
            return customers;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByCustomerIdAsync(int customerId)
        {
            return await _context.Transactions
                .Include(t => t.SourceAccount).ThenInclude(a => a.Customer)
                .Include(t => t.DestinationAccount).ThenInclude(a => a.Customer)
                .Where(t => t.SourceAccount.CustomerID == customerId || t.DestinationAccount.CustomerID == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(int customerId)
        {
            return await _context.Loans
                .Where(l => l.CustomerID == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAccountsByCustomerIdAsync(int customerId)
        {
            return await _context.Accounts
                .Where(a => a.CustomerID == customerId)
                .ToListAsync();
        }
        public async Task<Loan> ApplyForLoanAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return loan;
        }



    }
}
