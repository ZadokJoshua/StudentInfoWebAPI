using CourseInfoAPI.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Entities;

namespace StudentInfoAPI.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentInfoDbContext _studentInfoDbContext;
        private readonly ILogger<CourseRepository> _logger;

        public CourseRepository(StudentInfoDbContext studentInfoDbContext, ILogger<CourseRepository> logger)
        {
            _studentInfoDbContext = studentInfoDbContext ?? throw new ArgumentNullException(nameof(studentInfoDbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task AddCourseAsync(Course Course)
        {
            await _studentInfoDbContext.Courses.AddAsync(Course);
        }

        public void DeleteCourseAsync(Course course)
        {
            _studentInfoDbContext.Courses.Remove(course);
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
        {
            return await _studentInfoDbContext.Courses.Where(c => c.Id == courseId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _studentInfoDbContext.Courses.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _studentInfoDbContext.SaveChangesAsync() >= 1;
        }
    }
}
