using System;
using System.Diagnostics;
using System.Web;
using Microsoft.SharePoint;

namespace EPMLiveWebParts
{
    public class SaveHelper
    {
        public static void HandleMultiUserCase(SPWeb web, string value, SPListItem listItem, SPField field)
        {
            var users = value.Split('\n');
            var userValueCollection = new SPFieldUserValueCollection();
            for (var i = 0; i < users.Length; i = i + 2)
            {
                var iGroup = 0;
                var userName = users[i];
                if (int.TryParse(userName, out iGroup))
                {
                    var userValue = new SPFieldUserValue(web, $"{userName};#{users[i + 1]}");
                    userValueCollection.Add(userValue);
                }
                else
                {
                    var user = web.AllUsers[userName];
                    var userValue = new SPFieldUserValue(web, $"{user.ID};#{user.Name}");
                    userValueCollection.Add(userValue);
                }
            }
            listItem[field.Id] = userValueCollection;
        }

        public static void PopulateGuidData(
            string webId,
            string listId,
            string siteId,
            Action<SPList> updateProjectList,
            ref Guid siteGuid,
            ref SPWeb iWeb,
            ref SPSite iSite,
            ref Guid webGuid,
            ref Guid listGuid,
            ref SPList iList)
        {
            var wGuid = new Guid(webId);
            var lGuid = new Guid(listId);
            var sGuid = new Guid(siteId);
            if (siteGuid != sGuid)
            {
                if (iWeb != null)
                {
                    iWeb.Close();
                    iWeb = null;
                    iSite.Close();
                }
                iSite = new SPSite(sGuid);
                siteGuid = iSite.ID;
            }
            if (webGuid != wGuid)
            {
                if (iWeb != null)
                {
                    iWeb.Close();
                    iWeb = iSite.OpenWeb(wGuid);
                }
                else
                {
                    iWeb = iSite.OpenWeb(wGuid);
                }
                webGuid = iWeb.ID;
            }
            if (listGuid != lGuid)
            {
                iList = iWeb.Lists[lGuid];
                updateProjectList?.Invoke(iList);
                listGuid = iList.ID;
            }
        }

        public static void ParseSiteFromRequest(
            HttpRequest httpRequest,
            string id,
            out string webId,
            out string listId,
            out string siteId)
        {
            webId = string.Empty;
            listId = string.Empty;
            siteId = string.Empty;
            try
            {
                webId = httpRequest[id + "_webid"];
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                listId = httpRequest[id + "_listid"];
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                siteId = httpRequest[id + "_siteid"];
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }
    }
}