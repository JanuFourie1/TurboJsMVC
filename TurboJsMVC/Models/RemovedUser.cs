using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class RemovedUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
