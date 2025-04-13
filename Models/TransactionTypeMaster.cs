

using System.ComponentModel.DataAnnotations;

namespace MaverickBankReal.Models
{
    public class TransactionTypeMaster
    {
        [Key]
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; } = string.Empty;

        // Navigation Properties
        public List<Transaction>? Transactions { get; set; }
    }
}
