using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace KCDemo.WebAPI;

internal static class OpenTelemetryExtensions
{
    internal static IServiceCollection AddOpenTelemetryExtensions(
        this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("KCDemo.WebAPI"))
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter();
            });
        return services;
    }
}
