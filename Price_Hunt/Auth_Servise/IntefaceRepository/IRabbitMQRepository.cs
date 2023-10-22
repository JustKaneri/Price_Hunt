namespace Auth_Servise.IntefaceRepository
{
    public interface IRabbitMQRepository
    {
        public Task<Boolean> Notification(object obj);

        public Task<List<Boolean>> Notifications(object obj);
    }
}
