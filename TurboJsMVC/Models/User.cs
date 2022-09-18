using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime DateJoined { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLecture { get; set; }
        public bool IsStudent { get; set; }
        public int? StudentNumber { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
