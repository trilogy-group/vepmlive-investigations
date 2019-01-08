using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public partial class CostTypes
    {
        private static void GetCostTypesInfo(HttpContext context, CStruct data, ref string reply)
        {
            var ctId = int.Parse(data.InnerText);
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                // CC-78689 Can't dispose as the instance is not owned by this code, but I'll move the close call to a finally
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        DataTable dataTable;
                        if (dbaCostTypes.SelectCostType(dbAccess, ctId, out dataTable) != StatusEnum.rsSuccess)
                        {
                            reply = WebAdmin.FormatError("exception", "CostTypes.GetCostTypesInfo", dbAccess.StatusText);
                        }
                        else
                        {
                            var costTypes = new CStruct();
                            var editMode = PopulateBasicCostTypeAttributes(costTypes, dataTable);
                            PopulateCalendar(costTypes, dbAccess);
                            PopulateCFGrid(dbAccess, ctId, costTypes);
                            PopulateNamesAndIds(dbAccess, ctId, costTypes);
                            PopulateTGridData(editMode, dbAccess, ctId, costTypes);
                            reply = costTypes.XML();
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppresed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostTypes.GetCostTypesInfo", ex.Message);
                    }
                    finally
                    {
                        dbAccess.Close();
                    }
                }
            }
        }

        private static string GetCostTotalsInfo(HttpContext Context, CStruct xData)
        {
            var reply = string.Empty;
            var ctId = int.Parse(xData.InnerText);
            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            var dataAccess = new DataAccess(baseInfo);
            var dataAccessDba = dataAccess.dba;
            if (dataAccessDba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    var costTotals = new CStruct();
                    costTotals.Initialize("costTotals");
                    var tGrid = new _TGrid();
                    tGrid.AddColumn("ID", 50, name: "CB_ID", isId: true, hidden: true);
                    tGrid.AddColumn("Calendar", 200, name: "CB_NAME", type: _TGrid.Type.text, maincol: true, editable: false);
                    var column = tGrid.AddColumn("Total Field", 218, name: "BUDGET_TOTAL_FIELD", editable: true, type: _TGrid.Type.combo);
                    DataTable dataTable;
                    dbaCostTypes.SelectBudgetTotalList(dataAccessDba, out dataTable);
                    column.AddKeyValuePair(0, "[None]");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        column.AddKeyValuePair(SqlDb.ReadIntValue(row["FA_FIELD_ID"]), SqlDb.ReadStringValue(row["FA_NAME"]));
                    }

                    dbaCostTypes.SelectCostTotalsInfo(dataAccessDba, ctId, out dataTable);
                    tGrid.SetDataTable(dataTable);
                    string tableData;
                    tGrid.Build(out tableData);
                    costTotals.CreateString("tableData", tableData);
                    reply = costTotals.XML();
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppresed {0}", ex);
                    reply = WebAdmin.FormatError("exception", "CostTypes.GetCostTotalsInfo", ex.Message);
                }
                finally
                {
                    dataAccessDba.Close();
                }
            }
            return reply;
        }

        private static string GetPostOptionsInfo(HttpContext Context, CStruct xData)
        {
            var reply = string.Empty;
            var ctId = int.Parse(xData.InnerText);
            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                var dataAccessDba = dataAccess.dba;
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        var postOptions = new CStruct();
                        postOptions.Initialize("postOptions");
                        var calendars = postOptions.CreateSubStruct("calendars");
                        DataTable dataTable;
                        dbaCostTypes.SelectCostTypePostOptions(dataAccessDba, ctId, out dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var calendarId = SqlDb.ReadIntValue(row["CB_ID"]);

                            //if (editmode != 1 || calendarId != ctCalendarId)
                            {
                                var item = calendars.CreateSubStruct("item");
                                item.CreateIntAttr("id", calendarId);
                                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CB_NAME"], string.Empty));
                                item.CreateIntAttr("used", SqlDb.ReadIntValue(row["used"]));
                            }
                        }

                        postOptions.CreateBooleanAttr(
                            "autoPostOnRateChange",
                            dbaCostTypes.IsAutoPostEnabledOnRatePerProjectChange(dataAccessDba, ctId));
                        reply = postOptions.XML();
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppresed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostTypes.GetPostOptionsInfo", ex.Message);
                    }
                    finally
                    {
                        dataAccessDba.Close();
                    }
                }
            }
            return reply;
        }

        private static bool GetCCs(List<CStruct> listItems, List<int> availCCs)
        {
            foreach (var item in listItems)
            {
                var id = item.GetIntAttr("BC_UID");
                var isChecked = item.GetIntAttr("BC_UID_incl");
                if (isChecked > 0)
                {
                    availCCs.Add(id);
                }
                var listIparent = new List<CStruct>();
                listIparent = item.GetList("I");
                if (listIparent.Count > 0)
                {
                    GetCCs(listIparent, availCCs);
                }
            }
            return true;
        }
    }
}