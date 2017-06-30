using Microsoft.SharePoint;

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
    }
}