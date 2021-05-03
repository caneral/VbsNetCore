using ApplicationCore.Entity.Identity;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class AppClaimService : IAppClaimService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddAppClaim(AppUser user)
        {
            await _unitOfWork.AppUsers.AddAppClaim(user);
            return await _unitOfWork.SaveAsync();
        }
        public AppClaim GetClaim(string claimName)
        {
            return _unitOfWork.AppClaims.Get(p => p.Name == claimName);
        }
    }
}
