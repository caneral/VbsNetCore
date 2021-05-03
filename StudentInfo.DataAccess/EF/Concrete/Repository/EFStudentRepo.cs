using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.DTO.Student;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFStudentRepo : EFBaseRepo<Student>, IStudentRepo
    {
        public EFStudentRepo(DbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<StudentListDTO> ListStudent()
        {
            return GetListQueryable(p => !p.IsDeleted, p => p.ParentFK)
                .Select(p => new StudentListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Number = p.Number,
                    TCNumber = p.TCNumber,
                    ParentName = p.ParentFK.Name,
                    ParentSurname = p.ParentFK.Surname
                }).AsEnumerable();
        }

        public async Task UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO)
        {
            var currentStudent = await GetByIdAsync(id);
            Update(currentStudent);
            currentStudent.Name = studentUpdateDTO.Name;
            currentStudent.Surname = studentUpdateDTO.Surname;
            currentStudent.Number = studentUpdateDTO.Number;
            currentStudent.ParentId = studentUpdateDTO.ParentId;
            currentStudent.ModifiedDate = DateTime.Now;

        }
    }
}
