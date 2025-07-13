# TelemetryWithGrafanaAndCollectorsSample
This project demonstrates how to monitor a .NET 8 application using OpenTelemetry, Prometheus, Grafana, and Tempo through Docker Compose.

## Features
- .NET 8 app instrumented with OpenTelemetry
- Metrics sent to Prometheus
- Traces sent to Tempo
- Visualized with Grafana dashboards
## Setup
### 1. Start monitoring stack
Run this from the project root:
```bash
docker compose up -d
```
### 2. Run the .NET app
- In Visual Studio with `http://localhost:4317` as the OTLP endpoint
- Or as a Docker container with `http://otel-collector:4317`
### 3. Access the tools
- Application: http://localhost:8080
- Grafana: http://localhost:3000 (user: `admin`, pass: `admin`)
- Prometheus: http://localhost:9090
- Tempo (API only): http://localhost:3200
### 4. In Grafana
- Add Prometheus data source (URL: `http://prometheus:9090`)
- Add Tempo data source (URL: `http://tempo:3200`)
- Import dashboard ID `19924` for .NET metrics

## Files
- `docker-compose.yml` — sets up all monitoring services
- `prometheus.yml` — configures Prometheus scrape targets
- `recording_rules.yml` — optional metric aggregations
- `otel-collector-config.yaml` — OpenTelemetry Collector config
- `tempo.yaml` — configures Tempo
- 
## Notes
- Use OTLP exporter in your `Program.cs` with correct endpoint
- Tempo stores traces; Prometheus stores metrics
- Grafana connects to both for visualization
- Exclude `tempo-data/` from Git if generated

## License
For demo or educational use. No license applied.
