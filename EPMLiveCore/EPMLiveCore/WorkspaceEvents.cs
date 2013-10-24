using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore
{
    public class WorkspaceEvents : SPWebEventReceiver
    {
        public override void WebDeleting(SPWebEventProperties properties)
        {   
            try
            {
                var sParentItem = properties.Web.AllProperties["ParentItem"];
                var sColl = sParentItem.ToString().Split(new string[] {"^^"}, StringSplitOptions.RemoveEmptyEntries);
                var webid = sColl[0];
                var listid = sColl[1];
                var itemid = sColl[2];
                var sIsItem = (new Guid(listid) != Guid.Empty) ? "true" : "false";
                var bIsItem = (new Guid(listid) != Guid.Empty);

                var xml = 
                    "<Data><Param key=\"SiteId\">" + properties.SiteId + "</Param>" + 
                    "<Param key=\"WebId\">" + properties.Web.ID + "</Param>" +
                    "<Param key=\"ItemId\">" + itemid + "</Param>" +
                    "<Param key=\"FString\">" + properties.Web.ServerRelativeUrl + "</Param>" +
                    "<Param key=\"Type\">4</Param>" +
                    "<Param key=\"UserId\">" + properties.Web.CurrentUser.ID + "</Param>" +
                    "<Param key=\"IsItem\">" + sIsItem + "</Param></Data>";

                var data = new AnalyticsData(xml, AnalyticsType.FavoriteWorkspace, AnalyticsAction.Delete);
                var qExec = new QueryExecutor(properties.Web);
                qExec.ExecuteEpmLiveQuery(
                    FRFQueryFactory.GetQuery(data),
                    FRFQueryParamFactory.GetParam(data));

                qExec.ExecuteReportingDBNonQuery(
                    "DELETE FROM RPTWeb WHERE [WebId]=@webid", 
                    new Dictionary<string, object>()
                    {
                        {"@webid", properties.WebId}
                    });

                qExec.ExecuteReportingDBNonQuery(
                    "DELETE FROM [RPTWEBGROUPS] WHERE [WEBID] NOT IN (SELECT [WebId] FROM [RPTWeb])",
                    new Dictionary<string, object>());

                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        using (var s = new SPSite(properties.SiteId))
                        {
                            using (var w = s.OpenWeb(properties.WebId))
                            {
                                if (w.Lists.Cast<SPList>().Any())
                                {
                                    var slistIds = w.Lists.Cast<SPList>().Aggregate("(", (current, l) => current + ("'" + l.ID.ToString() + "',"));
                                    slistIds = (slistIds.TrimEnd(',') + ")");

                                    qExec.ExecuteReportingDBNonQuery(
                                        "DELETE FROM [RPTITEMGROUPS] WHERE [LISTID] NOT IN " + slistIds,
                                        new Dictionary<string, object>());
                                }
                            }
                        }
                    });
                }
                catch { }

                if (bIsItem)
                {
                    // remove the parent item's workspaceurl field value
                    // so the workspace icon doesn't show up in grid
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate
                        {
                            using (var s = new SPSite(properties.SiteId))
                            {
                                using (var w = s.OpenWeb(new Guid(webid)))
                                {
                                    w.AllowUnsafeUpdates = true;

                                    var l = w.Lists[new Guid(listid)];
                                    var i = l.GetItemById(int.Parse(itemid));

                                    i["WorkspaceUrl"] = string.Empty;
                                    i.SystemUpdate();
                                }
                            }
                        });
                    }
                    catch { }
                }

                CacheStore.Current.RemoveSafely(properties.Web.Url, CacheStoreCategory.Navigation);
            }
            catch
            {
            }
        }

       
    }
}
