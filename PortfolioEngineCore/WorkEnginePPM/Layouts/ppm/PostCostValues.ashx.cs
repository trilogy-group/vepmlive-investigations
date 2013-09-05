using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class PostCostValuesHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.PostCostValuesHandler";
            StreamReader sr = new StreamReader(context.Request.InputStream);
            string sRequest = sr.ReadToEnd();
            try
            {
                context.Server.ScriptTimeout = 86400;
                s = WebAdmin.CheckRequest(context, this_class, sRequest);
                if (s == "")
                {
                    CStruct xPageRequest = new CStruct();
                    if (xPageRequest.LoadXML(sRequest))
                    {
                        string sFunction = xPageRequest.GetStringAttr("function");
                        string sRequestContext = xPageRequest.GetStringAttr("context");
                        try
                        {
                            Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                            Type thisClass = assemblyInstance.GetType(this_class, true, true);
                            MethodInfo m = thisClass.GetMethod(sFunction);
                            CStruct xData = xPageRequest.GetSubStruct("data");
                            object result = m.Invoke(null, new object[] { context, sRequestContext, xData });
                            s = WebAdmin.BuildReply(this_class, sFunction, sRequestContext, result.ToString());
                        }
                        catch (Exception ex)
                        {
                            s = WebAdmin.BuildReply(this_class, sFunction, sRequestContext, WebAdmin.FormatError("exception", this_class + ".ProcessRequest", ex.Message, "1"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                s = WebAdmin.BuildReply(this_class, this_class + ".ProcessRequest", sRequest, WebAdmin.FormatError("exception", this_class + ".ProcessRequest", ex.Message, "1"));
            }
            context.Response.ContentType = "text/xml; charset=utf-8";
            context.Response.Write(CStruct.ConvertXMLToJSON(s));
        }

        public static string PostCostValuesRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadCalendarsForCostType":
                        {
                            int nFieldId = Int32.Parse(xData.InnerText);
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                sReply = ReadCalendarsForCostType(dba, nFieldId);
                            }
                            dba.Close();
                            break;
                        }
                    case "PostCostValues":
                        {
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                sReply = PostCostValues(dba, xData);
                            }
                            dba.Close();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "CostTypeCustomFields.CustomfieldRequest", ex.Message);
            }

            return sReply;
        }

        private static string ReadCalendarsForCostType(DBAccess dba, int nCTId)
        {
            string sReply = "";
            DataTable dt;
            dbaEditCosts.SelectCostType(dba, nCTId, out dt);
            int editmode = 0;
            int ctCalendarId = -1;
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                editmode = DBAccess.ReadIntValue(row["CT_EDIT_MODE"]);
                ctCalendarId = DBAccess.ReadIntValue(row["CT_CB_ID"]);
            }

            CStruct xCalendars = new CStruct();
            xCalendars.Initialize("calendars");
            dbaCalendars.SelectCalendars(dba, out dt);
            foreach (DataRow row in dt.Rows)
            {
                int calendarId = DBAccess.ReadIntValue(row["CB_ID"]);
                if (editmode != 1 || calendarId != ctCalendarId)
                {
                    CStruct xItem = xCalendars.CreateSubStruct("item");
                    xItem.CreateIntAttr("id", calendarId);
                    xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CB_NAME"], ""));
                }
            }

            dba.Close();

            sReply = xCalendars.XML();
            return sReply;
        }

        private static string PostCostValues(DBAccess dba, CStruct xData)
        {
            string sReply = "";
            int nCTId = xData.GetIntAttr("CT_ID");
            int nCBId = xData.GetIntAttr("CB_ID");

            // add job to ueue for immediate execution
            CStruct xRequest = new CStruct();
            xRequest.Initialize("Request");
            CStruct xSet = xRequest.CreateSubStruct("EPKSet");
            xSet.CreateString("EPKAuth", "");
            CStruct xProcess = xSet.CreateSubStruct("EPKProcess");
            xProcess.CreateInt("RequestNo", 2);
            CStruct xCBCTs = xProcess.CreateSubStruct("CBCTs");
            CStruct xCBCT = xCBCTs.CreateSubStruct("CBCT");
            xCBCT.CreateIntAttr("CTID", nCTId);
            xCBCT.CreateIntAttr("CBID", nCBId);
            int lRowsAffected;
            dbaQueueManager.PostCostValues(dba, "Post Cost Values for CTID=" + nCTId.ToString("0") + " and CBID=" + nCBId.ToString("0"), xRequest.XML(), out lRowsAffected);

            return sReply;
        }

        #endregion
    }
}
