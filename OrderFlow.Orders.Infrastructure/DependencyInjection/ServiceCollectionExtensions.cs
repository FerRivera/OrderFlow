using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderFlow.Orders.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Infrastructure.Repositories;

namespace OrderFlow.Orders.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OrdersDb");
            if (string.IsNullOrWhiteSpace(connectionString)) throw new InvalidOperationException("Missing connection string 'OrdersDb'.");
            services.AddDbContext<OrdersDbContext>(x => 
            x.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            return services;
        }
    }
}
