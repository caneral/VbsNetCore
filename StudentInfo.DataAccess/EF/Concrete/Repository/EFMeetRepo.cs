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
            return await GetQueryable(p => !p.IsDeleted && p.StudentId == studentId && p.IsOkay == 0)
                .OrderByDescending(p => p.Id)
                .Take(1)
                .Select(p => new MeetDTO
                {
                    Id = p.Id,
                    MeetDate = p.MeetDate,
                    TeacherFullName = $"{p.TeacherFK.Name}" + " " + $"{p.TeacherFK.Surname}",
                    StudentId = p.StudentId
                }).FirstOrDefaultAsync();
        }

        public async Task UpdateMeet(int id)
        {
            var currentMeet = await GetByIdAsync(id);
            Update(currentMeet);
            currentMeet.IsOkay = 1;
            currentMeet.ModifiedDate = DateTime.Now;
        }

       
    }
}
