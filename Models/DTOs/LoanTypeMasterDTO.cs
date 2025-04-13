namespace MaverickBankReal.Models.DTOs
{
    public class LoanTypeMasterDTO
    {
        public int LoanTypeID { get; set; }
        public string LoanTypeName { get; set; } = string.Empty;
        public decimal MaxLoanAmount { get; set; }
        public decimal DefaultInterestRate { get; set; }
    }
}
