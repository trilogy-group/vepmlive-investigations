using Microsoft.SharePoint;
using EPMLiveCore.SSRS2010;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder();
        void DeleteSiteCollectionMappedFolder();
        void SyncReports(SPDocumentLibrary reportLibrary);
        void DeleteReport(string data);
        void AddRoleMapping(SPGroupCollection groups, SPList userList);
        void RemoveRoleMapping(string data);
        Subscription[] ListSubscriptions(string itemPathOrSiteURL);
        Extension[] ListExtensions(string extensionType);
        ItemParameter[] GetItemParameters(string reportPath);
        void EnableSubscription(string subscriptionID);
        void DisableSubscription(string subscriptionID);
        void DeleteSubscription(string subscriptionID);
        CatalogItem[] ListChildren(string itemPath, bool recursive);
        string CreateSubscription(string itemPath, ExtensionSettings extensionSettings, string description,
            string eventType, string matchData, ParameterValue[] parameters);
        void ChangeSubscriptionOwner(string SubscriptionID, string NewOwner);
        SubscriptionProperties GetSubscriptionProperties(string subscriptionID);
        void SetSubscriptionProperties(string subscriptionID, ExtensionSettings extensionSettings,
            string description, string eventType, string matchData, ParameterValue[] parameters);
    }
}