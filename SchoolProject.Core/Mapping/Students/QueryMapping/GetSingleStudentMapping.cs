using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetSingleStudentMapping()
        {
            CreateMap<Student, GetSingleStudentResponse>()
                .ForMember(desc => desc.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
