using System;

namespace EPMLiveWebParts.Personalization.DomainModel
{
    public class PersonalizationSearchCriteria
    {
        public Guid? WebPartId { get; set; }
        public string UserId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? WebId { get; set; }
        public string Key { get; set; }
    }
}