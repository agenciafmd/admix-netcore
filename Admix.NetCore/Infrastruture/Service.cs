using Admix.NetCore.Repository.Generics;
using Microsoft.Extensions.DependencyInjection;


namespace Admix.NetCore.Infrastruture
{
    public static class Service
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository <> ), typeof(Repository <> ));  
            return services;
        }
    }
}
