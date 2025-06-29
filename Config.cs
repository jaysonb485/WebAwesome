using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesome
{
    public static class Config
    {
        public static IServiceCollection AddWebAwesome(this IServiceCollection services)
        {
            services.AddScoped<ToastService>();
            return services;
        }

    }
}
