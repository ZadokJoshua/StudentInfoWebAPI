using StudentInfoAPI.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInfoAPI.Entities;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    public ICollection<StudentDto> Students = new List<StudentDto>();


    public ICollection<CourseStudent> CourseStudent { get; set; } = new List<CourseStudent>();
}
