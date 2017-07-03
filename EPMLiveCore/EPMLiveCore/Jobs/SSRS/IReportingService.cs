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
        void AssignRoleMapping(SPGroupCollection groups, SPList userList);
        void RemoveRoleMapping(string data);
        Subscription[] ListSubscriptions(string reportPath);
        Extension[] ListExtensions(string extensionType);
        ItemParameter[] GetItemParameters(string reportPath);
        void EnableSubscription(string subscriptionID);
        void DisableSubscription(string subscriptionID);
        void DeleteSubscription(string subscriptionID);
        CatalogItem[] ListChildren(string itemPath, bool recursive);
        string CreateSubscription(string itemPath, ExtensionSettings extensionSettings, string description,
            string eventType, string matchData, ParameterValue[] parameters);
        void ChangeSubscriptionOwner(string SubscriptionID, string NewOwner);
        string GetSubscriptionProperties(string subscriptionID, out ExtensionSettings extensionSettings,
            out string description, out ActiveState active, out string status, out string eventType,
            out string matchData, out ParameterValue[] parameters);
    }
}