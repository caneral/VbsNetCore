using ApplicationCore.Entity.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentInfo.DataAccess.EF.Concrete.Context;
using StudentInfo.Entity.Entity;
using System;
using System.Linq;

namespace StudentInfo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    var context = service.GetRequiredService<StudentInfoDbContext>();
                    // If table not exist, make migration itself
                    context.Database.Migrate();

                    // Add role if not exist.
                    var appClaimsAny = context.AppClaims.Any();
                    if (!appClaimsAny)
                    {
                        var claimList = Enum.GetValues(typeof(AppClaimEnum)).Cast<AppClaimEnum>();
                        foreach (var claimItem in claimList)
                        {
                            context.Add(new AppClaim
                            {
                                Name = claimItem.ToString()
                            });
                        }
                       context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
