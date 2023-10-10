using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentReposirory : GenericRepositoryAsync<Student>, IStudentReposirory
    {
        #region Fields

        private readonly DbSet<Student> _students;

        #endregion

        #region CTOR

        public StudentReposirory(ApplicationContext context) : base(context)
        {
            _students = context.Set<Student>();
        }

        #endregion

        #region Handles Functions

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _students.Include(d => d.Department).ToListAsync();
        }        

        #endregion

    }
}
