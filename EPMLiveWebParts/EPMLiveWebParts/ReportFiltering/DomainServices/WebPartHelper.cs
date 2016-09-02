using System;

namespace EPMLiveWebParts.ReportFiltering.DomainServices
{
    public class WebPartHelper
    {
        public static Guid? ConvertWebPartIdToGuid(string webPartId)
        {
            return new Guid(webPartId.Replace("g_", string.Empty).Replace("_", "-"));
        } 
    }
}