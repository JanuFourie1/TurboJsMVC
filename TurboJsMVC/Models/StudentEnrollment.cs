using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class StudentEnrollment
    {
        public int Id { get; set; }
        public int ? UserId { get; set; }
        public int CourseId { get; set; }
    }
}
