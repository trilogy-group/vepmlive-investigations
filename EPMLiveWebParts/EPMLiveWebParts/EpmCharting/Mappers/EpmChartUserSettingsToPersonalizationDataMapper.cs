using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.Personalization.DomainModel;

namespace EPMLiveWebParts.EpmCharting.Mappers
{
    public class EpmChartUserSettingsToPersonalizationDataMapper
    {
        public static PersonalizationData GetPersonalizationData(EpmChartUserSettings epmChartUserSettings)
        {
            var personalizationData = new PersonalizationData
                                          {
                                              ForeignKey = epmChartUserSettings.WebPartId,
                                              Key = EpmChartUserSettings.Key,
                                              ListId = epmChartUserSettings.ListId,
                                              SiteId = epmChartUserSettings.SiteId,
                                              WebId = epmChartUserSettings.WebId,
                                              UserId = epmChartUserSettings.UserId,
                                              Value = epmChartUserSettings.Value
                                          };

            return personalizationData;
        }
    }
}