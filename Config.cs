using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vengage.WebAwesome
{
    public static class Config
    {
        public const string WebAwesomeBaseURL = "https://early.webawesome.com/webawesome@3.0.0-beta.6/dist";
        public static IServiceCollection AddWebAwesome(this IServiceCollection services)
        {
            services.AddScoped<Extended.ToastService>();
            return services;
        }

    }
}
