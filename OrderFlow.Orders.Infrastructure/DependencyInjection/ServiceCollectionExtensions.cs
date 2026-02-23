using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderFlow.Orders.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderFlow.Orders.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OrdersDb");
            if (string.IsNullOrWhiteSpace(connectionString)) throw new InvalidOperationException("There is no Connection String");
            services.AddDbContext<OrdersDbContext>(x => x.UseNpgsql(connectionString));
            return services;
        }
    }
}
