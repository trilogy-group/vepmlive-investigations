using Microsoft.SharePoint;
using System;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder();
        void DeleteSiteCollectionMappedFolder();
        void SyncReports( SPDocumentLibrary reportLibrary, out string errors);
        void DeleteReport(string data);
        void AssignRoleMapping(List<SPGroup> groups, SPList userList);
        void RemoveRoleMapping(string data);
    }
}