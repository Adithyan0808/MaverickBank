using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace MaverickBankReal.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [ForeignKey("User")] // Foreign key for User
        public int UserID { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string AadharNumber { get; set; } = string.Empty;
        public string PANNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User? User { get; set; }
        public List<Account>? Accounts { get; set; }
        public List<Loan>? Loans { get; set; }
    }
}
