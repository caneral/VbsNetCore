using ApplicationCore.Data;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IHomeWorkRepo: IBaseRepo<HomeWork>
    {
        Task<List<HomeWorkListDTO>> GetHomeWorkList();
        Task<List<HomeWorkListDTO>> GetHomeWorkWithClass(int classId);
        Task<int> GetTotalHomeWorkCount();
        Task<List<HomeWorkListDTO>> GetLastAdded5HomeWorks();
        Task<List<HomeWorkListDTO>> GetLastAddedHomeWork();

    }
}
