using Microsoft.Extensions.DependencyInjection;
using OrderFlow.Orders.Application.Interfaces;
using OrderFlow.Orders.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Orders.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrder, CreateOrder>();
            return services;
        }
    }
}
