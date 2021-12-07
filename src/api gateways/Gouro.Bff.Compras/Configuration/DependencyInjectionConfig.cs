﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Gouro.WebApi.Core.Usuario;

namespace Gouro.Bff.Compras.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }
}
