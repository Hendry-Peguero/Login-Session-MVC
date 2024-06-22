using LoginSession.Core.Application.Interfaces.IServices;
using LoginSession.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LoginSession.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {

            //Di - Dpendecy Injection
            services.AddTransient<IUserService, UserService>();
        }
    }
}
