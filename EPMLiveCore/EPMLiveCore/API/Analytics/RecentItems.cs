using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.ApplicationPages.Calendar.Exchange;

namespace EPMLiveCore.API
{
    public class RecentItems
    {
        public string Operate()
        {
            var result = "success";

            if (SPContext.Current != null && SPContext.Current.Item != null)
            {
                
            }
            
            return result;
        }

        private string InsertQuery =
            @"IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[FRF]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
                    BEGIN
	                    IF (count < 20)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [ [Icon], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, @type, " + Convert.ToInt32(AnalyticsType.Frequent) + @")
                        END
                        ELSE
                        BEGIN
                            //remove oldest entry
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [Icon], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, @type, " + Convert.ToInt32(AnalyticsType.Frequent) + @")
                        END
                    END";
    }
}
