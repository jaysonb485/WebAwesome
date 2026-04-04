using Microsoft.Extensions.DependencyInjection;

namespace WebAwesomeBlazor
{
    public static class Config
    {
        public static IServiceCollection AddWebAwesome(this IServiceCollection services, string KitCode, string WebAwesomeVersionCode = "3.5.0")
        {
            services.AddScoped<Extended.IConfirmDialog, Extended.ConfirmDialogService>();
            services.AddScoped<ToastService>();
            services.AddScoped<IWebAwesomeOptions>(x => new WebAwesomeOptions(KitCode, WebAwesomeVersionCode));
            return services;
        }

    }

}
