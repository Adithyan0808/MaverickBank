using System.Security.Principal;

namespace MaverickBankReal.Models
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; } = string.Empty;          
        public string Location { get; set; } = string.Empty;

        // Navigation Properties
        public List<BankEmployee>? Employees { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
