using System.ComponentModel.DataAnnotations;

namespace MaverickBankReal.Models
{
    public class LoanTypeMaster
    {
        [Key]
        public int LoanTypeID { get; set; }
        public string LoanTypeName { get; set; } = string.Empty;
        public decimal MaxLoanAmount { get; set; }
        public decimal DefaultInterestRate { get; set; }

        // Navigation Properties
        public List<Loan>? Loans { get; set; }
    }
}
