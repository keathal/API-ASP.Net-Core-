using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class StudentContact
    {
        public int StudentContactId { get; set; }
        public int StudentContactTypeId { get; set; }
        public string Value { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }
        public StudentContactType StudentContactType { get; set; }
    }
}
