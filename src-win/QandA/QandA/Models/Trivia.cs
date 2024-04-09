using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Models
{
    internal class Trivia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Topic Topic { get; set; }
        public DateTime CompletionDate { get; set; }
        public List<TriviaAnswer> Answers { get; set; } = new List<TriviaAnswer>();
    }
}
