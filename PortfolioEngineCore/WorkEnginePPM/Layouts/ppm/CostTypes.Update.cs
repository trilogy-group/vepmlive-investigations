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
        private static string UpdateCostTotalsInfo(HttpContext Context, CStruct xData)
        {
            var ctId = xData.GetIntAttr("CT_ID");
            var tGridCostTotals = xData.GetString("tgridCostTotals");
            var reply = string.Empty;

            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                // CC-78689 Can't dispose as the instance is not owned by this code, but I'll move the close call to a finally
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        var tGrid = new _TGrid();
                        tGrid.AddColumn("ID", 50, name: "CB_ID", isId: true, hidden: true);
                        tGrid.AddColumn("Calendar", 200, name: "CB_NAME", type: _TGrid.Type.text, maincol: true, editable: false);

                        // CC-78689 Not used variable, used to read on the following commented code.
                        // I'll leave unchanged as a receiver of the result as the call causes side effects
                        var col = tGrid.AddColumn("Total Field", 210, name: "BUDGET_TOTAL_FIELD", editable: true, type: _TGrid.Type.combo);

                        // CC-78689 leaving declaration far from usage to preserve layout of the commented code
                        DataTable dataTable;

                        //dbaCostTypes.SelectBudgetTotalList(dba, out dt);
                        //col.AddKeyValuePair(0, "[None]");
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    col.AddKeyValuePair(DBAccess.ReadIntValue(row["FA_FIELD_ID"]), DBAccess.ReadStringValue(row["FA_NAME"]));
                        //}
                        tGrid.SetXmlData(tGridCostTotals);
                        dataTable = tGrid.GetDataTable();

                        if (dbaCostTypes.UpdateCostTotalsInfo(dbAccess, ctId, dataTable, out reply) != StatusEnum.rsSuccess && reply.Length == 0)
                        {
                            reply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo2", dbAccess.StatusText);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTotalsInfo", ex.Message);
                    }
                    finally
                    {
                        dbAccess.Close();
                    }
                }
            }
            return reply;
        }

        private static string UpdateSecurityInfo(HttpContext Context, CStruct xData)
        {
            var ctId = xData.GetIntAttr("CT_ID");
            var tGridSecurity = xData.GetString("tgridSecurity");
            var reply = string.Empty;

            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                // CC-78689 Can't dispose as the instance is not owned by this code, but I'll move the close call to a finally
                var accessDba = dataAccess.dba;
                if (accessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        // pick up lines from CFs grid - a flat list
                        var sgStruct = new CStruct();
                        sgStruct.Initialize("SGs");

                        if (tGridSecurity.Length > 0)
                        {
                            var grid = new CStruct();
                            grid.LoadXML(tGridSecurity);
                            var body = grid.GetSubStruct("Body");
                            var bStruct = body.GetSubStruct("B");
                            var listIParent = bStruct.GetList("I");

                            foreach (var iStructs in listIParent)
                            {
                                var groupId = iStructs.GetIntAttr("GROUP_ID");
                                var readable = iStructs.GetIntAttr("DS_READ");
                                var editable = iStructs.GetIntAttr("DS_EDIT");
                                if (editable > 0 || readable > 0)
                                {
                                    var sgSubStruct = sgStruct.CreateSubStruct("SG");
                                    sgSubStruct.CreateIntAttr("ID", groupId);
                                    sgSubStruct.CreateIntAttr("Readable", readable);
                                    sgSubStruct.CreateIntAttr("Editable", editable);
                                }
                            }
                        }
                        if (dbaCostTypes.UpdateCostTypeSecurityInfo(accessDba, ctId, sgStruct, out reply) != StatusEnum.rsSuccess
                            && reply.Length == 0)
                        {
                            reply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo2", accessDba.StatusText);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostTypes.UpdateSecurityInfo", ex.Message);
                    }
                    finally
                    {
                        accessDba.Close();
                    }
                }
            }
            return reply;
        }

        private static string UpdateCostTypeInfo(HttpContext Context, CStruct xData)
        {
            var ctId = xData.GetIntAttr("CT_ID");
            var name = xData.GetStringAttr("CT_NAME");
            var namedRates = xData.GetIntAttr("CT_NAMEDRATES");
            var initialLevel = xData.GetIntAttr("CT_INITIAL_LEVEL");
            var inputCalendar = xData.GetIntAttr("CT_CB_ID");
            var editMode = xData.GetIntAttr("CT_EDIT_MODE");
            var tGridCfData = xData.GetString("tgridCFData");
            var tGridData = xData.GetString("tgridData");
            var formula = xData.GetStringAttr("formula");
            var reply = string.Empty;

            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                // CC-78689 Can't dispose as the instance is not owned by this code, but I'll move the close call to a finally
                var dataAccessDba = dataAccess.dba;
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        var availCcs = new CStruct();
                        availCcs.Initialize("AvailCCs");
                        var calcs = new CStruct();
                        calcs.Initialize("Calcs");

                        List<CStruct> listIParent;

                        // pick up lines from Available CCs or Calcs in bottom grid
                        if (tGridData.Length > 0)
                        {
                            var xGrid = new CStruct();
                            xGrid.LoadXML(tGridData);
                            var xBody = xGrid.GetSubStruct("Body");
                            var bStrucct = xBody.GetSubStruct("B");
                            listIParent = bStrucct.GetList("I");

                            if (editMode == (int)CTEditMode.ctCalculated || editMode == (int)CTEditMode.ctCalculatedCumulative)
                            {
                                //  passing Formula straight through now
                                //if (sFormula != "")
                                //{
                                //    sReply = dbaCostTypes.ValidateAndSaveCostTypeFormula(dba, nCTID, ref sFormula, true);
                                //    if (sReply != "")
                                //    {
                                //        dba.Close();
                                //        return sReply;
                                //    }
                                //}
                            }
                            else
                            {
                                // pick up lines from Available CCs grid that are set on - ccs are a structure
                                var availCCs = new List<int>();

                                // the result of this call is to go through the cc structure and get all ccs which are selected into the availCCs List
                                GetCCs(listIParent, availCCs);

                                foreach (var nItem in availCCs)
                                {
                                    var xAvailCC = availCcs.CreateSubStruct("AvailCC");
                                    xAvailCC.CreateIntAttr("BC_UID", nItem);
                                }
                            }
                        }

                        // pick up lines from CFs grid - a flat list
                        var cfsStruct = new CStruct();
                        cfsStruct.Initialize("CFs");

                        if (tGridCfData.Length > 0)
                        {
                            var grid = new CStruct();
                            grid.LoadXML(tGridCfData);
                            var body = grid.GetSubStruct("Body");
                            var bStruct = body.GetSubStruct("B");
                            listIParent = bStruct.GetList("I");

                            foreach (var iParent in listIParent)
                            {
                                var fieldId = iParent.GetIntAttr("FA_FIELD_ID");
                                var editable = iParent.GetIntAttr("CF_EDITABLE");
                                var visible = iParent.GetIntAttr("CF_VISIBLE");
                                var frozen = iParent.GetIntAttr("CF_FROZEN");
                                var identity = iParent.GetIntAttr("CF_IDENTITY");
                                var required = iParent.GetIntAttr("CF_REQUIRED");
                                if (editable > 0 || visible > 0 || frozen > 0 || identity > 0 || required > 0)
                                {
                                    var cfStruct = cfsStruct.CreateSubStruct("CF");
                                    cfStruct.CreateIntAttr("ID", fieldId);
                                    cfStruct.CreateIntAttr("Editable", editable);
                                    cfStruct.CreateIntAttr("Visible", visible);
                                    cfStruct.CreateIntAttr("Frozen", frozen);
                                    cfStruct.CreateIntAttr("Identity", identity);
                                    cfStruct.CreateIntAttr("Required", required);
                                }
                            }
                        }

                        if (dbaCostTypes.UpdateCostTypeInfo(
                                dataAccessDba,
                                ref ctId,
                                name,
                                editMode,
                                initialLevel,
                                inputCalendar,
                                namedRates,
                                availCcs,
                                cfsStruct,
                                formula,
                                out reply)
                            != StatusEnum.rsSuccess)
                        {
                            if (reply.Length == 0)
                            {
                                reply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo2", dataAccessDba.StatusText);
                            }
                        }
                        else
                        {
                            //  needed to update list after SAVE
                            var costType = new CStruct();
                            costType.Initialize("costtype");
                            costType.CreateIntAttr("CT_ID", ctId);
                            costType.CreateStringAttr("CT_NAME", name);
                            reply = costType.XML();
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo3", ex.Message);
                    }
                    dataAccessDba.Close();
                }
            }
            return reply;
        }

        private static string UpdatePostOptionsInfo(HttpContext Context, CStruct xData)
        {
            var ctId = xData.GetIntAttr("CT_ID");
            var reply = string.Empty;

            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                // CC-78689 Can't dispose as the instance is not owned by this code, but I'll move the close call to a finally
                var dataAccessDba = dataAccess.dba;
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        // pick up comma separated list of calendars 
                        var sCalendars = xData.GetStringAttr("calendars");
                        var autoPostOnRateChange = xData.GetBooleanAttr("autoPostOnRateChange", false);

                        if (dbaCostTypes.UpdatePostOptionsInfo(dataAccessDba, ctId, sCalendars, autoPostOnRateChange, out reply)
                            != StatusEnum.rsSuccess
                            && reply.Length == 0)
                        {
                            reply = WebAdmin.FormatError("exception", "CostTypes.UpdatePostOptionsInfo", dataAccessDba.StatusText);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "CostTypes.UpdatePostOptionsInfo", ex.Message);
                    }
                    finally
                    {
                        dataAccessDba.Close();
                    }
                }
            }
            return reply;
        }
    }
}