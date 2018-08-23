namespace RabbitMq.Publish.Services
{
    public interface IPublishService
    {
        bool Publish<T>(T model);
    }
}
