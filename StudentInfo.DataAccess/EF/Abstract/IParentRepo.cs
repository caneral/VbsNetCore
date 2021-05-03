using ApplicationCore.Data;
using StudentInfo.Entity.DTO.Parent;
using StudentInfo.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IParentRepo : IBaseRepo<Parent>
    {
        Task UpdateParent(int id, ParentUpdateDTO parentUpdateDTO);
        Task<List<ParentListDTO>> ParentList();
    }
}
