using System;
using System.Data;
using System.Diagnostics;
using System.Web;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    internal class FteHelper
    {
        internal static void InitializeFTEColumns(DBAccess dbAccess, int calendarId, _TGrid tGrid)
        {
            DataTable dataTable;
            DataTable dtPeriods;
            dbaCalendars.SelectCalendarPeriods(dbAccess, calendarId, out dtPeriods);

            // looks like following stmnt might not be used?
            dbaCalendars.ReadCalendarFTEs(dbAccess, calendarId, out dataTable);

            tGrid.AddColumn("ID", 50, name: "BC_UID", isId: true, hidden: true);
            tGrid.AddColumn("Category", 180, name: "BC_NAME", maincol: true);

            tGrid.AddColumn("Level", 180, name: "BC_LEVEL", mainlevelcol: true, hidden: true);
            tGrid.AddColumn("Role", 180, name: "BC_ROLE", hidden: true);
            foreach (DataRow row in dtPeriods.Rows)
            {
                var periodId = SqlDb.ReadIntValue(row["PRD_ID"]);
                var periodName = SqlDb.ReadStringValue(row["PRD_NAME"]);
                tGrid.AddColumn(periodName, 70, name: string.Format("P{0}", periodId), editable: true, align: _TGrid.Align.center);
            }
        }

        internal static string ReadCalendarFTEsInfo(HttpContext context, CStruct data)
        {
            var reply = string.Empty;
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        var calendarId = -1;
                        int i;
                        if (int.TryParse(data.InnerText, out i))
                        {
                            calendarId = i;
                        }
                        var xCostCategory = new CStruct();
                        xCostCategory.Initialize("FTEs");
                        xCostCategory.CreateIntAttr("CB_ID", calendarId);
                        DataTable dataTable;
                        dbaCalendars.SelectCalendars(dbAccess, out dataTable);
                        var calendars = xCostCategory.CreateSubStruct("calendars");
                        var item = calendars.CreateSubStruct("item");
                        item.CreateIntAttr("id", -1);
                        item.CreateStringAttr("name", "--Select a Calendar--");
                        foreach (DataRow row in dataTable.Rows)
                        {
                            item = calendars.CreateSubStruct("item");
                            var nCalendar = SqlDb.ReadIntValue(row["CB_ID"]);
                            item.CreateIntAttr("id", nCalendar);
                            item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CB_NAME"]));
                        }

                        var tGrid = new _TGrid();
                        InitializeFTEColumns(dbAccess, calendarId, tGrid);
                        dbaCalendars.ReadCalendarFTEs(dbAccess, calendarId, out dataTable);
                        tGrid.SetDataTable(dataTable);
                        string tGridFtes;
                        tGrid.Build(out tGridFtes);
                        xCostCategory.CreateString("tgridFTEs", tGridFtes);
                        reply = xCostCategory.XML();
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostCategories.ReadCalendarFTEsInfo", ex.Message);
                    }
                }
            }
            return reply;
        }

        internal static string SaveCalendarFTEsInfo(HttpContext context, CStruct data)
        {
            var reply = string.Empty;
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            DBAccess dbAcess;
            using (var dataAccess = new DataAccess(baseInfo))
            {
                dbAcess = dataAccess.dba;
                if (dbAcess.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        var nCalendarId = data.GetIntAttr("CB_ID");
                        var tg = new _TGrid();
                        InitializeFTEColumns(dbAcess, nCalendarId, tg);

                        var stgridFTEs = data.InnerText;
                        var dt = tg.SetXmlData(stgridFTEs);
                        if (dbaCostCategories.UpdateCostCategoryFTEs(dbAcess, nCalendarId, dt, out reply)
                            != StatusEnum.rsSuccess)
                        {
                            if (reply.Length == 0)
                            {
                                reply = WebAdmin.FormatError(
                                    "exception",
                                    "CostCategories.SaveCalendarFTEsInfo",
                                    dbAcess.StatusText);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostCategories.SaveCalendarFTEsInfo", ex.Message);
                    }
                }
            }
            return reply;
        }
    }
}