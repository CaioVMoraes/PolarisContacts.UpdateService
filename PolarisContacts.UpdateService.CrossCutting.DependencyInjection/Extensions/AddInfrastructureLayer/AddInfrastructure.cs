using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.Application.Interfaces.Messaging;
using PolarisContacts.UpdateService.Domain.Settings;
using PolarisContacts.UpdateService.Infrastructure.Messaging;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

public static partial class AddInfrastructureLayerExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services) =>
        services.AddBindedSettings<RabbitMqSettings>();

    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddTransient<IRabbitMqProducer, RabbitMqProducer>();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddSettings()
            .AddRepositories();
}