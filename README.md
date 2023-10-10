## System Description
- Proof Of Concept of an Event-Driven Architecture with 2 channels.
- Producer simulates a telemetry system which outputs decibel measurements (in this POC user manually inputs the decibel measurement by console). Producer is publishing messages on the 'telemetry' queue of the Channel #1.
- Channel #1 is a RabbitMQ message broker with one queue ('telemetry' queue)
- Channel #2 is a SignalR hub which behaves as a consumer for the events of the RabbitMQ 'telemetry' queue ("telemtry" queue). And also behaves as a producer/publisher for the SignalR hub (TELEMETRY_CONTROLLER_URI).
- Consumer is a final client receiving messages published in the SignalR hub.

## How to setup and use the system?
1. Install "requirements.txt"
2. Open RabbitMQ console (RabbitMQ Command Prompt (sbin dir)) and start Channel 1 (RabbitMQ): $$ rabbitmq-server start
4. Run the Producer: Producer-TelemetryRabbitClient
5. Run Channel 2 (SignalR): Channel_2-SignalRTelemetry
6. Run the Consumer: Consumer-SignalRClient