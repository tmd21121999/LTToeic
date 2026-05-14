using CoreLTToeic.Application.Business;
using CoreLTToeic.Application.Interfaces.IService;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLTToeic.Infrastructure.Helper
{
    public static class BuildServices
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IUserResultService, UserResultService>();
        }
    }
}
