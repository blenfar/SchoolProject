using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IStudentReposirory : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentListAsync();
    }
}
