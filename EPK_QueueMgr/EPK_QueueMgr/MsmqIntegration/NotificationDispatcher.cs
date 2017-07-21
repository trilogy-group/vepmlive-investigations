using PortfolioEngineCore;

namespace WE_QueueMgr.MsmqIntegration
{
    public class NotificationDispatcher : INotificationDispatcher
    {
        public void QueueNotification(Notification notification)
        {
            Global.Instance.ManageQueueJobs(notification.BasePath);
        }
    }
}