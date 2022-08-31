using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Module
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int LectureId { get; set; }
        public int CourseId { get; set; }
    }
}
