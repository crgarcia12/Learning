using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Concept> Concepts { get; set; } = new List<Concept>();
        public List<Question> Questions { get; set; } = new List<Question>();
        public Area Area { get; set; }

    }
}
