using StudentInfoAPI.Models;

namespace StudentInfoAPI
{
    public class DataStore
    {
        public List<StudentDto> Students { get; set; }

        public static DataStore Data { get; } = new DataStore(); 

        public DataStore()
        {
            Students = new List<StudentDto>()
            {
                // Student 1
                new StudentDto()
                {
                    Id = 1,
                    Name = "Zadok Joshua",
                    Courses = new List<CourseDto>()
                    {
                        new CourseDto()
                        {
                            Id = 1,
                            Name = "Strength of Material",
                            Grade = 'A'
                        },
                        new CourseDto()
                        {
                            Id = 2,
                            Name = "Thermodynamics",
                            Grade = 'C'
                        }
                    }
                },
                // Student 2
                new StudentDto()
                {
                    Id = 2,
                    Name = "Trinity Ikpe",
                    Courses = new List<CourseDto>()
                    {
                        new CourseDto()
                        {
                            Id = 1,
                            Name = "Hausa",
                            Grade = 'A'
                        },
                        new CourseDto()
                        {
                            Id = 2,
                            Name = "Maths",
                            Grade = 'C'
                        }
                    }
                },
                // Student 3
                new StudentDto()
                {
                    Id = 3,
                    Name = "James Sam",
                    Courses = new List<CourseDto>()
                    {
                        new CourseDto()
                        {
                            Id = 1,
                            Name = "Electronics",
                            Grade = 'A'
                        },
                        new CourseDto()
                        {
                            Id = 2,
                            Name = "Thermodynamics",
                            Grade = 'C'
                        },
                        new CourseDto()
                        {
                            Id = 3,
                            Name = "Hausa",
                            Grade = 'B'
                        }
                    }
                }
            };
        }
    }
}
