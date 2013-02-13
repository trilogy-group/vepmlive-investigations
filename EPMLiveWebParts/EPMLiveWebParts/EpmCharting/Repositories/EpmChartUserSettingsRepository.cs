using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.EpmCharting.Mappers;
using EPMLiveWebParts.Personalization.DomainModel;
using EPMLiveWebParts.Personalization.Repositories;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.EpmCharting.Repositories
{
    public class EpmChartUserSettingsRepository
    {
        private readonly SPWeb _web;

        public EpmChartUserSettingsRepository(SPWeb web)
        {
            _web = web;
        }

        public EpmChartUserSettings GetChartSettings(PersonalizationSearchCriteria searchCriteria)
        {
            var personalizationsRepo = new PersonalizationDataRepository(_web, EpmChartUserSettings.Key);
            var personalizationsData = personalizationsRepo.GetUserSettings(searchCriteria);

            var chartSettingsToReturn = new EpmChartUserSettings();
            chartSettingsToReturn.Hydrate(personalizationsData);
            return chartSettingsToReturn;
        }

        public void PersistChartSettings(EpmChartUserSettings chartSettings)
        {
            var personalizationData = EpmChartUserSettingsToPersonalizationDataMapper.GetPersonalizationData(chartSettings);
            var personalizationsRepo = new PersonalizationDataRepository(_web, EpmChartUserSettings.Key);
            personalizationsRepo.PersistUserSettings(personalizationData);
        }
    }
}
