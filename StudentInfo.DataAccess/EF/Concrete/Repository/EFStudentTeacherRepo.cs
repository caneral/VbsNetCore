using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.Entity;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFStudentTeacherRepo : EFBaseRepo<StudentTeacher>, IStudentTeacherRepo
    {
        public EFStudentTeacherRepo(DbContext dbContext) : base(dbContext)
        {

        }
        public async Task AddStudentTeacher(int teacherId, int studentId)
        {
            var studentTeacher = new StudentTeacher
            {
                StudentId = studentId,
                TeacherId = teacherId
            };
            await AddAsync(studentTeacher);
        }
    }
}
