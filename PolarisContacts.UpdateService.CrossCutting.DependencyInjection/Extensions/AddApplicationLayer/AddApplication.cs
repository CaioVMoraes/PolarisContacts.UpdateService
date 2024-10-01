using Microsoft.Extensions.DependencyInjection;
using PolarisContacts.UpdateService.Application.Interfaces.Services;
using PolarisContacts.UpdateService.Application.Services;

namespace PolarisContacts.UpdateService.CrossCutting.DependencyInjection.Extensions.AddApplicationLayer;

public static partial class AddApplicationLayerExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IContatoService, ContatoService>()                
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IEnderecoService, EnderecoService>()
                .AddScoped<ITelefoneService, TelefoneService>()
                .AddScoped<ICelularService, CelularService>();

    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddServices();
}
