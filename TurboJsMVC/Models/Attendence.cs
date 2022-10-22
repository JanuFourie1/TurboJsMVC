using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TurboJsMVC.Models
{
    public partial class Attendence
    {
        public int Id { get; set; }

        
        [DisplayName("Module ID:")]
        [Required(ErrorMessage = "Please enter unique Module ID")]
        public int ModuleId { get; set; }

        
        [DisplayName("User ID:")]
        [Required(ErrorMessage = "Please enter unique User ID")]
        public int UserId { get; set; }

        [DisplayName("Date:")]
        [Required(ErrorMessage = "Please enter correct date ")]
        public string Date { get; set; } = null!;
    }
}
