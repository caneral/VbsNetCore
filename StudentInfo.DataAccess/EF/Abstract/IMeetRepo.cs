using ApplicationCore.Data;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.DTO.Meet;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IMeetRepo: IBaseRepo<Meet>
    {
        Task<MeetDTO> GetMeetById(int studentId);
        Task UpdateMeet(int id);

    }
}
