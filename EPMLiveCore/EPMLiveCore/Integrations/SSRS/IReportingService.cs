namespace EPMLiveCore.Integrations.SSRS
{
    public interface IReportingService
    {
        void CreateFolders(string webApplicationId, string siteCollectionId);
        void DeleteSiteCollection(string webApplicationId, string siteCollectionId);
    }
}