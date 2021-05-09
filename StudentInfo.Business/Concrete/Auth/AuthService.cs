using ApplicationCore.Entity.Identity;
using ApplicationCore.Utility.Security.Hashing;
using ApplicationCore.Utility.Security.Jwt;
using StudentInfo.Business.Abstract;
using StudentInfo.Entity.DTO.Authentication;
using StudentInfo.Entity.Entity;
using System.Threading.Tasks;

namespace StudentInfo.Business.Concrete.Auth
{
    public class AuthService : IAuthService
    {
        public ITokenHelper _tokenHelper;
        private readonly IAppUserService _appUserService;
        private readonly IAppClaimService _appClaimService;

        public AuthService(ITokenHelper tokenHelper, IAppUserService appUserService,
            IAppClaimService appClaimService)
        {
            _tokenHelper = tokenHelper;
            _appUserService = appUserService;
            _appClaimService = appClaimService;
        }
        public async Task<AccessToken> CreateAccessToken(AppUser user)
        {
            var userClaimList = await _appUserService.GetUserClaimsByUserId(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, userClaimList);
            return accessToken;
        }

        public async Task<AppUser> Login(AppUserLoginDTO userForLoginDTO)
        {
            var appUser = await _appUserService.GetByTCNumber(userForLoginDTO.TCNumber);
            if (appUser == null)
            {
                return null;
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDTO.Password, appUser.PasswordHash,
               appUser.PasswordSalt))
            {
                return null;
            }

            return appUser;
        }

        public AppUser Register(UserRegisterDTO userRegisterDTO)
        {
            HashingHelper.CreatePasswordHash(userRegisterDTO.Password, out byte[] passwordHash,
    out byte[] passwordSalt);
            var newUser = new AppUser
            {
                TCNumber = userRegisterDTO.TCNumber,
                Email = userRegisterDTO.Email,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
            };


            if (userRegisterDTO.UserRole == 1)
            {
                var claim = _appClaimService.GetClaim(AppClaimEnum.Teacher.ToString());
                newUser.AppUserClaims.Add(new AppUserClaim
                {
                    AppClaimId = claim.Id
                });
            }
            else if (userRegisterDTO.UserRole == 2)
            {
                var claim = _appClaimService.GetClaim(AppClaimEnum.Parent.ToString());
                newUser.AppUserClaims.Add(new AppUserClaim
                {
                    AppClaimId = claim.Id
                });
            }
            else if(userRegisterDTO.UserRole == 3)
            {
                var claim = _appClaimService.GetClaim(AppClaimEnum.Admin.ToString());
                newUser.AppUserClaims.Add(new AppUserClaim
                {
                    AppClaimId = claim.Id
                });
            }
            _appUserService.Add(newUser);

            return newUser;
        }
    }
}
