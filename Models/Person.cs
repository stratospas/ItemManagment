using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagment.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public required string Name { get; set; }
        public required string Lastname { get; set; }

        public virtual Department? Department { get; set; }
        public int DepartmentId { get; set; }

    }
}
