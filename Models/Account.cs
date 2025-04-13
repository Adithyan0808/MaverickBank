using System.ComponentModel.DataAnnotations.Schema;

namespace MaverickBankReal.Models
{
    public class Account
    {
        public int AccountID { get; set; }

        [ForeignKey("Customer")] // Foreign key for Customer
        public int CustomerID { get; set; }

        [ForeignKey("AccountType")] // Foreign key for AccountTypeMaster
        public int AccountTypeID { get; set; }

        [ForeignKey("Branch")] // Foreign key for Branch
        public int BranchID { get; set; }

        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Navigation Properties
        public Customer? Customer { get; set; }
        public AccountTypeMaster? AccountType { get; set; }
        public Branch? Branch { get; set; }
        public List<Transaction>? SourceTransactions { get; set; } // Transactions where this account is the source
        public List<Transaction>? DestinationTransactions { get; set; } // Transactions where this account is the destination
    }
}

