using Microsoft.Extensions.DependencyInjection;
using Template.Application.Interfaces;
using Template.Application.Services;

namespace Template.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registra o serviço IUserService com a implementação UserService
            services.AddScoped<IUserService, UserService>();
        }
    }
}
