using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TurboJsMVC.Models
{
    public partial class Assessment
    {
        public int Id { get; set; }
        [DisplayName("Module ID")]
        public int ModuleId { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Question 1:")]
        public string QuestionOneQ { get; set; } = null!;
        [DisplayName("First Choice Answer:")]
        public string QuestionOneA { get; set; } = null!;
        [DisplayName("Second Choice Answer:")]
        public string QuestionOneO { get; set; } = null!;
        [DisplayName("Question 2:")]
        public string QuestionTwoQ { get; set; } = null!;
        [DisplayName("First Choice Answer:")]
        public string QuestionTwoA { get; set; } = null!;
        [DisplayName("Second Choice Answer:")]
        public string QuestionTwoO { get; set; } = null!;
        [DisplayName("Question 3:")]
        public string QuestionThreeQ { get; set; } = null!;
        [DisplayName("First Choice Answer:")]
        public string QuestionThreeA { get; set; } = null!;
        [DisplayName("Second Choice Answer:")]
        public string QuestionThreeO { get; set; } = null!;
        [DisplayName("Question 4:")]
        public string QuestionFourQ { get; set; } = null!;
        [DisplayName("First Choice Answer:")]
        public string QuestionFourA { get; set; } = null!;
        [DisplayName("Second Choice Answer:")]
        public string QuestionFourO { get; set; } = null!;
        [DisplayName("Question 5:")]
        public string QuestionFiveQ { get; set; } = null!;
        [DisplayName("First Choice Answer:")]
        public string QuestionFiveA { get; set; } = null!;
        [DisplayName("Second Choice Answer:")]
        public string QuestionFiveO { get; set; } = null!;
    }
}
