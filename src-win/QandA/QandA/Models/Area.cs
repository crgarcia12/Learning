using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QandA.Models
{
    internal class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
