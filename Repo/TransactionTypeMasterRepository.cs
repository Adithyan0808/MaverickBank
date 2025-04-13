using MaverickBankReal.Context;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public class TransactionTypeMasterRepository : Repository<int,TransactionTypeMaster> , ITransactionTypeMasterRepository
    {
        public TransactionTypeMasterRepository(BankDbContext context) : base(context) { }

        public override async Task<IEnumerable<TransactionTypeMaster>> GetAll()
        {
            return await _context.TransactionTypes.ToListAsync();
        }

        public override async Task<TransactionTypeMaster> GetById(int id)
        {
            return await _context.TransactionTypes.FirstOrDefaultAsync(tt => tt.TransactionTypeID == id);
        }
    }
}
