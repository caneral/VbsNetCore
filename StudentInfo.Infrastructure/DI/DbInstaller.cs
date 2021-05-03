using Microsoft.Extensions.DependencyInjection;
using StudentInfo.DataAccess.EF.Concrete.Context;
using StudentInfo.DataAccess.UOW;

namespace StudentInfo.Infrastructure.DI
{
    public static class DbInstaller
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<StudentInfoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
