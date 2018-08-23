using System;
using RabbitMq.Models;

namespace RabbitMq.Core.Base
{
    public class ServiceBase
    {
        protected Response Try(Action execution)
        {
            var result = new Response();

            try
            {
                execution();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Exception = ex;
                result.ExceptionType = ex.GetType();
                Console.WriteLine(result.Exception.Message);
            }
            return result;
        }

        protected Response<T> Try<T>(Func<T> execution)
        {
            var result = new Response<T>();

            try
            {
                result.Result = execution();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Exception = ex;
                result.ExceptionType = ex.GetType();
                Console.WriteLine(result.Exception.Message);
            }

            return result;
        }
    }
}
