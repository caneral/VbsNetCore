using ApplicationCore.Entity.Identity;
using StudentInfo.Business.Abstract;
using StudentInfo.DataAccess.UOW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<AppClaim>> GetUserClaimsByUserId(int userId)
        {
            return await _unitOfWork.AppUserClaims.GetUserClaimsByUserId(userId);
        }
        public async Task<int> Add(AppUser user)
        {
            await _unitOfWork.AppUsers.AddAsync(user);
            return await _unitOfWork.SaveAsync();
        }
        public async Task<AppUser> GetByUserName(string userName)
        {
            var aa = await _unitOfWork.AppUsers.GetAsync(p => p.UserName == userName);
            return await _unitOfWork.AppUsers.GetAsync(p => p.UserName == userName);
        }
    }
}
