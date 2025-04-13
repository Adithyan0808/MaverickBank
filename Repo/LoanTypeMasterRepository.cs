using MaverickBankReal.Context;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public class LoanTypeMasterRepository : Repository<int,LoanTypeMaster>,ILoanTypeMasterRepository
    {
        public LoanTypeMasterRepository(BankDbContext context) : base(context) { }

        public override async Task<IEnumerable<LoanTypeMaster>> GetAll()
        {
            return await _context.LoanTypes.ToListAsync();
        }

        public override async Task<LoanTypeMaster> GetById(int id)
        {
            return await _context.LoanTypes.FirstOrDefaultAsync(lt => lt.LoanTypeID == id);
        }


    }
}
