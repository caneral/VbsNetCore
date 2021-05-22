using ApplicationCore.Utility.Mapper;
using ApplicationCore.Utility.Security.Encryption;
using ApplicationCore.Utility.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudentInfo.Business.Abstract;
using StudentInfo.Business.Concrete.Auth;
using StudentInfo.DataAccess.MongoDB;
using StudentInfo.Infrastructure.DI;
using System;
using System.Collections.Generic;

namespace StudentInfo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    // Servisi belirli bir adresten gelen taleplere ama
                    //builder.WithOrigins("http://localhost:3000","http://94.73.164.170:")
                    // Servisi tm taleplere ama
                     builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentInfo.WebApi", Version = "v1" });
            });
            services.AddSingleton<IMapper, Mapper>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppClaimService, AppClaimService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddPersistence();
            services.AddService();
            services.AddScoped<MongoDbContext>();
            services.Configure<MongoOptions>(Configuration.GetSection("MongoOptions"));


            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtopt =>
            {
                jwtopt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    // Check the tokens validation time.
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{"/vbsadmin"}" } };
                    });

                });
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./v1/swagger.json", "StudentInfo.WebAPI v1");
                    //c.SwaggerEndpoint("/test/swagger/v1/swagger.json", "Test.WebAPI v1");
                });
                app.UseCors(option =>
                 option.AllowAnyOrigin()
                     .AllowAnyMethod()
                      .AllowAnyHeader()
         );
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
