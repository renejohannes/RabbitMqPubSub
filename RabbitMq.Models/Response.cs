using System;

namespace RabbitMq.Models
{
    public class Response 
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public Type ExceptionType { get; set; }
    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }
}
