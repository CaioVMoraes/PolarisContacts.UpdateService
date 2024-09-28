using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.Application.Interfaces.Messaging;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.UpdateService.Domain.Settings;
using PolarisContacts.UpdateService.Infrastructure.Messaging;
using PolarisContacts.UpdateService.Infrastructure.Repositories;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

public static partial class AddInfrastructureLayerExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services) =>
        services.AddBindedSettings<RabbitMqSettings>();

    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddTransient<IRabbitMqProducer, RabbitMqProducer>()
                .AddTransient<IUsuarioRepository, UsuarioRepository>();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddSettings()
            .AddRepositories();
}