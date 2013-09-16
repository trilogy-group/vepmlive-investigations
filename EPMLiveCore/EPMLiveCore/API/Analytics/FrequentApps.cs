using System;
using System.Collections.Generic;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public static class FrequentApps
    {
        #region Methods (2)

        // Public Methods (1) 

        public static string Count(string xml)
        {
            var result = "success";
            var sOrigList = SessionManager.CurrList;
            var sCurList = string.Empty;
            try { sCurList = SPContext.Current.List.Title; } catch{}
            SessionManager.CurrList = sCurList;

            if (!IsDifferentList()) return result;
            
            var data = new AnalyticsData(xml);
            try
            {
                var exec = new QueryExecutor(SPContext.Current.Web);
                exec.ExecuteReportingDBNonQuery(InsertQuery, InsertParams(data));
            }
            catch (Exception e)
            {
                SessionManager.CurrList = sOrigList;
                result = "error: " + e.Message;
            }
            return result;
        }

        // Private Methods (1) 

        private static bool IsDifferentList()
        {   
            var sSessionList = SessionManager.CurrList;
            var sContextList = (SPContext.Current.List == null) ? string.Empty : SPContext.Current.List.Title;
            return sSessionList != sContextList;
        }

        private static Dictionary<string, object> InsertParams(AnalyticsData data)
        {
            return new Dictionary<string, object>
            {   
                {"@siteid", data.SiteId},
                {"@webid", data.WebId},
                {"@listid", data.ListId},
                {"@userid", data.UserId},
                {"@title", data.Title},
                {"@icon", data.Icon}
            };
        }

        #endregion Methods

        private static string InsertQuery =
            @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    UPDATE FRF SET [F_Int]=[F_Int]+1 WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                    END
                    ELSE
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [Icon], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Frequent) + @", 1)
                    END";
        
    }
}