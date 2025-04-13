namespace MaverickBankReal.Models.DTOs
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int BranchID { get; set; }
        public string Role { get; set; }
    }
}
