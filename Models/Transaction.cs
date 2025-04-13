using System.ComponentModel.DataAnnotations.Schema;

namespace MaverickBankReal.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        [ForeignKey("SourceAccount")] 
        public int SourceAccountID { get; set; }

        [ForeignKey("DestinationAccount")] 
        public int DestinationAccountID { get; set; }

        [ForeignKey("TransactionType")] 
        public int TransactionTypeID { get; set; }

        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        // Navigation
        public Account? SourceAccount { get; set; }
        public Account? DestinationAccount { get; set; }
        public TransactionTypeMaster? TransactionType { get; set; }
    }
}
