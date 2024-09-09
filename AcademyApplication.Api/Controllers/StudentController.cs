using AcademyApplication.Application.Dtos.StudentDto;
using AcademyApplication.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public IActionResult Create(StudentCreateDto studentCreateDto)
        {
           
          
                return Ok(_studentService.Create(studentCreateDto));
        }
    }
}
