using MaverickBankReal.Models;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Context;
using Microsoft.EntityFrameworkCore;
namespace MaverickBankReal.Repo
{
    public class BranchRepository : Repository<int,Branch> , IBranchRepository
    {
        public BranchRepository(BankDbContext context) : base(context) { }

        public override async Task<IEnumerable<Branch>> GetAll()
        {
            var branchs =  await _context.Branches
                .Include(b => b.Employees)
                .Include(b => b.Accounts)
                .ToListAsync();
            if (branchs == null)
                throw new Exception("No Branch found");
            return branchs;
        }

        public override async Task<Branch> GetById(int id)
        {
            var branch =  await _context.Branches
                .Include(b => b.Employees)
                .Include(b => b.Accounts)
                .FirstOrDefaultAsync(b => b.BranchID == id);
            if (branch == null)
                throw new Exception("Branch not found");
            return branch;
        }
        
    }
}
