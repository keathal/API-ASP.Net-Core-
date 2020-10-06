using System;
using System.Collections.Generic;

namespace ASPcore2.Models
{
    public partial class Journal
    {
        public int JournalId { get; set; }
        public int StudentId { get; set; }
        public int CityId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Company { get; set; }
        public string Site { get; set; }
        public decimal? Salary { get; set; }
        public bool CanShowSalary { get; set; }
        public string Position { get; set; }
        public int CurrencyId { get; set; }

        public City City { get; set; }
        public Currency Currency { get; set; }
        public Student Student { get; set; }
    }
}
