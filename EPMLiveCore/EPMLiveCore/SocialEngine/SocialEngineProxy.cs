using System.Collections.Generic;
using System.Xml.Linq;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.WorkEngineService;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine
{
    public static class SocialEngineProxy
    {
        #region Methods (1) 

        // Public Methods (1) 

        public static string ProcessActivity(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb contextWeb)
        {
            string webUrl = contextWeb.Url;

            var request = new XElement("ProcessActivity",
                new XAttribute("ObjectKind", objectKind),
                new XAttribute("ActivityKind", activityKind));

            foreach (var property in data)
            {
                request.Add(new XElement(property.Key,
                    new XAttribute("DataType", property.Value == null ? "NULL" : property.Value.GetType().Name),
                    new XCData((property.Value ?? string.Empty).ToString())));
            }

            using (var api = new WorkEngine())
            {
                api.Url = webUrl + (webUrl.EndsWith("/") ? string.Empty : "/") + "_vti_bin/WorkEngine.asmx";
                api.UseDefaultCredentials = true;
                return api.Execute("SocialEngine_ProcessActivity", request.ToString());
            }
        }

        #endregion Methods 
    }
}