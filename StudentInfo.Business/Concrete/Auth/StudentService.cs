using ApplicationCore.Utility.Mapper;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using StudentInfo.Entity.DTO.Student;
using StudentInfo.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddStudent(StudentAddDTO studentAddDTO)
        {
            var student = _mapper.Map<StudentAddDTO, Student>(studentAddDTO);
            await _unitOfWork.Students.AddAsync(student);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteStudent(int id)
        {
            _unitOfWork.Students.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public IEnumerable<StudentListDTO> ListStudent()
        {
            return _unitOfWork.Students.ListStudent();
        }
        public IEnumerable<StudentListDTO> ListStudentWithClass(string classN)
        {
            return _unitOfWork.Students.ListStudentWithClass(classN);
        }

        public Task<int> UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO)
        {
            _unitOfWork.Students.UpdateStudent(id, studentUpdateDTO);
            return _unitOfWork.SaveAsync();
        }
        public Task<int> GetTotalStudentCount()
        {
            return _unitOfWork.Students.GetTotalStudentCount();
        }
    }
}
