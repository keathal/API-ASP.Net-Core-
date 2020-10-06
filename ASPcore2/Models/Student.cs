using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class Student
    {
        public Student()
        {
            Journal = new HashSet<Journal>();
            StudentContact = new HashSet<StudentContact>();
        }
        public Student(Student s)
        {
            if (s != null)
            {
                StudentId = s.StudentId;
                Surname = s.Surname;
                Patronymic = s.Patronymic;
                StudentGroupId = s.StudentGroupId;
                BirthDate = s.BirthDate;
            }
            Journal = new HashSet<Journal>();
            StudentContact = new HashSet<StudentContact>();
        }
        public int StudentId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int StudentGroupId { get; set; }
        public DateTime BirthDate { get; set; }

        public StudentGroup StudentGroup { get; set; }
        public ICollection<Journal> Journal { get; set; }
        public ICollection<StudentContact> StudentContact { get; set; }
    }
}
