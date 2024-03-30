using TestTaskOCS.CrudService;
using TestTaskOCS.Interfaces;

namespace TestTaskOCS.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<IMeetingRequestCrudServices, MeetingRequestCrudServices>();
            return services;
        }
    }
}