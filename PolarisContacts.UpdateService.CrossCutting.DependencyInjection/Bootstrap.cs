using PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddApplicationLayer;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection;

public static class Bootstrap
{
    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddInfrastructure()
            .AddApplication();
}
