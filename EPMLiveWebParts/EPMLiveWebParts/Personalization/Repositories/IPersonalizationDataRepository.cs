using EPMLiveWebParts.Personalization.DomainModel;

namespace EPMLiveWebParts.Personalization.Repositories
{
    public interface IPersonalizationDataRepository
    {
        void PersistUserSettings(PersonalizationData userSettings);
        PersonalizationData GetUserSettings(PersonalizationSearchCriteria searchCriteria);
    }
}