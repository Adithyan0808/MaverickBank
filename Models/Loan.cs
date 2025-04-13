using System.ComponentModel.DataAnnotations.Schema;

namespace MaverickBankReal.Models
{
    public class Loan
    {
        public int LoanID { get; set; }

        [ForeignKey("Customer")] 
        public int CustomerID { get; set; }

        [ForeignKey("LoanType")] 
        public int LoanTypeID { get; set; }

        [ForeignKey("LoanStatus")] 
        public int LoanStatusID { get; set; }

        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Customer? Customer { get; set; }
        public LoanTypeMaster? LoanType { get; set; }
        public LoanStatusMaster? LoanStatus { get; set; }
    }
}
