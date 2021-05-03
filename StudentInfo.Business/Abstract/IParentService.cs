using StudentInfo.Entity.DTO.Parent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IParentService
    {
        //Task<>
        Task<int> AddParent(ParentAddDTO parentAddDTO);
        Task<int> UpdateParent(int id, ParentUpdateDTO parentUpdateDTO);
        Task<List<ParentListDTO>> ParentList();
        void DeleteParent(int id);
    }
}
