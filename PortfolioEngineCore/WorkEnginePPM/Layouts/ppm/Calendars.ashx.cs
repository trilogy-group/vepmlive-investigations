using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class Calendars : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.Calendars";
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

        public static string CalendarRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadCalendarInfo":
                        int nCalendarId = Int32.Parse(xData.InnerText);
                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        DataAccess da = new DataAccess(sBaseInfo);
                        DBAccess dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            sReply = ReadCalendarInfo(dba, nCalendarId);
                            dba.Close();
                        }
                        break;
                    case "UpdateCalendarInfo":
                        sReply = UpdateCalendarInfo(Context, xData);
                        break;
                    case "DeleteCalendarInfo":
                        {
                            sReply = DeleteCalendarInfo(Context, xData);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "Calendars.CalendarRequest", ex.Message);
            }

            return sReply;
        }

        private static void InitializeColumns(_TGrid tg)
        {
            tg.AddColumn(title: "ID", width: 50, name: "PRD_ID", isId: true, type: _TGrid.Type.integer, hidden: true);
            tg.AddColumn(title: "Name", width: 150, name: "PRD_NAME", editable: true);
            tg.AddColumn(title: "Start", width: 100, name: "PRD_START_DATE", type: _TGrid.Type.date, editable: true);
            tg.AddColumn(title: "Finish", width: 100, name: "PRD_FINISH_DATE", type: _TGrid.Type.date, editable: true);
            //tg.AddColumn(title: "Desc", width: 180, name: "CB_DESC");
        }

        private static string ReadCalendarInfo(DBAccess dba, int nCalendarId)
        {
            CStruct xCalendar = new CStruct();
            xCalendar.Initialize("calendar");
            DataTable dt;
            dbaCalendars.SelectCalendar(dba, nCalendarId, out dt);
            xCalendar.CreateIntAttr("calendarid", nCalendarId);
            if (dt.Rows.Count == 1)
            {
                {
                    DataRow row = dt.Rows[0];
                    xCalendar.CreateString("name", DBAccess.ReadStringValue(row["CB_NAME"], ""));
                    xCalendar.CreateString("desc", DBAccess.ReadStringValue(row["CB_DESC"], ""));
                    DateTime date = DBAccess.ReadDateValue(row["CB_LOCK_TO"]);
                    if (date > DateTime.MinValue)
                        xCalendar.CreateDate("lockto", date);
                    date = DBAccess.ReadDateValue(row["CB_LOCK_FROM"]);
                    if (date > DateTime.MinValue)
                        xCalendar.CreateDate("lockfrom", date);
                }
                dbaCalendars.SelectCalendarPeriods(dba, nCalendarId, out dt);

                _TGrid tg = new _TGrid();
                tg.AddCfgAttr("AutoCalendar", "1");
                InitializeColumns(tg);
                tg.SetDataTable(dt);
                string tgridData = "";
                tg.Build(out tgridData);
                xCalendar.CreateString("tgridData", tgridData);

            }
            return xCalendar.XML();
        }
        private static string UpdateCalendarInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nCalendarId = Int32.Parse(xData.GetStringAttr("calendarid"));
                string sCalendarName = xData.GetStringAttr("name");
                dba.BeginTransaction();
                try
                {
                    int lRowsAffected;

                    if (dbaCalendars.UpdateCalendar(dba, ref nCalendarId, sCalendarName, "", out sReply) != StatusEnum.rsSuccess)
                    { if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "Calendars.UpdateCustomFieldInfo", dba.StatusText); }
                    else
                    {
                        string sXML = xData.InnerText;
                        _TGrid tg = new _TGrid();
                        InitializeColumns(tg);
                        DataTable dt = tg.SetXmlData(sXML);
                        if (dbaCalendars.CheckPeriods(dt, out sReply) != StatusEnum.rsSuccess)
                        {
                            if (sReply.Length == 0) { sReply = WebAdmin.FormatError("exception", "Calendars.CheckPeriods", "Saving Calendar '" + sCalendarName + "' failed"); }
                        }
                        if (sReply.Length > 0)
                        {
                            sReply = DBAccess.FormatAdminError("error", "Calendars.CheckPeriods", sReply);
                            dba.Status = StatusEnum.rsRequestCannotBeCompleted;
                        }
                        else
                        {
                            dbaCalendars.DeletePeriods(dba, nCalendarId, out lRowsAffected);
                            if (dbaCalendars.InsertPeriods(dba, nCalendarId, dt, out lRowsAffected) != StatusEnum.rsSuccess)
                            {
                                sReply = WebAdmin.FormatError("error", "Calendars.InsertPeriods", dba.StatusText);
                                dba.Status = StatusEnum.rsRequestCannotBeCompleted;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Calendars.UpdateCalendarInfo", "Saving Calendar '" + sCalendarName + "' failed.\n" + ex.Message);
                    dba.Status = (StatusEnum)99999;
                }

                if (dba.Status == StatusEnum.rsSuccess)
                {
                    dba.CommitTransaction();

                    //sReply = ReadCalendarInfo(dba, nCalendarId);

                    // submit Jobs to recalculate anything which may have been affected by changing the calendar
                    try
                    {
                        // if calendar we've just changed is the RP calendar then recalculate resource availability
                        DataTable dt;
                        int nRPCalendar=-1;
                        dbaGeneral.SelectAdmin(dba, out dt);
                        if (dt.Rows.Count == 1)
                        {
                            DataRow row = dt.Rows[0];
                            nRPCalendar = DBAccess.ReadIntValue(row["ADM_PORT_COMMITMENTS_CB_ID"]);
                        }

                        CStruct xQueue;
                        if (nRPCalendar==nCalendarId)
                        {
                            xQueue = new CStruct();
                            xQueue.Initialize("Queue");
                            xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcCalcAvailability);
                            xQueue.CreateString("Context", "Edit Calendar");
                            xQueue.CreateString("Comment", "Calculate Availability");
                            xQueue.CreateString("Data", "No Context Data");
                            AdminFunctions.SubmitJobRequest(dba, dba.UserWResID, xQueue.XML());

                            // this is useful for test
                            //AdminFunctions.CalcRPAllAvailabilities(dba);
                        }

                        // recalculate FTE values if using default values
                        xQueue = new CStruct();
                        xQueue.Initialize("Queue");
                        xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcCalcDefaultFTEs);
                        xQueue.CreateString("Context", "Edit Periods");
                        xQueue.CreateString("Comment", "Calculate Default FTE values");
                        xQueue.CreateString("Data", "No Context Data");
                        AdminFunctions.SubmitJobRequest(dba, dba.UserWResID, xQueue.XML());

                        // recalculate Cost Category Rates - not sure if this should be done by Job Server, right now there isn't an option set up so do it synchronously
                        if (!AdminFunctions.CalcCategoryRates(dba, out sReply))
                        {
                            sReply = DBAccess.FormatAdminError("error", "Calendars.UpdateCalendarInfo", sReply);
                            dba.Status = StatusEnum.rsRequestCannotBeCompleted;
                        }
                        else
                        {
                            CStruct xCalendar = new CStruct();
                            xCalendar.Initialize("calendar");
                            xCalendar.CreateIntAttr("calendarid", nCalendarId);
                            xCalendar.CreateStringAttr("name", sCalendarName);
                            sReply = xCalendar.XML();
                        }
                    }
                    catch (Exception ex)
                    {
                        sReply = WebAdmin.FormatError("exception", "Calendars.UpdateCalendarInfo", "Saving Calendar '" + sCalendarName + "' failed to execute follow up calculations.\n" + ex.Message);
                    }

                }
                else
                    dba.RollbackTransaction();

                dba.Close();
            }
            return sReply;
        }

        private static string DeleteCalendarInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nCalendar = xData.GetIntAttr("calendarid");
                try
                {
                    dbaCalendars.DeleteCalendar(dba, nCalendar, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Calendars.DeleteCalendar", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        #endregion
    }
}
