using ApplicationCore.Entity;
using StudentInfo.Entity.DTO.Teacher;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface ITeacherService
    {
        Task<int> AddTeacher(TeacherAddDTO teacherAddDTO);
        Task<int> AddStudentTeacher(int studentId, int teacherId);

    }
}
