namespace StudentInfoAPI.DTOs;

public class StudentDto
{
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public string MatricNumber { get; set; } = String.Empty;

    public ICollection<CourseDto> Courses = new List<CourseDto>();
}
