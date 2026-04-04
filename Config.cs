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

    public class WebAwesomeOptions(string _KitCode, string _WebAwesomeVersionCode) : IWebAwesomeOptions
    {
        public string KitCode { get; set; } = _KitCode;
        public string WebAwesomeVersionCode { get; set; } = _WebAwesomeVersionCode;
    }

    public interface IWebAwesomeOptions
    {
        string KitCode { get; set; }
        string WebAwesomeVersionCode { get; set; }
    }
}
