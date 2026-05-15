using Microsoft.Extensions.DependencyInjection;
using WebAwesomeBlazor.Extended;

namespace WebAwesomeBlazor
{
    public static class Config
    {
        public static IServiceCollection AddWebAwesome(this IServiceCollection services)
        {
            services.AddScoped<IConfirmDialog, ConfirmDialogService>();
            services.AddScoped<ToastService>();
            return services;
        }

    }

}
