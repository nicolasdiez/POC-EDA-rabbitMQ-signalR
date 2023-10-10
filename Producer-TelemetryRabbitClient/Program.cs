using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Noise Sensor started.");
Send();

void Send()
{
    //create a connection to the RabbitMQ server (in this case in 'localhost')
    var factory = new ConnectionFactory() { HostName = "localhost" };
    using (var connection = factory.CreateConnection())

    using (var channel = connection.CreateModel())
    {
        // create a new 'telemetry' queue
        channel.QueueDeclare(queue: "telemetry", durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

        while (true)
        {
            Console.Write("Please enter the decibels to send from the device to the queue:");
            string? decibels = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(decibels))
            {
                var body = Encoding.UTF8.GetBytes(decibels);

                // publish the encoded decibels data into the 'telemetry' queue
                channel.BasicPublish(exchange: "",
                                    routingKey: "telemetry",
                                    basicProperties: null,
                                    body: body);
                Console.WriteLine(" [x] Sent {0}", decibels);
            }
        }
    }
}
