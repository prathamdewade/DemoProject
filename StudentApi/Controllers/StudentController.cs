using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.DTO;
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
            return res ? Ok(ob) : BadRequest("Data Not Added");
        }

        [HttpGet("Retrive")]
        public ActionResult GetStudents()
        {
            IList<Student> slist=service.GetAllStudents();
            if(slist.Count() > 0)
            {
              return  Ok(new { Message = "Data Retrive", Data = slist });
            }
             return  BadRequest(new { Message = "Data Not Found" });
        }
        [HttpGet("GetById{id}")]
        public ActionResult GetStudent(int id)
        {
            Student s=service.GetAllStudents().FirstOrDefault(ob=> ob.Id==id);
          return  s != null ? Ok(new { Messege = "Data Fetch By Id", Data = s }) :
                  NotFound("Data Not Found");
        }
        //update by id
        [HttpPut("upadte")]
        public ActionResult Update(int id , [FromBody] StudentDto ob)
        {
            Student s = new Student() { Id = id , Name=ob.Name, Marks=ob.Marks};
            return Ok(s);
        }
    }
}
