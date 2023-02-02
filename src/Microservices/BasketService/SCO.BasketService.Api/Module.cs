using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace SCO.BasketService
{
    public class Module
    {
        private readonly ILogger<Module> _logger;

        public Module( ILogger<Module> logger)
        {
            _logger = logger;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("basket", exclusive: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogError($"Message received: {message}");
            };

            channel.BasicConsume(queue: "basket", autoAck: true, consumer: consumer);
          
        }
    }
}
