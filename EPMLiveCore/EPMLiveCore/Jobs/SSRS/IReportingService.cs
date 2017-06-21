namespace EPMLiveCore.Jobs.SSRS
{
    public interface IReportingService
    {
        void CreateSiteCollectionMappedFolder(string webApplicationId, string siteCollectionId);
        void DeleteSiteCollectionMappedFolder(string webApplicationId, string siteCollectionId);
    }
}