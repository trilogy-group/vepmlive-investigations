using PortfolioEngineCore;
using System.ServiceModel;

namespace WE_QueueMgr.MsmqIntegration
{
    public class NotificationDispatcher : INotificationDispatcher
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void QueueNotification(Notification notification)
        {
            Global.Instance.ManageQueueJobs(notification.BasePath);
        }
    }
}