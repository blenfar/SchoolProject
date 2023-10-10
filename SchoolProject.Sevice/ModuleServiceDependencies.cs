using Microsoft.Extensions.DependencyInjection;

namespace SchoolProject.Sevice
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }
    }
}