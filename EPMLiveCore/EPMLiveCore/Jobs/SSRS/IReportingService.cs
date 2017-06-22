using System;

namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(Guid siteCollectionId);
        void DeleteSiteCollectionMappedFolder(Guid siteCollectionId);
    }
}