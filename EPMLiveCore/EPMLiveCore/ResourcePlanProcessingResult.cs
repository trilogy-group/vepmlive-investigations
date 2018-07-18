using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore
{
    public class ResourcePlanProcessingResult
    {
        public readonly IList<string> InfoMessages = new List<string>();
        public readonly IList<string> ErrorMessages = new List<string>();

        public IList<ResourceLink> ResourceLinks = new List<ResourceLink>();
        public IList<ResourceInfo> ResourceInfos = new List<ResourceInfo>();

        public IEnumerable<object[]> ResourceLinkRows
        {
            get
            {
                foreach (var resourceLink in ResourceLinks)
                {
                    yield return new object[]
                    {
                        resourceLink.ServerRelativeUrl,
                        resourceLink.ResourceUrl,
                        resourceLink.SiteId,
                        resourceLink.Workdays,
                        resourceLink.Hours
                    };
                }
            }
        }

        public IEnumerable<object[]> ResourceInfoRows
        {
            get
            {
                foreach (var resourceInfo in ResourceInfos)
                {
                    yield return new object[]
                    {
                        resourceInfo.Project,
                        resourceInfo.Title,
                        resourceInfo.LookupValue,
                        resourceInfo.StartDateString,
                        resourceInfo.DueDateString,
                        resourceInfo.ResourcePlanList,
                        resourceInfo.StatusString,
                        resourceInfo.Work,
                        resourceInfo.SiteId
                    };
                }
            }
        }

        public struct ResourceInfo
        {
            public string Project;
            public string Title;
            public string LookupValue;
            public string ResourcePlanList;
            public string StartDateString;
            public string DueDateString;
            public string StatusString;
            public float Work;
            public Guid SiteId;

            public ResourceInfo(
                string project, 
                string title, 
                string lookupValue, 
                string startDateString, 
                string dueDateString,
                string resourcePlanList,
                string statusString, 
                float work, 
                Guid siteId)
            {
                Project = project;
                Title = title;
                LookupValue = lookupValue;
                StartDateString = startDateString;
                DueDateString = dueDateString;
                ResourcePlanList = resourcePlanList;
                StatusString = statusString;
                Work = work;
                SiteId = siteId;
            }
        }

        public struct ResourceLink
        {
            public string ServerRelativeUrl;
            public string ResourceUrl;
            public Guid SiteId;
            public string Workdays;
            public int Hours;

            public ResourceLink(string serverRelativeUrl, string resourceUrl, Guid siteId, string workdays, int hours)
            {
                ServerRelativeUrl = serverRelativeUrl;
                ResourceUrl = resourceUrl;
                SiteId = siteId;
                Workdays = workdays;
                Hours = hours;
            }
        }
    }
}
