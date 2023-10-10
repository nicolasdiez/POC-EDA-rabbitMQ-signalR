## How to setup and use the system?

1. Install "requirements.txt"
2. Open RabbitMQ console (RabbitMQ Command Prompt (sbin dir)) and start Channel 1 (RabbitMQ): $$ rabbitmq-server start
4. Run the Producer: Producer-TelemetryRabbitClient
5. Run Channel 2 (SignalR): Channel_2-SignalRTelemetry
6. Run the Consumer: Consumer-SignalRClient