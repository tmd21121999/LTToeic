using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLTToeic.Infrastructure.Helper
{
    public static class BuildRepositories
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IExamRepository, ExamRepository>();
        }
    }
}
