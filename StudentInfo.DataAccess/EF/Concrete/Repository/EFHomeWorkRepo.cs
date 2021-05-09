using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFHomeWorkRepo : EFBaseRepo<HomeWork>, IHomeWorkRepo
    {
        public EFHomeWorkRepo(DbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<HomeWorkListDTO>> GetHomeWorkList()
        {
            return await GetListQueryable(p => !p.IsDeleted, p => p.ClassFK)
                     .Select(p => new HomeWorkListDTO
                     {
                         Id = p.Id,
                         CourseName = p.CourseName,
                         HomeworkSubject = p.HomeworkSubject,
                         HomeworkDesc = p.HomeworkDesc,
                         ClassName = p.ClassFK.Name
                     }).ToListAsync();
        }

        public async Task<List<HomeWorkListDTO>> GetHomeWorkWithClass(int classId)
        {
            return await GetListQueryable(p => !p.IsDeleted && (p.ClassId == classId) , p => p.ClassFK)
                     .Select(p => new HomeWorkListDTO
                     {
                         Id = p.Id,
                         CourseName = p.CourseName,
                         HomeworkSubject = p.HomeworkSubject,
                         HomeworkDesc = p.HomeworkDesc,
                         ClassName = p.ClassFK.Name
                     }).ToListAsync();
        }
    }
}
