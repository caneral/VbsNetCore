using ApplicationCore.Entity.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IAppUserService
    {
        Task<int> Add(AppUser user);
        Task<List<AppClaim>> GetUserClaimsByUserId(int userId);
        Task<AppUser> GetByTCNumber(string tcNumber);
    }
}
