using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.DTO.HomeWork;
using StudentInfo.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFClassRepo : EFBaseRepo<Class>, IClassRepo
    {
        public EFClassRepo(DbContext dbContext) : base(dbContext)
        {
            
        }


    }
}
