using ApplicationCore.Data.EF;
using ApplicationCore.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFAppClaimRepo : EFBaseRepo<AppClaim>, IAppClaimRepo
    {
        public EFAppClaimRepo(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
