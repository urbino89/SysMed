using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SysMed.Infrastructure.AppSetup
{
    public static class OptionsSetup
    {
        /// <summary>
        /// Add application options
        /// </summary>
        public static IServiceCollection AddAppOptions(
            this IServiceCollection services,
            IConfigurationRoot configuration)
        {
            services.AddOptions();

            return services;
        }
    }
}
