using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaverickBankReal.Models
{
    public class BankEmployee
    {
        [Key]
        public int EmployeeID { get; set; }

        [ForeignKey("User")] // Foreign key for User
        public int UserID { get; set; }

        [ForeignKey("Branch")] // Foreign key for Branch
        public int BranchID { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User? User { get; set; }
        public Branch? Branch { get; set; }
    }
}
