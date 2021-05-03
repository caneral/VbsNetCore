using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApplicationCore.Utility.Security.Encryption
{
    /// <summary>
    /// Security Key Creator
    /// </summary>
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
