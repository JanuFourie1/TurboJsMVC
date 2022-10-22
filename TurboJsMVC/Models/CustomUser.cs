namespace TurboJsMVC.Models
{
    public class CustomUser
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DateJoined { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLecture { get; set; }
        public bool IsStudent { get; set; }
        public int StudentNumber { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Department { get; set; }
    }
}
