using ApplicationCore.Data;
using StudentInfo.Entity.DTO.Student;
using StudentInfo.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IStudentRepo : IBaseRepo<Student>
    {
        IEnumerable<StudentListDTO> ListStudent();
        Task UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO);
    }
}
