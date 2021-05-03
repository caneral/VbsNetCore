using ApplicationCore.Data;
using StudentInfo.Entity.Entity;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IStudentTeacherRepo : IBaseRepo<StudentTeacher>
    {
        Task AddStudentTeacher(int teacherId, int studentId);
    }
}
