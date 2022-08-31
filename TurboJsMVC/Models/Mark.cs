using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int? Mark1 { get; set; }
        public int? ModuleId { get; set; }
        public int? UserId { get; set; }
    }
}
