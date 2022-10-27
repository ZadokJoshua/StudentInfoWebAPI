using StudentInfoAPI.Entities;

namespace StudentInfoAPI.Data.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);

        void AddStudentAsync(Student student);

        void DeleteStudentAsync(int id);
    }
}
