using Microsoft.Extensions.DependencyInjection;
using StudentApp_DataAccessLayer.Interfaces;
using StudentApp_DataAccessLayer.Repository;
using StudentApp_Services.Interfaces;
using StudentApp_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp_API.Configurations
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentResultRepository, StudentResultRepository>();
            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentResultService, StudentResultService>();
            return services;
        }
    }
}
