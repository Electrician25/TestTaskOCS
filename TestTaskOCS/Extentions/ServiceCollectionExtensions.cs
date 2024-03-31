using TestTaskOCS.CrudService;
using TestTaskOCS.Interfaces;
using TestTaskOCS.JwtProvider;

namespace TestTaskOCS.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<IMeetingRequestCrudServices, MeetingRequestCrudServices>();
            services.AddTransient<IJwtService, JwtService>();
            return services;
        }
    }
}