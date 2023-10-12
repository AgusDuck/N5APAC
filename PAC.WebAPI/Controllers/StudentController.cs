using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [AuthorizationFilter]
        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            if(student.Id == 0)
            {
                return BadRequest("Id de estudiante no valida");
            }
            _studentLogic.InsertStudents(student);
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            return Ok(_studentLogic.GetStudentById(id));
        }
    
        [HttpGet]
        public IActionResult GetAllStudents([FromQuery]int age)
        {
            return Ok(_studentLogic.GetStudents(age));
        }


    }
}
