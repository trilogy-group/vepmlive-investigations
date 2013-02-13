using System;

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    public class ReportFilterSearchCriteria
    {
        public Guid? WebPartId { get; set; }
        public string UserId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? WebId { get; set; } 
    }
}