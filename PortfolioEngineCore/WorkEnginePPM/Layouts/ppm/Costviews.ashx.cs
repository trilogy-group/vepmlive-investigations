using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class Costviews : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.Costviews";
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

        public static string CostviewsRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadCostviewInfo":
                    {
                        int nViewId = Int32.Parse(xData.InnerText);
                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        DataAccess da = new DataAccess(sBaseInfo);
                        DBAccess dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            DataTable dt;
                            if (dbaCostViews.SelectCostView(dba, nViewId, out dt) != StatusEnum.rsSuccess)
                            {
                                sReply = WebAdmin.FormatError("exception", "Costviews.ReadCostviewInfo", dba.StatusText);
                            }
                            else
                            {
                                CStruct xCostviews = new CStruct();
                                xCostviews.Initialize("Costview");

                                int nSelectedCalendar = -1;
                                if (dt.Rows.Count == 1)
                                {
                                    DataRow row = dt.Rows[0];
                                    xCostviews.CreateIntAttr("VIEW_UID", DBAccess.ReadIntValue(row["VIEW_UID"]));
                                    xCostviews.CreateStringAttr("VIEW_NAME", DBAccess.ReadStringValue(row["VIEW_NAME"]));
                                    xCostviews.CreateStringAttr("VIEW_DESC", DBAccess.ReadStringValue(row["VIEW_DESC"]));
                                    nSelectedCalendar = DBAccess.ReadIntValue(row["VIEW_COST_BREAKDOWN"]);
                                    xCostviews.CreateIntAttr("VIEW_COST_BREAKDOWN", nSelectedCalendar);
                                    xCostviews.CreateIntAttr("VIEW_FIRST_PERIOD", DBAccess.ReadIntValue(row["VIEW_FIRST_PERIOD"]));
                                    xCostviews.CreateIntAttr("VIEW_LAST_PERIOD", DBAccess.ReadIntValue(row["VIEW_LAST_PERIOD"]));
                                }
                                else
                                {
                                    xCostviews.CreateIntAttr("VIEW_UID", 0);
                                    xCostviews.CreateStringAttr("VIEW_NAME", "New Cost View");
                                    xCostviews.CreateStringAttr("VIEW_DESC", "");
                                    xCostviews.CreateIntAttr("VIEW_COST_BREAKDOWN", nSelectedCalendar);
                                    xCostviews.CreateIntAttr("VIEW_FIRST_PERIOD", 0);
                                    xCostviews.CreateIntAttr("VIEW_LAST_PERIOD", 0);
                                }

                                CStruct xCalendars = xCostviews.CreateSubStruct("calendars");
                                CStruct xItem = xCalendars.CreateSubStruct("item");
                                xItem.CreateIntAttr("id", -1);
                                xItem.CreateStringAttr("name", "[None]");
                                {
                                    dbaCalendars.SelectCalendars(dba, out dt);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        xItem = xCalendars.CreateSubStruct("item");
                                        int nCalendar = DBAccess.ReadIntValue(row["CB_ID"]);
                                        xItem.CreateIntAttr("id", nCalendar);
                                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CB_NAME"]));
                                    }
                                }

                                CStruct xCosttypes = xCostviews.CreateSubStruct("costtypes");
                                {
                                    dbaCostViews.SelectCostTypesForView(dba, nViewId, out dt);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        xItem = xCosttypes.CreateSubStruct("item");
                                        int nCosttype = DBAccess.ReadIntValue(row["CT_ID"]);
                                        xItem.CreateIntAttr("id", nCosttype);
                                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CT_NAME"]));
                                        xItem.CreateIntAttr("used", DBAccess.ReadIntValue(row["used"]));
                                    }
                                }

                                CStruct xPeriods = xCostviews.CreateSubStruct("periods");
                                xItem = xPeriods.CreateSubStruct("item");
                                xItem.CreateIntAttr("id", -1);
                                xItem.CreateStringAttr("name", "[None]");
                                if (nSelectedCalendar >= 0)
                                {
                                    {
                                        dbaCalendars.SelectCalendarPeriods(dba, nSelectedCalendar, out dt);
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            xItem = xPeriods.CreateSubStruct("item");
                                            xItem.CreateIntAttr("id", DBAccess.ReadIntValue(row["PRD_ID"]));
                                            xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["PRD_NAME"]));
                                        }
                                    }
                                }
                            //    {
                                dba.Close();
                                sReply = xCostviews.XML();
                                }
                            }
                        }
                        break;
                    case "ReadCalendarInfo":
                        sReply = ReadCalendarInfo(Context, xData);
                        break;
                    case "UpdateCostviewInfo":
                    {
                        sReply = UpdateCostviewInfo(Context, xData);
                        break;
                    }
                    case "DeleteCostviewInfo":
                    {
                        sReply = DeleteCostviewInfo(Context, xData);
                        break;
                    }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "Costviews.CostviewsRequest", ex.Message);
            }

            return sReply;
        }
        private static string ReadCalendarInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    int nCalendarId = -1;
                    int i;
                    if (Int32.TryParse(xData.InnerText, out i) == true)
                        nCalendarId = i;
                    CStruct xCostview = new CStruct();
                    xCostview.Initialize("Costview");
                    xCostview.CreateIntAttr("CB_ID", nCalendarId);
                    DataTable dt;

                    CStruct xPeriods = xCostview.CreateSubStruct("periods");
                    CStruct xItem = xPeriods.CreateSubStruct("item");
                    xItem.CreateIntAttr("id", -1);
                    xItem.CreateStringAttr("name", "[None]");
                    if (nCalendarId >= 0)
                    {
                        {
                            dbaCalendars.SelectCalendarPeriods(dba, nCalendarId, out dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                xItem = xPeriods.CreateSubStruct("item");
                                xItem.CreateIntAttr("id", DBAccess.ReadIntValue(row["PRD_ID"]));
                                xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["PRD_NAME"]));
                            }
                        }
                    }
                    sReply = xCostview.XML();
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.ReadCalendarFTEsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string UpdateCostviewInfo(HttpContext Context, CStruct xData)
        {
            int nVIEW_UID = xData.GetIntAttr("VIEW_UID");
            string sVIEW_NAME = xData.GetStringAttr("VIEW_NAME");
            string sVIEW_DESC = xData.GetStringAttr("VIEW_DESC");
            int nVIEW_COST_BREAKDOWN = xData.GetIntAttr("VIEW_COST_BREAKDOWN");
            int nVIEW_FIRST_PERIOD = xData.GetIntAttr("VIEW_FIRST_PERIOD");
            int nVIEW_LAST_PERIOD = xData.GetIntAttr("VIEW_LAST_PERIOD");
            string sVIEW_CTS = xData.GetStringAttr("VIEW_CTS");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    if (dbaCostViews.UpdateCostViewInfo(dba, ref nVIEW_UID, sVIEW_NAME, sVIEW_DESC, nVIEW_COST_BREAKDOWN, nVIEW_FIRST_PERIOD, nVIEW_LAST_PERIOD, sVIEW_CTS, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "Costviews.UpdateCostviewsInfo2", dba.StatusText);
                    }
                    else
                    {
                        //  needed to update list after SAVE
                        CStruct xCostviews = new CStruct();
                        xCostviews.Initialize("Costview");
                        xCostviews.CreateIntAttr("VIEW_UID", nVIEW_UID);
                        xCostviews.CreateStringAttr("VIEW_NAME", sVIEW_NAME);
                        xCostviews.CreateStringAttr("VIEW_DESC", sVIEW_DESC);
                        sReply = xCostviews.XML();
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Costviews.UpdateCostviewsInfo3", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string DeleteCostviewInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nVIEW_UID = xData.GetIntAttr("VIEW_UID");
                try
                {
                    dbaCostViews.DeleteCostView(dba, nVIEW_UID, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Costviews.DeleteCostviewInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        #endregion
    }
}
