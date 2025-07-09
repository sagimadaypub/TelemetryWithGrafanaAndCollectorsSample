using Microsoft.Extensions.Hosting;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TelemetryWithGrafanaAndCollectorsSample
{
    public class AppMonitor
    {
        public static void StartMonitor(WebApplicationBuilder builder)
        {
            SetupOpenTelemetry(builder);
        }

        public static void SetupOpenTelemetry(WebApplicationBuilder builder)
        {
            var collectorEndpoint = Environment.GetEnvironmentVariable("OTEL_COLLECTOR_ENDPOINT") ?? "http://localhost:4317";
            builder.Services.AddOpenTelemetry()
                .WithTracing(tracing => tracing
                    .SetResourceBuilder(resourceBuilder: ResourceBuilder.CreateDefault().AddService("DotNet8App"))
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(collectorEndpoint); // or "http://otel-collector:4317" in Docker
                    }))
                .WithMetrics(metrics => metrics
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("DotNet8App"))
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation()
                    //.AddPrometheusExporter()
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(collectorEndpoint); // or "http://otel-collector:4317" in Docker
                    }));
        }
    }
}
