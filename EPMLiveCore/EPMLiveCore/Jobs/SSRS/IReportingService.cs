using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(string siteCollectionId);
        void DeleteSiteCollectionMappedFolder(string siteCollectionId);
        void SyncReports(string siteCollectionId, SPDocumentLibrary reportLibrary, out string errors);
    }
}