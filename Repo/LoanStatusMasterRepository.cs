using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Context;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public class LoanStatusMasterRepository : Repository<int,LoanStatusMaster> , ILoanStatusMasterRepository
    {
        public LoanStatusMasterRepository(BankDbContext context) : base(context)
        {
        }
        public override async Task<LoanStatusMaster> GetById(int id)
        {
            var loanStatus = await _context.LoanStatusMasters
                .FirstOrDefaultAsync(l => l.LoanStatusID == id);
            if (loanStatus == null)
                throw new Exception("Loan Status not found");
            return loanStatus;
        }
        public override async Task<IEnumerable<LoanStatusMaster>> GetAll()
        {
            var loanStatuses = await _context.LoanStatusMasters.ToListAsync();
            if (loanStatuses == null)
                throw new Exception("No Loan Statuses found");
            return loanStatuses;
        }
    }
}
