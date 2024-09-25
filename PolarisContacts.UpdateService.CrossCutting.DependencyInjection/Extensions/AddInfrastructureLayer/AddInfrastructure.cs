using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.Application.Interfaces.Repositories;
using PolarisContacts.Domain.Settings;
using PolarisContacts.UpdateService.Infrastructure.Repositories;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddInfrastructureLayer;

public static partial class AddInfrastructureLayerExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services) =>
        services.AddBindedSettings<DbSettings>();

    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IContatoRepository, ContatoRepository>()
                .AddTransient<ITelefoneRepository, TelefoneRepository>()
                .AddTransient<ICelularRepository, CelularRepository>()
                .AddTransient<IEmailRepository, EmailRepository>()
                .AddTransient<IEnderecoRepository, EnderecoRepository>()
                .AddTransient<PolarisContacts.DatabaseConnection.IDatabaseConnection, PolarisContacts.DatabaseConnection.DatabaseConnection>();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddSettings()
            .AddRepositories();
}