using StudentInfo.DataAccess.EF.Abstract;
using StudentInfo.DataAccess.EF.Concrete.Context;
using StudentInfo.DataAccess.EF.Concrete.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Transactions;

namespace StudentInfo.DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentInfoDbContext _dbContext;
        private EFMessageRepo _messageRepo;
        private EFParentRepo _parentRepo;
        private EFStudentRepo _studentRepo;
        private EFStudentTeacherRepo _studentTeacherRepo;
        private EFTeacherRepo _teacherRepo;
        private EFAppUserRepo _appUserRepository;
        private EFAppClaimRepo _appClaimRepository;
        private EFAppUserClaimRepo _appUserClaimRepository;

        public IMessageRepo Messages => _messageRepo ??= new EFMessageRepo(_dbContext);
        public IParentRepo Parents => _parentRepo ??= new EFParentRepo(_dbContext);
        public IStudentRepo Students => _studentRepo ??= new EFStudentRepo(_dbContext);
        public IStudentTeacherRepo StudentTeachers => _studentTeacherRepo ??= new EFStudentTeacherRepo(_dbContext);
        public ITeacherRepo Teachers => _teacherRepo ??= new EFTeacherRepo(_dbContext);
        public IAppUserRepo AppUsers => _appUserRepository ??= new EFAppUserRepo(_dbContext);
        public IAppClaimRepo AppClaims => _appClaimRepository ??= new EFAppClaimRepo(_dbContext);
        public IAppUserClaimRepo AppUserClaims => _appUserClaimRepository ??= new EFAppUserClaimRepo(_dbContext);


        public UnitOfWork(StudentInfoDbContext context)
        {
            _dbContext = context;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveTransactionAsync()
        {
            int result = -1;
            try
            {
                using TransactionScope tScope = new();
                result = await _dbContext.SaveChangesAsync();
                tScope.Complete();
            }
            catch (ValidationException)
            {
                // Todo: Hata yaz. 
            }
            catch (Exception)
            {
                // Todo: Hata yaz. 
            }
            return result;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
