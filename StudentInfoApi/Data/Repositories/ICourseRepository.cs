
using StudentInfoAPI.Entities;

namespace CourseInfoAPI.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course?> GetCourseByIdAsync(int courseId);

        Task AddCourseAsync(Course Course);

        void DeleteCourseAsync(Course course);

        Task<bool> SaveChangesAsync();
    }
}
