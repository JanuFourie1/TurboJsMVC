using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class LoginHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Ip { get; set; } = null!;

    }
}
