using ApplicationCore.Data.EF;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.Entity.Entity;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFTeacherRepo : EFBaseRepo<Teacher>, ITeacherRepo
    {
        public EFTeacherRepo(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
