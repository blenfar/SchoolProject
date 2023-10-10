using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Sevice;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        #region Fields

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //Mapping between request to student
            var studentMapper = _mapper.Map<Student>(request);

            //Add student
            var result = await _studentService.AddAsync(studentMapper);

            //Check conditions
            if (result.Equals("Exists"))
            {
                return UnprocessableEntity<string>("Name is exists");
            }                
            else if (result.Equals("Success"))
            {
                return Created<string>("Added Succed");
            }                
            else
            {
                return BadRequest<string>();
            }                
        }

        #endregion

    }
}
