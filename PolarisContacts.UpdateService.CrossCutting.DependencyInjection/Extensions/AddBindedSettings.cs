using Microsoft.Extensions.DependencyInjection;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddBindedSettings<TSettings>(this IServiceCollection services) where TSettings : class
    {
        services
           .AddOptions<TSettings>()
           .BindConfiguration(typeof(TSettings).Name)
           .ValidateDataAnnotations()
           .ValidateOnStart();

        return services;
    }
}
