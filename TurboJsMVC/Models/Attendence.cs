using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Attendence
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; } = null!;
    }
}
