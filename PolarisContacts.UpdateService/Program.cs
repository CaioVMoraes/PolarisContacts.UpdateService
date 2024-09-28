using PolarisContacts.UpdateService.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de ambiente
builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var env = context.HostingEnvironment;

    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
});

// Adiciona servi�os ao container
builder.Services.RegisterServices();

// Adiciona suporte para controladores e filtros de autentica��o
builder.Services.AddControllers(options =>
{
    // Adiciona o filtro globalmente, exceto em ambientes de teste
    //if (!builder.Environment.IsEnvironment("Test"))
    //{
    //    options.Filters.Add(new AuthenticationFilterAttribute());
    //}
});

// Swagger para documenta��o
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

app.Run();

public partial class Program { }
