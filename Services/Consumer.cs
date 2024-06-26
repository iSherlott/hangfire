using System.Text;
using Hangfire;
using Highfire.Works;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Highfire.Services
{
    public class Consumer : Queue
    {
        private readonly MessageService _messageService;

        public Consumer(IConfiguration configuration, MessageService messageService) : base(configuration)
        {
            _messageService = messageService;
        } 

        public void Start()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                BackgroundJob.Enqueue(() => _messageService.ProcessQueueMessage(message));
            };
            _channel.BasicConsume(queue: "email_queue",
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void Close()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
