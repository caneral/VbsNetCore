using ApplicationCore.Utility.Mapper;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.Teacher;
using StudentInfo.Entity.Entity;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddStudentTeacher(int studentId, int teacherId)
        {
            await _unitOfWork.StudentTeachers.AddStudentTeacher(teacherId, studentId);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> AddTeacher(TeacherAddDTO teacherAddDTO)
        {
            var teacher = _mapper.Map<TeacherAddDTO, Teacher>(teacherAddDTO);
            await _unitOfWork.Teachers.AddAsync(teacher);
            return await _unitOfWork.SaveAsync();
        }
    }
}
