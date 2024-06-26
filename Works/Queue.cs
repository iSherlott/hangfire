using Highfire.Services;
using RabbitMQ.Client;
using System.Threading.Channels;

namespace Highfire.Works
{
    public class ConnectionSettings
    {
        public required string HostName { get; set; }
        public int Port { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string VirtualHost { get; set; }
        public required string ServerName { get; set; }
        public required bool Enabled { get; set; }
        public required string Queue { get; set; }
    }
    public class Queue
    {
        protected readonly IConnection _connection;
        protected readonly IModel _channel;
        public Queue(IConfiguration configuration)
        {
            var connectionSetings = configuration.GetSection("RabbitMQ").Get<ConnectionSettings>();

            var factory = new ConnectionFactory
            {
                HostName = connectionSetings.HostName,
                Port = connectionSetings.Port,
                UserName = connectionSetings.UserName,
                Password = connectionSetings.Password,
                VirtualHost = connectionSetings.VirtualHost,
                Ssl = new SslOption
                {
                    ServerName = connectionSetings.ServerName,
                    Enabled = connectionSetings.Enabled
                }
            };

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: connectionSetings.Queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }
    }
}
