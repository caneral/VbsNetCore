using ApplicationCore.Data;
using ApplicationCore.Entity.Identity;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IAppUserRepo : IBaseRepo<AppUser>
    {
        Task AddAppClaim(AppUser user);
    }
}
