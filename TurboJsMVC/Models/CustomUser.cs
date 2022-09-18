namespace TurboJsMVC.Models
{
    public class CustomUser
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DateJoined { get; set; }
    }
}
