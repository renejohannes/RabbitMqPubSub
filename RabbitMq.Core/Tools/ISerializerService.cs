namespace RabbitMq.Core.Tools
{
    public interface ISerializerService
    {
        string SerializeJson(object model);

        T DeserializeJson<T>(string message) where T : class;
    }
}
