using MaverickBankReal.Context;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public class AccountTypeMasterRepository : Repository<int,AccountTypeMaster>, IAccountTypeMasterRepository
    {
        public AccountTypeMasterRepository(BankDbContext context) : base(context) { }

        public override async Task<IEnumerable<AccountTypeMaster>> GetAll()
        {
            return await _context.AccountTypes.ToListAsync();
        }

        public override async Task<AccountTypeMaster> GetById(int id)
        {
            return await _context.AccountTypes.FirstOrDefaultAsync(at => at.AccountTypeID == id);
        }
    }
}
