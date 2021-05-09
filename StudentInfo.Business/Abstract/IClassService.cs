using StudentInfo.Entity.DTO.Class;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.DTO.Message;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IClassService
    {
        Task<int> AddClass(ClassAddDTO classAddDTO);


    }
}
