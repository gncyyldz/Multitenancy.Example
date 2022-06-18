using Microsoft.Extensions.DependencyInjection;
using Multitenant.Example.Application.Abstractions;
using Multitenant.Example.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitenant.Example.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection collection)
        {
            collection.AddTransient<ITenantService, TenantService>();
        }
    }
}
