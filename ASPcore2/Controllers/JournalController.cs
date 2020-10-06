using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPcore2.Models;
using Microsoft.AspNetCore.Authorization;


namespace ASPcore2.Controllers
{
    [Route("api/[controller]")]
    public class JournalController : Controller
    {
        readonly dbGraduatesContext db;


        public JournalController(dbGraduatesContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<Journal>> GetAllJournal()
        {
            List<City> cities = db.City.ToList();
            List<CityCountry> cityCountries = db.CityCountry.ToList();
            List<Currency> currencies = db.Currency.ToList();
            List<Student> students = db.Student.ToList();
            List<StudentGroup> groups = db.StudentGroup.ToList();

            List<Journal> result = new List<Journal>();
            foreach (Journal item in db.Journal)
            {
                Journal temp = new Journal();
                temp.JournalId = item.JournalId;
                temp.DateBegin = item.DateBegin;
                temp.DateEnd = item.DateEnd;
                temp.Company = item.Company;
                temp.Site = item.Site;
                temp.Position = item.Position;

                temp.CityId = item.CityId;
                temp.City = new City(cities.Where(o => o.CityId == item.CityId).FirstOrDefault());
                temp.City.CityCountry = new CityCountry(cityCountries.Where(o => o.CityCountryId == temp.City.CityCountryId).FirstOrDefault());

                temp.CurrencyId = item.CurrencyId;
                temp.Currency = new Currency(currencies.Where(o => o.CurrencyId == item.CurrencyId).FirstOrDefault());

                temp.StudentId = item.StudentId;
                temp.Student = new Student(students.Where(o => o.StudentId == item.StudentId).FirstOrDefault());
                temp.Student.StudentGroup = new StudentGroup(groups.Where(o => o.StudentGroupId == temp.Student.StudentGroupId).FirstOrDefault());

                if (!item.CanShowSalary)
                {
                    temp.Salary = null;
                    temp.Student.Name = "";
                    temp.Student.Surname = "";
                }
                result.Add(temp);
            }
            return result;
        }

        //getting all different companies
        [Authorize]
        [HttpGet("companies")]
        public ActionResult<List<Journal>> GetCompanies()
        {
            List<City> cities = db.City.ToList();
            List<CityCountry> cityCountries = db.CityCountry.ToList();
            List<Currency> currencies = db.Currency.ToList();
            List<Student> students = db.Student.ToList();
            List<StudentGroup> groups = db.StudentGroup.ToList();

            List<string> companies = new List<string>();
            List<Journal> result = new List<Journal>();
            foreach (Journal item in db.Journal)
            {
                if (!companies.Contains(item.Company))
                {
                    companies.Add(item.Company);
                    Journal temp = new Journal();
                    temp.JournalId = item.JournalId;
                    temp.Company = item.Company;
                    temp.Site = item.Site;

                    temp.CityId = item.CityId;
                    temp.City = new City(cities.Where(o => o.CityId == item.CityId).FirstOrDefault());
                    temp.City.CityCountry = new CityCountry(cityCountries.Where(o => o.CityCountryId == temp.City.CityCountryId).FirstOrDefault());

                    temp.CurrencyId = item.CurrencyId;
                    temp.Currency = new Currency(currencies.Where(o => o.CurrencyId == item.CurrencyId).FirstOrDefault());
                    result.Add(temp);

                }
            }
            return result;
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<List<Journal>> GetCompaniesByGroup(int id)
        {
            List<City> cities = db.City.ToList();
            List<CityCountry> cityCountries = db.CityCountry.ToList();
            List<Currency> currencies = db.Currency.ToList();
            List<Student> students = db.Student.ToList();
            List<StudentGroup> groups = db.StudentGroup.ToList();

            List<Journal> result = new List<Journal>();
            foreach (Journal item in db.Journal)
            {
                if (item.Student.StudentGroupId==id)
                {
                    Journal temp = new Journal();
                    temp.JournalId = item.JournalId;
                    temp.DateBegin = item.DateBegin;
                    temp.DateEnd = item.DateEnd;
                    temp.Company = item.Company;
                    temp.Site = item.Site;
                    temp.Position = item.Position;

                    temp.CityId = item.CityId;
                    temp.City = new City(cities.Where(o => o.CityId == item.CityId).FirstOrDefault());
                    temp.City.CityCountry = new CityCountry(cityCountries.Where(o => o.CityCountryId == temp.City.CityCountryId).FirstOrDefault());

                    temp.CurrencyId = item.CurrencyId;
                    temp.Currency = new Currency(currencies.Where(o => o.CurrencyId == item.CurrencyId).FirstOrDefault());

                    temp.StudentId = item.StudentId;
                    temp.Student = new Student(students.Where(o => o.StudentId == item.StudentId).FirstOrDefault());
                    temp.Student.StudentGroup = new StudentGroup(groups.Where(o => o.StudentGroupId == temp.Student.StudentGroupId).FirstOrDefault());

                    if (!item.CanShowSalary)
                    {
                        temp.Salary = null;
                        temp.Student.Name = "";
                        temp.Student.Surname = "";
                    }
                    result.Add(temp);

                }
            }
            return result;
        }

        [Authorize]
        [HttpPost]
        public ActionResult<int> AddCityCountry([FromQuery] string city, [FromQuery] string country, [FromQuery] float latitude, [FromQuery] float longtitude)
        {
            CityCountry countryItem = new CityCountry();
            countryItem.Name = country;
            try
               {
                db.CityCountry.Add(countryItem);
                db.SaveChanges();
                List<CityCountry> countries = db.CityCountry.ToList();
                City item = new City();
                item.Name = city;
                item.Latitude = latitude;
                item.Longtitude = longtitude;
                item.CityCountryId = countries.Where(b => b.Name == country).FirstOrDefault().CityCountryId;
                   try
                   {
                       db.City.Add(item);
                       db.SaveChanges();
                   return 1;
                   }
                   catch
                   {
                   return -2;
                   }
            }
           catch 
            {
               return -1;
            }
       }
    }
}