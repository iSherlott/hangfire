using Highfire.Works;
using RabbitMQ.Client;
using System.Text;

namespace Highfire.Services
{
    public class Publisher : Queue
    {
        public Publisher(IConfiguration configuration) : base(configuration) { }

        public void Send(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: "email_queue",
                                 basicProperties: null,
                                 body: body);
        }
        public void Close()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
