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
            // will implement later
            try
            {
                var sParentItem = properties.Web.AllProperties["ParentItem"];
                var sColl = sParentItem.ToString().Split(new string[] {"^^"}, StringSplitOptions.RemoveEmptyEntries);
                var webid = sColl[0];
                var listid = sColl[1];
                var itemid = sColl[2];
                var isitem = (new Guid(listid) == Guid.Empty) ? "false" : "true";
                var xml = 
                    "<Data><Param key=\"SiteId\">" + properties.SiteId + "</Param>" + 
                    "<Param key=\"WebId\">" + properties.Web.ID + "</Param>" +
                    "<Param key=\"ItemId\">" + itemid + "</Param>" +
                    "<Param key=\"FString\">" + properties.Web.ServerRelativeUrl + "</Param>" +
                    "<Param key=\"Type\">4</Param>" +
                    "<Param key=\"UserId\">" + properties.Web.CurrentUser.ID + "</Param>" +
                    "<Param key=\"IsItem\">" + isitem + "</Param></Data>";

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


                CacheStore.Current.RemoveSafely(properties.Web.Url, CacheStoreCategory.Navigation);
            }
            catch
            {
            }
        }

       
    }
}
