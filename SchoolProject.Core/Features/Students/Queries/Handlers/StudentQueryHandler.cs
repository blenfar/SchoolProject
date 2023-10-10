using AutoMapper;
using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Sevice;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListReponse>>>
        , IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>
    {
        #region Fields

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        #endregion

        #region Handle Functions

        public async Task<Response<List<GetStudentListReponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentListAsync();
            var result = _mapper.Map<List<GetStudentListReponse>>(students);

            return Success(result);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);

            return student is null ?
                    NotFound<GetSingleStudentResponse>("Student not found !!!") :
                    Success(_mapper.Map<GetSingleStudentResponse>(student));
        }

        #endregion
    }
}
