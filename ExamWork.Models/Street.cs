using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Models
{
    public class Street: Entity
    {
        public string Name { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
