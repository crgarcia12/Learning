using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Models
{
    public class Question
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Topic Topic { get; set; }
        public string QuestionText { get; set; }
        public string OptionCorrect { get; set; }
        public string OptionIncorrect1 { get; set; }
        public string OptionIncorrect2 { get; set; }
        public string OptionIncorrect3 { get; set; }
    }
}
