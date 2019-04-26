using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Models
{
    public class Coutry: Entity
    {
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
