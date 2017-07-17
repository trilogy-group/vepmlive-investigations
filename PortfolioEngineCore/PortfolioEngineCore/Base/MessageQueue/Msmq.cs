using System;
using System.Messaging;

namespace PortfolioEngineCore
{
    public class Msmq : IMessageQueue
    {
        private readonly string address;
        private readonly MessageQueue queue;

        public Msmq(string queueAddress)
        {
            address = queueAddress;
            queue = new MessageQueue(queueAddress);
        }

        public void Queue(string basePath)
        {
            queue.Send(basePath);
        }

        public string Receive()
        {
            try
            {
                var message = queue.Receive(new TimeSpan(0, 0, 1));
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });
                return message.Body.ToString();
            }
            catch (Exception exception)
            {
                if (exception.Message == "Timeout for the requested operation has expired.")
                {
                    return string.Empty;
                }
                throw;                
            }
        }
    }
}