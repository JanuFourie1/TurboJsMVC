using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public int ModuleId { get; set; }
        public string Day { get; set; } = null!;
        public string TimeStart { get; set; } = null!;
        public string TimeEnd { get; set; } = null!;
    }
}
