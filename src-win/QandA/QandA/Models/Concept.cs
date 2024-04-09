using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Models
{
    public class Concept
    {
        public Guid Id { get; set; }
        public Topic Topic { get; set; }
        public string Name { get; set; }
        public string ConceptText { get; set; } = String.Empty;
    }
}
