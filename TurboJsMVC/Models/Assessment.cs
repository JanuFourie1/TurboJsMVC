using System;
using System.Collections.Generic;

namespace TurboJsMVC.Models
{
    public partial class Assessment
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; } = null!;
        public string QuestionOneQ { get; set; } = null!;
        public string QuestionOneA { get; set; } = null!;
        public string QuestionOneO { get; set; } = null!;
        public string QuestionTwoQ { get; set; } = null!;
        public string QuestionTwoA { get; set; } = null!;
        public string QuestionTwoO { get; set; } = null!;
        public string QuestionThreeQ { get; set; } = null!;
        public string QuestionThreeA { get; set; } = null!;
        public string QuestionThreeO { get; set; } = null!;
        public string QuestionFourQ { get; set; } = null!;
        public string QuestionFourA { get; set; } = null!;
        public string QuestionFourO { get; set; } = null!;
        public string QuestionFiveQ { get; set; } = null!;
        public string QuestionFiveA { get; set; } = null!;
        public string QuestionFiveO { get; set; } = null!;
    }
}
