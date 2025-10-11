using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService service;

        public StudentController(StudentService service)
        {
            this.service = service;
        }

        [HttpPost("Add")]
        public ActionResult AddStudent([FromBody] Student ob)
        {
           // slist.Add(ob);
          bool res= service.CreateStudent(ob);
            return res ? Ok("Data Is Added") : BadRequest("Data Not Added");
        }

        //[HttpGet("Retrive")]
        //public ActionResult GetStudents()
        //{
        //    return Ok(new {Message ="Data retrive", Data =new  });
        //}
    }
}
