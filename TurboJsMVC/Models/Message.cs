using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Message1 { get; set; } = null!;
        public int ModuleId { get; set; }
        public int UserId { get; set; }
    }
}
