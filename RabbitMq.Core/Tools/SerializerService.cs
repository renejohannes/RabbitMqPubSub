using Newtonsoft.Json;

namespace RabbitMq.Core.Tools
{
    public class SerializerService : ISerializerService
    {
        public string SerializeJson(object model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public T DeserializeJson<T>(string message) where T : class
        {
            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
