using StudentInfo.Entity.DTO.Class;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.DTO.Meet;
using StudentInfo.Entity.DTO.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IMeetService
    {
        Task<int> AddMeet(MeetAddDTO meetAddDTO);
        Task<MeetDTO> GetMeetById(int studentId);
        Task<int> UpdateMeetAsync(int id);
        Task<List<MeetListDTO>> GetMeetList();



    }
}
