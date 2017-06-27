using Microsoft.SharePoint;
using System;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(Guid siteCollectionId);
        void DeleteSiteCollectionMappedFolder(Guid siteCollectionId);
        void SyncReports(Guid siteCollectionId, SPDocumentLibrary reportLibrary, out string errors);
        void DeleteReport(Guid siteCollectionId, string data);
        void AssignRoleMapping(Guid siteCollectionId, List<SPGroup> groups, SPList userList);
    }
}