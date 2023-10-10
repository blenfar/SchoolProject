using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;

namespace SchoolProject.Sevice
{
    public class StudentService : IStudentService
    {
        #region Fields

        private readonly IStudentReposirory _studentRepository;

        #endregion

        #region CTOR

        public StudentService(IStudentReposirory studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion

        #region Handle Functions

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentRepository.GetStudentListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetTableNoTracking()
                                           .Include(x => x.Department)
                                           .Where(x => x.StudId.Equals(id))
                                           .FirstOrDefaultAsync();
        }

        public async Task<string> AddAsync(Student student)
        {
            //Check Name exists or not
            var studentResult = await _studentRepository.GetTableNoTracking().Where(c => c.Name.Equals(student.Name)).FirstOrDefaultAsync();
            if (studentResult is not null)
            {
                return "Exists";
            }

            //Add Student
            await _studentRepository.AddAsync(student);

            return "Success";
        }

        #endregion
    }
}
