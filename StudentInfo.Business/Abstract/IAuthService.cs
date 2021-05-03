using ApplicationCore.Entity;
using ApplicationCore.Entity.Identity;
using ApplicationCore.Utility.Security.Jwt;
using StudentInfo.Entity.DTO.Authentication;
using System.Threading.Tasks;

namespace StudentInfo.Business.Abstract
{
    public interface IAuthService
    {
        AppUser Register(UserRegisterDTO userRegisterDTO);
        Task<AppUser> Login(AppUserLoginDTO userForLoginDTO);
        Task<AccessToken> CreateAccessToken(AppUser user);
    }
}
