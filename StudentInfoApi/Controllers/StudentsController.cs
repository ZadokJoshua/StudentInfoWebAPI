using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAPI.Models;

namespace StudentInfoAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudents()
        {
            return Ok(DataStore.Data.Students);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("{studentId}")]
        public ActionResult<StudentDto> GetStudent(int studentId)
        {
            var studentsToReturn = DataStore.Data.Students.FirstOrDefault(s => s.Id == studentId);

            if(studentsToReturn == null)
            {
                return NotFound($"StudentId {studentId} not found");
            }   

            return Ok(studentsToReturn);
        }
    }
}
