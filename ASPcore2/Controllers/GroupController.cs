using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPcore2.Models;

namespace ASPcore2.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        readonly dbGraduatesContext db;

        public GroupController(dbGraduatesContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<List<StudentGroup>> GetAllStudentGroup()
        {
            List<StudentGroup> result = new List<StudentGroup>();
            foreach (StudentGroup item in db.StudentGroup)
            {
                StudentGroup temp = new StudentGroup();
                temp.StudentGroupId = item.StudentGroupId;
                temp.Name = item.Name;
                temp.FirstYear = item.FirstYear;
                temp.LastYear = item.LastYear;
                temp.Answer = item.Answer;
                result.Add(temp);
            }
            return result;
        }
    }
}