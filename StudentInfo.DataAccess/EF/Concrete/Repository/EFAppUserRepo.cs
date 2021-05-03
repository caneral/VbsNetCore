using ApplicationCore.Data.EF;
using ApplicationCore.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using StudentInfo.DataAccess.EF.Abstract;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Concrete.Repository
{
    public class EFAppUserRepo : EFBaseRepo<AppUser>, IAppUserRepo
    {
        public EFAppUserRepo(DbContext dbContext) : base(dbContext)
        {

        }
        public async Task AddAppClaim(AppUser user)
        {
            await GetByIdAsync(user.Id);
            await AddAsync(user);
        }
    }
}
