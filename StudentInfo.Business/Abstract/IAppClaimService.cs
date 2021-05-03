using ApplicationCore.Entity.Identity;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IAppClaimService
    {
        Task<int> AddAppClaim(AppUser user);
        AppClaim GetClaim(string claimName);
    }
}
