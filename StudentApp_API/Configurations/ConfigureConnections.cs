using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentApp_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp_API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var masterConnection = configuration.GetConnectionString("StudentMasterDb");
            services.AddDbContext<StudentDatabaseContext>(options =>
            {
                options.UseSqlServer(masterConnection);
            }, ServiceLifetime.Scoped);


            return services;
        }
    }
}
