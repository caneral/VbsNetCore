using ApplicationCore.Utility.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;
using StudentInfo.Business.Abstract;
using StudentInfo.Business.Concrete.Auth;

namespace StudentInfo.Infrastructure.DI
{
    public static class ServiceInstaller
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IHomeWorkService, HomeWorkService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ITokenHelper, TokenHelper>();
            return services;
        }
    }
}
