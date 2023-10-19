
using Microsoft.Extensions.DependencyInjection;
using RestaurantOrder.Core.Contracts.Services;
using RestaurantOrder.Services;

namespace RestaurantOrder.IOC
{
    public static class ServicesInjection
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>(); 
        }
    }
}
