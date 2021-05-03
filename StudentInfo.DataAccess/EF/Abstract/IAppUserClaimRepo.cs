using ApplicationCore.Data;
using ApplicationCore.Entity.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.EF.Abstract
{
    public interface IAppUserClaimRepo : IBaseRepo<AppUserClaim>
    {
        Task<List<AppClaim>> GetUserClaimsByUserId(int userId);
    }
}
