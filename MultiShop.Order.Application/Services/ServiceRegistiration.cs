using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Services
{
     public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection serviceDescriptors,IConfiguration configuration)
        {
            serviceDescriptors.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));

        }
    }
}
