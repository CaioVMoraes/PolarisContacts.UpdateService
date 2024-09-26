using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddApplicationLayer;
using PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection;

public static class Bootstrap
{
    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddInfrastructure()
            .AddApplication();
}
