using ApplicationCore.Entity.Identity;
using System.Collections.Generic;

namespace ApplicationCore.Utility.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser user, List<AppClaim> appClaims);
    }
}
