using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Duration { get; set; } = null!;
    }
}
