namespace MaverickBankReal.Models.DTOs
{
    public class TransactionDTO
    {
        public int TransactionID { get; set; }
        public int SourceAccountID { get; set; }
        public int DestinationAccountID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
