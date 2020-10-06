using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class StudentContactType
    {
        public StudentContactType()
        {
            StudentContact = new HashSet<StudentContact>();
        }
        public StudentContactType(StudentContactType s)
        {
            if(s!=null)
            {
                StudentContactTypeId = s.StudentContactTypeId;
                Name = s.Name;
                Prefix = s.Prefix;
            }
            StudentContact = new HashSet<StudentContact>();
        }
        public int StudentContactTypeId { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }

        public ICollection<StudentContact> StudentContact { get; set; }
    }
}
