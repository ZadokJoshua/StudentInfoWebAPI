namespace StudentInfoAPI.Models
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int CoursesCount
        {
            get
            {
                return Courses.Count;
            }
        }

        public ICollection<CourseDto> Courses = new List<CourseDto>();
    }
}
