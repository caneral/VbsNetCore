using ApplicationCore.Entension;
using ApplicationCore.Entity.Identity;
using ApplicationCore.Utility.Security.Encryption;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace ApplicationCore.Utility.Security.Jwt
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public TokenHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }
        public AccessToken CreateToken(AppUser user, List<AppClaim> appClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, appClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser user,
            SigningCredentials signingCredentials, List<AppClaim> appClaims)
        {
            var jwt = new JwtSecurityToken(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, appClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(AppUser user, List<AppClaim> appClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.TCNumber.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(appClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
