using System;

namespace RabbitMq.Models
{
    public interface INLogLogger
    {
        void WriteTrace(Exception e, string message);
        void WriteDebug(Exception e, string message);
        void WriteInfo(Exception e, string message);
        void WriteInfo(string message);
        void WriteWarning(Exception e, string message);
        void WriteWarning(string message);
        void WriteError(Exception e, string message);
        void WriteError(string message);
        void WriteFatal(Exception e, string message);
        void WriteFatal(string message);
    }
}
