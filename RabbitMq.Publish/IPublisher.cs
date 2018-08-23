namespace RabbitMq.Publish
{
  public  interface IPublisher
  {
      void Publish<T>(T model);
  }
}
