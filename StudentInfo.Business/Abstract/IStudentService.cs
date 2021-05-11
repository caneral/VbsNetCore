using ApplicationCore.Entity;
using StudentInfo.Entity.DTO.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IStudentService
    {
        IEnumerable<StudentListDTO> ListStudent();
        IEnumerable<StudentListDTO> ListStudentWithClass(string classN);
        Task<int> AddStudent(StudentAddDTO studentAddDTO);
        Task<int> UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO);
        Task<int> DeleteStudent(int id);
        Task<int> GetTotalStudentCount();

    }
}
