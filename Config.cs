using Microsoft.Extensions.DependencyInjection;

namespace WebAwesomeBlazor
{
    public static class Config
    {
        public static IServiceCollection AddWebAwesome(this IServiceCollection services)
        {
            services.AddScoped<Extended.IConfirmDialog, Extended.ConfirmDialogService>();
            services.AddScoped<ToastService>();
            return services;
        }

    }

}
