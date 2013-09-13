using System;
using System.Collections.Generic;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public class FrequentApps
    {
        #region Methods (2)

        // Public Methods (1) 

        public string Operate(string xml)
        {
            var result = "success";

            if (!IsDifferentList()) return result;
            var sOrigList = SessionManager.CurrList;
            var data = new AnalyticsData(xml);
            try
            {
                var exec = new QueryExecutor(SPContext.Current.Web);
                exec.ExecuteReportingDBNonQuery(InsertQuery, new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@userid", data.UserId},
                        {"@title", data.Title},
                        {"@icon", data.Icon},
                        {"@type", data.Type}
                    });
                SessionManager.CurrList = SPContext.Current.List.Title;
            }
            catch (Exception e)
            {
                SessionManager.CurrList = sOrigList;
                result = "error: " + e.Message;
            }
            return result;
        }
        // Private Methods (1) 

        private bool IsDifferentList()
        {
            var isDiff = false;
            isDiff = (SPContext.Current.List == null)
                ? (SessionManager.CurrList != string.Empty)
                : (SessionManager.CurrList != SPContext.Current.List.Title);

            return isDiff;
        }

        #endregion Methods

        private string InsertQuery =
            @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    UPDATE FRF SET [F_Int]=[F_Int]+1 WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                    END
                    ELSE
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [Icon], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, @type, " + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    END";
    }
}