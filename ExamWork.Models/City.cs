using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Models
{
    public class City: Entity
    {
        public string Name{ get; set; }

        public Guid CountryId { get; set; }
        public Coutry Country { get; set; }

        public ICollection<Street> Streets { get; set; } = new List<Street>();
    }
}
