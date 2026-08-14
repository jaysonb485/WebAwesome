using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAwesomeBlazor.Extended;

namespace WebAwesomeBlazor
{
    public static class Config
    {
        public static IServiceCollection AddWebAwesome(this IServiceCollection services)
        {
            services.AddScoped<IConfirmDialog, ConfirmDialogService>();
            services.AddScoped<ToastService>();
            services.TryAddScoped<HtmlRenderer>();
            return services;
        }

    }

}
