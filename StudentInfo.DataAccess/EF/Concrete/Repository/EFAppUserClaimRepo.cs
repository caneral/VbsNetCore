using ApplicationCore.Data.EF;
using ApplicationCore.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFAppUserClaimRepo : EFBaseRepo<AppUserClaim>, IAppUserClaimRepo
    {
        public EFAppUserClaimRepo(DbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<AppClaim>> GetUserClaimsByUserId(int userId)
        {
            return await GetListQueryable(p => p.AppUserId == userId, p => p.AppClaimFK)
                .Select(p => p.AppClaimFK).ToListAsync();
        }
    }
}
