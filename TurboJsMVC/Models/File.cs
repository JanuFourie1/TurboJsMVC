using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ModuleId { get; set; }
        public int UserId { get; set; }
    }
}
