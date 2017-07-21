using System.Messaging;
using System.Transactions;

namespace PortfolioEngineCore
{
    public class Msmq : IMessageQueue
    {
        public void CreateQueue(string name)
        {
            if (!MessageQueue.Exists(name))
            {
                var queue = MessageQueue.Create(name, true);
                queue.SetPermissions("Everyone", MessageQueueAccessRights.WriteMessage);
            }
        }

        public void Queue(string basePath)
        {
            var client = new ND.NotificationDispatcherClient();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                client.QueueNotification(new ND.Notification() { BasePath = basePath });
                scope.Complete();
            }
            client.Close();
        }
    }
}