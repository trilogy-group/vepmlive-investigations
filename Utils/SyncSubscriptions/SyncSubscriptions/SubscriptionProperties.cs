using SyncSubscriptions.SSRS2010;

namespace SyncSubscriptions
{
    public class SubscriptionProperties : Subscription
    {
        public SubscriptionProperties() { }

        public ParameterValue[] ReportParams { get; set; }
        public string MatchData { get; set; }
    }
}
