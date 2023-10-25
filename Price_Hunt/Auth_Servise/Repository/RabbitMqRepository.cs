using Auth_Servise.IntefaceRepository;
using RabbitDataLibrary.Interface;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Auth_Servise.Repository
{
    public class RabbitMqRepository : IRabbitMQRepository
    {
        public void SendMessage<T>(T obj, string host, string exchange) where T : IRabbitModel
        {
            byte[] message = ConvertToByte(obj);

            var factory = new ConnectionFactory() { HostName = host };

            using (var con = factory.CreateConnection())
            {
                using (var chanel = con.CreateModel())
                {
                    chanel.BasicPublish(exchange: exchange, routingKey: "", basicProperties: null, body: message);
                }
            }

        }

        private byte[] ConvertToByte(object obj)
        {
            string json = JsonSerializer.Serialize(obj);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
