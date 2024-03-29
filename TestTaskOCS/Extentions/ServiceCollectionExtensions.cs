using TestTaskOCS.CrudService;

namespace TestTaskOCS.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationContextServices(this IServiceCollection services)
        {
            services.AddTransient<MeetingRequestCrudServices>();
            return services;
        }
    }
}