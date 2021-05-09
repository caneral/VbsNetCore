using ApplicationCore.Data;
using StudentInfo.Entity.DTO.Class;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IClassRepo: IBaseRepo<Class>
    {
        Task<List<ClassListDTO>> GetClassList();

    }
}
