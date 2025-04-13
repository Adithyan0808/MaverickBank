namespace MaverickBankReal.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        // Navigation Properties
        public Customer? Customer { get; set; }
        public Admin? Admin { get; set; }
        public BankEmployee? BankEmployee { get; set; }
    }
}
