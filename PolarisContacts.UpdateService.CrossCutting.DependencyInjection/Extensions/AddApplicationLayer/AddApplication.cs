using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Application.Services;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddApplicationLayer;

public static partial class AddApplicationLayerExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddTransient<IUsuarioService, UsuarioService>()
                .AddTransient<IContatoService, ContatoService>()                
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IEnderecoService, EnderecoService>()
                .AddTransient<ITelefoneService, TelefoneService>()
                .AddTransient<ICelularService, CelularService>();

    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddServices();
}
