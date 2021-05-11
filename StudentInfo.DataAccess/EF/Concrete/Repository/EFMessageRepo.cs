using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.DTO.Message;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFMessageRepo : EFBaseRepo<Message>, IMessageRepo
    {
        public EFMessageRepo(DbContext dbContext) : base(dbContext)
        {

        }
        /// <summary>
        /// ********
        /// </summary>
        public async Task<List<MessageListDTO>> GetMessageList(int? classId)
        {
            return await GetListQueryable(p => !p.IsDeleted && (p.ClassId == classId || p.ClassId == null), p => p.TeacherFK)
                 .Select(p => new MessageListDTO
                 {
                     Id = p.Id,
                     Desc = p.Desc,
                     TeacherName = p.TeacherFK.Name,
                     TeacherSurname = p.TeacherFK.Surname
                 }).ToListAsync();
        }


        public async Task UpdateMessage(int id, MessageUpdateDTO messageUpdate)
        {
            var currentMessage = await GetByIdAsync(id);
            Update(currentMessage);
            currentMessage.Desc = messageUpdate.Desc;
            currentMessage.ClassId = messageUpdate.ClassId;
            currentMessage.TeacherId = messageUpdate.TeacherId;
        }
    }
}
