using System.Transactions;

namespace PortfolioEngineCore
{
    public class Msmq : IMessageQueue
    {
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