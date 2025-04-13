using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace MaverickBankReal.Models
{
    public class AccountTypeMaster
    {
        [Key]
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; } = string.Empty;

        // Navigation Properties
        public List<Account>? Accounts { get; set; }
    }
}
