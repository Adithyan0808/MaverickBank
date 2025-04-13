using System.ComponentModel.DataAnnotations;

namespace MaverickBankReal.Models
{
    public class LoanStatusMaster
    {
        [Key]
        public int LoanStatusID { get; set; }
        public string LoanStatusName { get; set; } = string.Empty;

        // Navigation Properties
        public List<Loan>? Loans { get; set; }
    }
}
