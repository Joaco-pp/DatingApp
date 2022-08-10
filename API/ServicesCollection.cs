using API.Services;

namespace API
{
    public static class ServicesCollection
    {
        public static IServiceCollection InitServices(this IServiceCollection services)
        {
            //Inject generic service
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            return services;
        }
    }

}