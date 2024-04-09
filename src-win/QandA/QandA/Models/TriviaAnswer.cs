using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Models
{
    internal class TriviaAnswer
    {
        public Guid Id { get; set; }
        public Trivia Trivia { get; set; }
        public Question Question { get; set; }
        public DateTime CompletionDate { get; set; }
        public int SelectedAnswer { get; set; }
    }
}
