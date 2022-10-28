using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAPI.Data;
using StudentInfoAPI.DTOs;
using StudentInfoAPI.Entities;

namespace StudentInfoAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentInfoDbContext _studentInfoDbContext;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(StudentInfoDbContext studentInfoDbContext, ILogger<StudentsController> logger)
        {
            _studentInfoDbContext = studentInfoDbContext;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    Name = "Zadok Joshua",
                    MatricNumber = "2017/345"
                },
                new Student()
                {
                    Id = 2,
                    Name = "Trinity Ikpe",
                    MatricNumber = "2017/343"
                },
                new Student()
                {
                    Id = 3,
                    Name = "James Sam",
                    MatricNumber = "2017/343"
                }
            });
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="studentId"></param>
        ///// <returns></returns>
        //[HttpGet("{studentId}")]
        //public ActionResult<StudentDto> GetStudent(int studentId)
        //{
        //    var studentsToReturn = DataStore.Data.Students.FirstOrDefault(s => s.Id == studentId);

        //    if(studentsToReturn == null)
        //    {
        //        return NotFound($"StudentId {studentId} not found");
        //    }   

        //    return Ok(studentsToReturn);
        //}
    }
}
