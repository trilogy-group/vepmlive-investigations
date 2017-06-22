using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(string webApplicationId, string siteCollectionId);
        void DeleteSiteCollectionMappedFolder(string webApplicationId, string siteCollectionId);
        void SyncReports(string webApplicationId, string siteCollectionId, SPDocumentLibrary reportLibrary);
    }
}