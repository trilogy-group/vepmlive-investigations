using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(string siteCollectionId);
        void DeleteSiteCollectionMappedFolder(string siteCollectionId);
        void SyncReports(string webApplicationId, string siteCollectionId, SPDocumentLibrary reportLibrary);
    }
}