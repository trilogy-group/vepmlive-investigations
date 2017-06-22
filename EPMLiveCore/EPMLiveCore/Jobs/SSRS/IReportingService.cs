namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(string siteCollectionId);
        void DeleteSiteCollectionMappedFolder(string siteCollectionId);
    }
}