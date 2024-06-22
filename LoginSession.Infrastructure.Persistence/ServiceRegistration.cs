using LoginSession.Core.Application.Interfaces.IRespositories;
using LoginSession.Infrastructure.Persistence.Contexts;
using LoginSession.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration config)
        {
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(opt =>
                                           opt.UseInMemoryDatabase("DatabaseTest"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(opt =>
                                           opt.UseSqlServer(config.GetConnectionString("Default"),
                                           m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }


            //Di - Dpendecy Injection
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
