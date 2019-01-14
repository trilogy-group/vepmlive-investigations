using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                    // Error reported by Mark Virnig working with CEVA - Locks are period ids not dates - However, don't appear to be used
                    //DateTime date = DBAccess.ReadDateValue(row["CB_LOCK_TO"]);
                    //if (date > DateTime.MinValue)
                    //    xCalendar.CreateDate("lockto", date);
                    //date = DBAccess.ReadDateValue(row["CB_LOCK_FROM"]);
                    //if (date > DateTime.MinValue)
                    //    xCalendar.CreateDate("lockfrom", date);
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
            var reply = string.Empty;
            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    var calendarId = int.Parse(xData.GetStringAttr("calendarid"));
                    var calendarName = xData.GetStringAttr("name");
                    dataAccessDba.BeginTransaction();

                    reply = UpdateOnDataBase(xData, dataAccessDba, calendarName, ref calendarId);

                    if (dataAccessDba.Status == StatusEnum.rsSuccess)
                    {
                        dataAccessDba.CommitTransaction();

                        // submit Jobs to recalculate anything which may have been affected by changing the calendar
                        try
                        {
                            RecalculateResourceAvailability(dataAccessDba, calendarId, dataAccess);
                            RecalculateFteValues(dataAccessDba, dataAccess);
                            reply = RecalculateCostCategoryRates(dataAccessDba, calendarId, calendarName);
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Exception Suppressed {0}", ex);
                            reply = WebAdmin.FormatError(
                                "exception",
                                "Calendars.UpdateCalendarInfo",
                                string.Format("Saving Calendar '{0}' failed to execute follow up calculations.\n{1}", calendarName, ex.Message));
                        }
                    }
                    else
                    {
                        dataAccessDba.RollbackTransaction();
                    }
                }
            }
            return reply;
        }

        private static string RecalculateCostCategoryRates(DBAccess dataAccessDba, int calendarId, string calendarName)
        {
            string reply;

            // recalculate Cost Category Rates - not sure if this should be done by Job Server, right now there isn't an option set up so do it synchronously
            if (!AdminFunctions.CalcCategoryRates(dataAccessDba, out reply))
            {
                reply = SqlDb.FormatAdminError("error", "Calendars.UpdateCalendarInfo", reply);
                dataAccessDba.Status = StatusEnum.rsRequestCannotBeCompleted;
            }
            else
            {
                var calendar = new CStruct();
                calendar.Initialize("calendar");
                calendar.CreateIntAttr("calendarid", calendarId);
                calendar.CreateStringAttr("name", calendarName);
                reply = calendar.XML();
            }
            return reply;
        }

        private static void RecalculateFteValues(DBAccess dataAccessDba, DataAccess dataAccess)
        {
            // recalculate FTE values if using default values
            var queue = new CStruct();
            queue.Initialize("Queue");
            queue.CreateInt("JobContext", (int)QueuedJobContext.qjcCalcDefaultFTEs);
            queue.CreateString("Context", "Edit Periods");
            queue.CreateString("Comment", "Calculate Default FTE values");
            queue.CreateString("Data", "No Context Data");
            AdminFunctions.SubmitJobRequest(dataAccessDba, dataAccessDba.UserWResID, queue.XML(), dataAccess.BasePath);
        }

        private static void RecalculateResourceAvailability(DBAccess dataAccessDba, int calendarId, DataAccess dataAccess)
        {
            // if calendar we've just changed is the RP calendar then recalculate resource availability
            DataTable dataTable;
            var rpCalendar = -1;
            dbaGeneral.SelectAdmin(dataAccessDba, out dataTable);
            if (dataTable.Rows.Count == 1)
            {
                var row = dataTable.Rows[0];
                rpCalendar = SqlDb.ReadIntValue(row["ADM_PORT_COMMITMENTS_CB_ID"]);
            }

            if (rpCalendar == calendarId)
            {
                var queue = new CStruct();
                queue.Initialize("Queue");
                queue.CreateInt("JobContext", (int)QueuedJobContext.qjcCalcAvailability);
                queue.CreateString("Context", "Edit Calendar");
                queue.CreateString("Comment", "Calculate Availability");
                queue.CreateString("Data", "No Context Data");
                AdminFunctions.SubmitJobRequest(dataAccessDba, dataAccessDba.UserWResID, queue.XML(), dataAccess.BasePath);

                // CC-77735 Since the commented out is not broken I'm keeping it because as the comment below is useful for testing
                // this is useful for test
                //AdminFunctions.CalcRPAllAvailabilities(dataAccessDba);
            }
        }

        private static string UpdateOnDataBase(CStruct data, DBAccess dataAccessDba, string calendarName, ref int calendarId)
        {
            string reply;
            try
            {
                int rowsAffected;

                if (dbaCalendars.UpdateCalendar(dataAccessDba, ref calendarId, calendarName, string.Empty, out reply) != StatusEnum.rsSuccess)
                {
                    if (reply.Length == 0)
                    {
                        reply = WebAdmin.FormatError("exception", "Calendars.UpdateCustomFieldInfo", dataAccessDba.StatusText);
                    }
                }
                else
                {
                    var xml = data.InnerText;
                    var tGrid = new _TGrid();
                    InitializeColumns(tGrid);

                    // CC-77735 Not calling dispose as instance isn't owned by this code
                    var dataTable = tGrid.SetXmlData(xml);
                    if (dbaCalendars.CheckPeriods(dataTable, out reply) != StatusEnum.rsSuccess && reply.Length == 0)
                    {
                        reply = WebAdmin.FormatError("exception", "Calendars.CheckPeriods", "Saving Calendar '" + calendarName + "' failed");
                    }
                    if (reply.Length > 0)
                    {
                        reply = SqlDb.FormatAdminError("error", "Calendars.CheckPeriods", reply);
                        dataAccessDba.Status = StatusEnum.rsRequestCannotBeCompleted;
                    }
                    else
                    {
                        dbaCalendars.DeletePeriods(dataAccessDba, calendarId, out rowsAffected);
                        if (dbaCalendars.InsertPeriods(dataAccessDba, calendarId, dataTable, out rowsAffected) != StatusEnum.rsSuccess)
                        {
                            reply = WebAdmin.FormatError("error", "Calendars.InsertPeriods", dataAccessDba.StatusText);
                            dataAccessDba.Status = StatusEnum.rsRequestCannotBeCompleted;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                reply = WebAdmin.FormatError(
                    "exception",
                    "Calendars.UpdateCalendarInfo",
                    string.Format("Saving Calendar '{0}' failed.\n{1}", calendarName, ex.Message));
                dataAccessDba.Status = (StatusEnum)99999;
            }
            return reply;
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
