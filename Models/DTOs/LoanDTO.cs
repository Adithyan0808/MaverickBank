namespace MaverickBankReal.Models.DTOs
{
    public class LoanDTO
    {
        public int LoanID { get; set; }
        public int CustomerID { get; set; }
        public decimal LoanAmount { get; set; }
        public string LoanStatus { get; set; }
    }
}
