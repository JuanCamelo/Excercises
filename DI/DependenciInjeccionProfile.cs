using Exercises.Application;
using Exercises.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Exercises.DI
{
    public static class DependenciInjeccionProfile
    {
        public static IServiceCollection AddDependencyInjeccion(this IServiceCollection service)
        {
            return service.AddTransient<IHomeService, HomeAppService>();
        }
    }
}
