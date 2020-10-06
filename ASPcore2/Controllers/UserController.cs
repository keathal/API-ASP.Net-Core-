using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASPcore2.Models;

namespace ASPcore2.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        readonly dbGraduatesContext db;


        public UserController(dbGraduatesContext _db)
        {
            db = _db;
        }

        //getting personal info
        [Authorize]
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Student> GetUser(int id)
        {
            Student item = new Student();
            item = db.Student.Where(b => b.StudentId == id).FirstOrDefault();
            return item;
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult<bool> AddContact([FromQuery]int id, [FromQuery] int contactTypeId, [FromQuery] string value)
        {
            StudentContact item = new StudentContact();
            item.StudentContactTypeId = contactTypeId;
            item.StudentId = id;
            item.Value = value;

            try
            {
                db.StudentContact.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        [Authorize]
        [HttpDelete]
        public ActionResult<int> DeleteJournal([FromQuery]int id, [FromQuery]int id_work)
        {
            Journal item = db.Journal.Where(b => b.JournalId == id_work).FirstOrDefault();
            if (item != null)
            {
                if (item.StudentId == id)
                {
                    try
                    {
                        db.Journal.Remove(item);
                        db.SaveChanges();
                        return 1;
                    }
                    catch
                    {
                        return -1;
                    }
                }
                else
                    return -2;
            }
            else
                return -3;
        }
        
        [Authorize]
        [HttpPost("{id}")]
        public ActionResult<int> AddJournal(int id, [FromQuery] int id_city, [FromQuery] string company, [FromQuery] string link, [FromQuery] string post, 
            [FromQuery] int salary, [FromQuery] int id_currency, [FromQuery] bool canShow, [FromQuery] DateTime dateStart, [FromQuery] DateTime dateEnd)
        {
            if(db.Student.Where(b=>b.StudentId==id).FirstOrDefault()!=null)
            {
                Journal item = new Journal();
                item.StudentId = id;
                item.CityId = id_city;
                item.Company = company;
                item.Site = link;
                item.Position = post;
                item.Salary = Convert.ToDecimal(salary);
                item.CurrencyId = id_currency;
                item.CanShowSalary = canShow;
                item.DateBegin = dateStart;
                item.DateEnd = dateEnd;
                try
                {
                    db.Journal.Add(item);
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return -2;
                }
            }
            else
                return -1;
        }
    }
}
