using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.DTO.Meet;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFMeetRepo : EFBaseRepo<Meet>, IMeetRepo
    {
        public EFMeetRepo(DbContext dbContext) : base(dbContext)
        {
            
        }
        
        public async Task<MeetDTO> GetMeetById(int studentId)
        {
            return await GetQueryable(p => !p.IsDeleted && p.StudentId == studentId)
                .Select(p => new MeetDTO
                {
                    MeetDate = p.MeetDate,
                    TeacherFullName = $"{p.TeacherFK.Name}" + " " + $"{p.TeacherFK.Surname}",
                    StudentId = p.StudentId
                }).FirstOrDefaultAsync();
        }
    }
}
