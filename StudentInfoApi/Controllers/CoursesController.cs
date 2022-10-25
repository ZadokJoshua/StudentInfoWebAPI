using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAPI.DTOs;

namespace StudentInfoAPI.Controllers
{
    [Route("api/students/{studentId}/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        //[HttpGet]
        //public ActionResult<IEnumerable<CourseDto>> GetCourses(int studentId)
        //{
        //    var student = DataStore.Data.Students.FirstOrDefault(s => s.Id == studentId);

        //    if (student == null)
        //    {
        //        return NotFound($"No student with id {studentId}");
        //    }

        //    return Ok(student.Courses);
        //}

        //[HttpGet("{courseId}")]
        //public ActionResult<CourseDto> GetCourse(int studentId, int courseId)
        //{
        //    var student = DataStore.Data.Students.FirstOrDefault(s => s.Id == studentId);

        //    if (student == null)
        //    {
        //        return NotFound($"No student with id {studentId}");
        //    }

        //    var course = student.Courses.FirstOrDefault(c => c.Id == courseId);

        //    if (course == null)
        //    {
        //        return NotFound($"{student.Name} has no course with id {courseId}");
        //    }

        //    return Ok(course);
        //}
    }
}
