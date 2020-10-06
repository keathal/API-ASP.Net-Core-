using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class StudentGroup
    {
        public StudentGroup()
        {
            Student = new HashSet<Student>();
        }
        public StudentGroup(StudentGroup g)
        {
            if (g!=null )
            {
                StudentGroupId = g.StudentGroupId;
                Name = g.Name;
                FirstYear = g.FirstYear;
                LastYear = g.LastYear;
                Answer = g.Answer;
            }
            Student = new HashSet<Student>();
        }
        public int StudentGroupId { get; set; }
        public string Name { get; set; }
        public int FirstYear { get; set; }
        public int LastYear { get; set; }
        public string Answer { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
