using Auth_Servise.Interface;
using Auth_Servise.Repository;
using RabbitDataLibrary.Interface;

namespace Auth_Servise.IntefaceRepository
{
    public interface IRabbitMQRepository
    {
        public Task<Boolean> SendMessage<T>(T obj, string host, string exchange) where T : IRabbitModel;
    }
}
