using AutoMapper;
using FluentValidation.AspNetCore;
using Home_todo_list___common;
using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___core.BusinessLogic;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using Home_todo_list___infrastructure.Other;
using Home_todo_list___infrastructure.Repositories;
using Home_todo_list___web_api.Extensions;
using Home_todo_list___web_api.Helpers;
using Home_todo_list___web_api.Logging;
using Home_todo_list___web_api.Other;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System;
using System.IO;
using System.Text;

namespace Home_todo_list___web_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // configure controllers and fluent validation
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            GlobalSettings.Secret = appSettings.Secret;
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // configure DI for application services
            HomeTodoListDbContext.ConnectionString = appSettings.ConnectionString;
            services.AddDbContext<HomeTodoListDbContext>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<ICRUDLogic<ProjectModel, ProjectsPagedDto, ProjectDto>, ProjectLogic>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICRUDRepository<ProjectModel, ProjectsPagedDto, ProjectDto>, ProjectRepository>();

            services.AddSingleton(Configuration);
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.ConfigureCustomExceptionMiddleware();
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
