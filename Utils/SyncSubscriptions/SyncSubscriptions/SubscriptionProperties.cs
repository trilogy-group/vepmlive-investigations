using SyncSubscriptions.SSRS2010;

namespace SyncSubscriptions
{
    public class SubscriptionProperties : Subscription
    {
        public SubscriptionProperties() { }

        public SubscriptionProperties(Subscription subs) : base()
        {
            base.Active = subs.Active;
            base.DeliverySettings = subs.DeliverySettings;
            base.Description = subs.Description;
            base.EventType = subs.EventType;
            base.IsDataDriven = subs.IsDataDriven;
            base.LastExecuted = subs.LastExecuted;
            base.LastExecutedSpecified = subs.LastExecutedSpecified;
            base.ModifiedBy = subs.ModifiedBy;
            base.ModifiedDate = subs.ModifiedDate;
            base.Owner = subs.Owner;
            base.Path = subs.Path;
            base.Report = subs.Report;
            base.Status = subs.Status;
            base.SubscriptionID = subs.SubscriptionID;
            base.VirtualPath = subs.VirtualPath;
        }

        public ParameterValue[] ReportParams { get; set; }
        public string MatchData { get; set; }
        public string SitePath { get; set; }
    }
}
