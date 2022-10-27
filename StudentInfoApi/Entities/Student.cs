using StudentInfoAPI.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace StudentInfoAPI.Entities;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = String.Empty;

    public string MatricNumber { get; set; } = String.Empty;

    public DateTime DateAdded { get; set; } = DateTime.UtcNow;


    public ICollection<CourseStudent> CourseStudent { get; set; } = new List<CourseStudent>();

}
