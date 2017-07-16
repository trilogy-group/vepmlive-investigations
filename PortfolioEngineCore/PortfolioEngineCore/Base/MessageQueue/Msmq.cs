using System;
using System.Messaging;

namespace PortfolioEngineCore
{
    public class Msmq : IMessageQueue
    {
        private readonly string address;

        public Msmq(string queueAddress)
        {
            address = queueAddress;
        }

        public void Queue(string basePath)
        {
            var pfeQueue = new MessageQueue(address);
            pfeQueue.Send(basePath);
        }
    }
}