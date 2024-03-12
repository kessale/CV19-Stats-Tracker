using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Models.Decanat
{
    // Represents a student with personal information and academic rating.
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public double Rating { get; set; }

        public string Description { get; set; }

    }
    // Represents an academic group containing a list of students.
    internal class Group
    {
        public string Name { get; set; } // The name of the group.
        public IList<Student> Students { get; set; } // The students in the group.

        public string Description { get; set; } // Additional description for the group.
    }
}
