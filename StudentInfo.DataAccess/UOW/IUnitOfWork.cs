using StudentInfo.DataAccess.EF.Abstract;
using System;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.UOW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IMessageRepo Messages { get; }
        IParentRepo Parents { get; }
        IStudentRepo Students { get; }
        IStudentTeacherRepo StudentTeachers { get; }
        ITeacherRepo Teachers { get; }
        IHomeWorkRepo HomeWorks { get; }
        IClassRepo Classes { get; }
        IAppUserClaimRepo AppUserClaims { get; }
        IAppClaimRepo AppClaims { get; }
        IAppUserRepo AppUsers { get; }

        int Save();

        Task<int> SaveAsync();

        Task<int> SaveTransactionAsync();
    }
}
