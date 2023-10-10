using SchoolProject.Data.Entities;

namespace SchoolProject.Sevice
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentListAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> AddAsync(Student student);
    }
}
