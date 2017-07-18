using PortfolioEngineCore;
using System.ServiceModel;

namespace WE_QueueMgr.MsmqIntegration
{
    [ServiceContract]
    public interface INotificationDispatcher
    {
        [OperationContract(IsOneWay = true)]
        void QueueNotification(Notification notification);
    }
}