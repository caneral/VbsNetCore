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
        IEnumerable<StudentListDTO> ListStudentWithClass(string classN);
        Task UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO);
        Task<int> GetTotalStudentCount();

    }
}
