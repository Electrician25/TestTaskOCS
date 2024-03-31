using TestTaskOCS.CrudService;
using TestTaskOCS.MeetingRequestInterface;

namespace TestTaskOCS.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationtServices(this IServiceCollection services)
        {
            services.AddTransient<IMeetingRequestCrudServices, MeetingRequestCrudService>();
            return services;
        }
    }
}