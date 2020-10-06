using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPcore2.Models;

namespace ASPcore2.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : Controller
    {
        readonly dbGraduatesContext db;


        public LoginController(dbGraduatesContext _db)
        {
            db = _db;
        }

       //checking if answer is right  
       [HttpPost]
       public ActionResult<int> CheckAnswer([FromQuery] string surname,[FromQuery] string name, [FromQuery] string patr, [FromQuery] DateTime date, [FromQuery] string answer)
       {
           Student sItem = db.Student.Where(b => b.Surname == surname).FirstOrDefault();
           if(sItem!=null)
           {
               if (sItem.Name == name && sItem.Patronymic == patr && sItem.BirthDate == date)
               {
                   StudentGroup item = db.StudentGroup.Where(b => b.StudentGroupId == sItem.StudentGroupId).FirstOrDefault();
                   if (item != null)
                   {
                       if (item.Answer == answer)
                           return 1;
                       else
                           return -1;
                   }
                   else
                       return -4;
               }
               else
                   return -3;
           }
           else
               return -2;
       }

        [HttpGet]
        public ActionResult<String> GetQuestion([FromQuery]int id, [FromQuery] string surname, [FromQuery] string name, [FromQuery] string patr, [FromQuery] DateTime date)
        {
            Student item = db.Student.Where(b => b.Surname == surname).FirstOrDefault();
            if (item != null)
            {
                if (item.Name == name && item.Patronymic == patr && item.BirthDate == date && item.StudentGroupId == id)
                    return "question";
                else
                    return
                        "wrong data";
            }
            else
                return "student not found";
        }
    }
}