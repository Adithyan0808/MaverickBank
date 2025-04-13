using System.ComponentModel.DataAnnotations.Schema;

namespace MaverickBankReal.Models
{
    public class Admin
    {
        public int AdminID { get; set; }

        [ForeignKey("User")] // Foreign key for User
        public int UserID { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User? User { get; set; }
    }
}
