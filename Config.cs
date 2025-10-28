using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAwesomeBlazor
{
    public static class Config
    {
        public static IServiceCollection AddWebAwesome(this IServiceCollection services)
        {
            return services;
        }

    }
}
