using EPMLiveWebParts.ReportFiltering.DomainModel;

namespace ReportFiltering.Repositories
{
    public interface IReportFilterUserSettingsRepository
    {
        void PersistUserSettings(ReportFilterUserSettings userSettings);
        ReportFilterUserSettings GetUserSettings(ReportFilterSearchCriteria searchCriteria);
    }
}