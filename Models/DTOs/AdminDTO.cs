namespace MaverickBankReal.Models.DTOs
{
    public class AdminDTO
    {
        public int AdminID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
