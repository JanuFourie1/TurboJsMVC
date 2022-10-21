using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TurboJsMVC.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        [DisplayName("Lecture ID")]
        public int LectureId { get; set; }

        [DisplayName("Module ID")]
        public int ModuleId { get; set; }
        [DisplayName("Class Day")]
        public string Day { get; set; } = null!;
        [DisplayName("Start Time")]
        public string TimeStart { get; set; } = null!;
        [DisplayName("End Time")]
        public string TimeEnd { get; set; } = null!;
    }
}
