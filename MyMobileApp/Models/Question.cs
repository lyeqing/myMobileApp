using System;
using System.Collections.Generic;
using System.Text;

namespace MyMobileApp.Models
{
    class Question
    {
        public string Id { get; set; }
        public QuestionType Type { get; set; }
        public string QuestionBody { get; set; }
        public List<string> Selections { get; set; } = new List<string>();
        public string Description { get; set; }
        public List<string> Answers { get; set; } = new List<string>();

    }

    enum QuestionType { 
    ThreeChoice,
    FiveStar,
    SeverChoice,
    YesNo,
    ShortAnswer,
    LongAnswer,
    SingleChoice,
    MultiChoice

    }
}
