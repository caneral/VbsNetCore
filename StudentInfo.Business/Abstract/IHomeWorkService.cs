using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.DTO.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IHomeWorkService
    {
        Task<int> AddHomeWork(HomeWorkAddDTO homeWorkAddDTO);
        Task<List<HomeWorkListDTO>> GetHomeWorkList();

        /// <summary>
        /// Mesajları Listeleme (Öğrenci id varsa özel mesajları da dahil et)
        /// </summary>
        //Task<List<MessageListDTO>> GetMessageList(int? studentId);
        //Task<int> DeleteMessage(int id);

        //Task<int> UpdateMessage(int id, MessageUpdateDTO messageUpdate);

    }
}
