using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInfoAPI.Entities;

[Table("Student_Course")]
public class CourseStudent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey(nameof(CourseId))]
    public int CourseId { get; set; }
    public Course Course { get; set; }

    [ForeignKey(nameof(StudentId))]
    public int StudentId { get; set; }
    public Student Student { get; set; }
}
