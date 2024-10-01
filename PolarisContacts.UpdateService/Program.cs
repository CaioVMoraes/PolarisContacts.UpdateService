using PolarisContacts.UpdateService.CrossCutting.DependencyInjection;
using Prometheus;
using System.Diagnostics;

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

// Adiciona o middleware do Prometheus para m�tricas
app.UseHttpMetrics();

// M�tricas personalizadas
var requestCounter = Metrics.CreateCounter("myapp_http_requests_total", "Total number of HTTP requests received");
var responseLatency = Metrics.CreateHistogram("myapp_http_response_latency_seconds", "HTTP response latency in seconds");

// M�tricas de uso de CPU e mem�ria
var cpuUsageGauge = Metrics.CreateGauge("myapp_cpu_usage_total", "Total CPU usage of the application");
var memoryUsageGauge = Metrics.CreateGauge("myapp_memory_usage_bytes", "Total memory usage of the application in bytes");

// Atualizar m�tricas de CPU e mem�ria a cada requisi��o
var process = Process.GetCurrentProcess();

app.Use(async (context, next) =>
{
    // Incrementar o contador de requisi��es
    requestCounter.Inc();

    // Iniciar a medi��o de lat�ncia
    var stopwatch = Stopwatch.StartNew();

    // Executar a pr�xima parte do pipeline
    await next.Invoke();

    // Parar a medi��o de lat�ncia
    stopwatch.Stop();
    responseLatency.Observe(stopwatch.Elapsed.TotalSeconds);

    // Atualizar m�tricas de uso de CPU e mem�ria
    cpuUsageGauge.Set(process.TotalProcessorTime.TotalMilliseconds / Environment.ProcessorCount);
    memoryUsageGauge.Set(process.WorkingSet64);
});

app.MapMetrics(); // Rota para as m�tricas do Prometheus

// Mapeia os controladores
app.MapControllers();

app.Run();

public partial class Program { }
