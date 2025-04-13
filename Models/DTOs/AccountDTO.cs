namespace MaverickBankReal.Models.DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
