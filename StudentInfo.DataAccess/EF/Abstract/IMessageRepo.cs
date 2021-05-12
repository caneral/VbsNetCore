using ApplicationCore.Data;
using StudentInfo.Entity.DTO.Message;
using StudentInfo.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IMessageRepo : IBaseRepo<Message>
    {

        Task<List<MessageListDTO>> GetMessageList(int? studentId);
        Task UpdateMessage(int id, MessageUpdateDTO messageUpdate);
        Task<List<MessageListDTO>> GetMessageWithClass(int classId);

    }
}
