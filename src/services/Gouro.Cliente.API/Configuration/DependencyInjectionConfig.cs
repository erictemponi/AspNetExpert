using Microsoft.Extensions.DependencyInjection;
using Gouro.Clientes.API.Data;
using Gouro.Clientes.API.Models;
using Gouro.Clientes.API.Data.Repository;

namespace Gouro.Clientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();
        }
    }
}