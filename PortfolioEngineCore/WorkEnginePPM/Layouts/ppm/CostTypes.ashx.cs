using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class CostTypes : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.CostTypes";
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

        private static void InitializeCustomFieldColumns(_TGrid tg)
        {
            tg.AddColumn(title: "CTID", width: 50, name: "CT_ID", hidden: true);
            tg.AddColumn(title: "CFID", width: 50, name: "FA_FIELD_ID", isId: true, hidden: true);
            tg.AddColumn(title: "Name", width: 100, name: "FA_NAME", editable: false);
            tg.AddColumn(title: "Visible", width: 60, name: "CF_VISIBLE", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Frozen", width: 60, name: "CF_FROZEN", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Editable", width: 60, name: "CF_EDITABLE", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Required", width: 60, name: "CF_REQUIRED", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Identity", width: 60, name: "CF_IDENTITY", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
        }

        private static void InitializeCostCategoryColumns(_TGrid tg)
        {
            tg.AddColumn(title: "ID", width: 50, name: "BC_UID", isId: true, hidden: true);
            tg.AddColumn(title: "Include", width: 60, name: "BC_UID_incl", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Name", width: 180, name: "BC_NAME", maincol: true, editable: false);
            tg.AddColumn(title: "Level", width: 180, name: "BC_LEVEL", mainlevelcol: true, hidden: true);
        }

        private static void InitializeSecurityColumns(_TGrid tg)
        {
            tg.AddColumn(title: "ID", width: 50, name: "GROUP_ID", isId: true, hidden: true);
            tg.AddColumn(title: "Permission Group", width: 156, name: "GROUP_NAME", maincol: true, editable: false);
            tg.AddColumn(title: "Read", width: 50, name: "DS_READ", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Edit", width: 50, name: "DS_EDIT", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
        }

        public static string CostTypesRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            var reply = string.Empty;
            try
            {
                ProcessRequest(Context, sRequestContext, xData, ref reply);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                reply = WebAdmin.FormatError("exception", "CostTypes.CostTypesRequest", ex.Message);
            }

            return reply;
        }

        private static void ProcessRequest(HttpContext context, string requestContext, CStruct data, ref string reply)
        {
            switch (requestContext)
            {
                case "GetCostTypesInfo":
                {
                    GetCostTypesInfo(context, data, ref reply);
                    break;
                }
                case "GetCostTotalsInfo":
                {
                    reply = GetCostTotalsInfo(context, data);
                    break;
                }
                case "UpdateCostTotalsInfo":
                {
                    reply = UpdateCostTotalsInfo(context, data);
                    break;
                }
                case "GetSecurityInfo":
                {
                    reply = GetSecurityInfo(context, data);
                    break;
                }
                case "GetPostOptionsInfo":
                {
                    reply = GetPostOptionsInfo(context, data);
                    break;
                }
                case "UpdateSecurityInfo":
                {
                    reply = UpdateSecurityInfo(context, data);
                    break;
                }
                case "UpdatePostOptionsInfo":
                {
                    reply = UpdatePostOptionsInfo(context, data);
                    break;
                }
                case "UpdateCosttypeInfo":
                {
                    reply = UpdateCostTypeInfo(context, data);
                    break;
                }
                case "DeleteCostType":
                {
                    reply = DeleteCostType(context, data);
                    break;
                }
                case "ValidateFormula":
                {
                    ValidateFormula(context, data, ref reply);
                    break;
                }
                case "ReadCalendarsForCostType":
                {
                    reply = ReadCalendarsForCostType(context, data, reply);
                    break;
                }
                case "PostCostValues":
                {
                    reply = PostCostValues(context, data, reply);
                    break;
                }
                default:
                    Trace.TraceError("Unexpected Value {0}", requestContext);
                    break;
            }
        }

        private static string PostCostValues(HttpContext context, CStruct data, string reply)
        {
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    reply = PostCostValues(dbAccess, data, dataAccess.BasePath);
                }
            }
            return reply;
        }

        private static string ReadCalendarsForCostType(HttpContext context, CStruct data, string reply)
        {
            int fieldId;
            if (int.TryParse(data.InnerText, out fieldId))
            {
                var baseInfo = WebAdmin.BuildBaseInfo(context);
                using (var dataAccess = new DataAccess(baseInfo))
                {
                    var dbAccess = dataAccess.dba;
                    if (dbAccess.Open() == StatusEnum.rsSuccess)
                    {
                        reply = ReadCalendarsForCostType(dbAccess, fieldId);
                    }
                }
                return reply;
            }
            return string.Empty;
        }

        private static void ValidateFormula(HttpContext context, CStruct data, ref string reply)
        {
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    var ctId = data.GetIntAttr("CT_ID");
                    var formula = data.GetStringAttr("formula");
                    reply = dbaCostTypes.ValidateAndSaveCostTypeFormula(dbAccess, ctId, ref formula, false);
                }
            }
        }

        private static void GetCostTypesInfo(HttpContext context, CStruct data, ref string reply)
        {
            var ctId = int.Parse(data.InnerText);
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
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
            }
        }

        private static void PopulateTGridData(int editMode, DBAccess dbAccess, int ctId, CStruct costTypes)
        {
            DataTable dataTable;
            if (editMode == (int)CTEditMode.ctCalculated || editMode == (int)CTEditMode.ctCalculatedCumulative)
            {
                //  why is this here?  maybe it is needed to ensure TGrid initializes correctly even when not used? Maybe can switch to it w/o going back to server?
                dbaUsers.SelectAvailCCs(dbAccess, ctId, out dataTable);
                var tGrid = new _TGrid();
                InitializeCostCategoryColumns(tGrid);
                tGrid.SetDataTable(dataTable);
                string tgridData;
                tGrid.Build(out tgridData);
                costTypes.CreateString("tgridData", tgridData);

                var formula = new StringBuilder();
                dbaCostTypes.SelectCostTypeFormula(dbAccess, ctId, out dataTable);
                var first = true;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var component = SqlDb.ReadStringValue(dataRow["CT_NAME"], string.Empty);
                    var clOp = SqlDb.ReadIntValue(dataRow["CL_OP"]);

                    if (!first)
                    {
                        switch (clOp)
                        {
                            case 0:
                                formula.Append(" + ");
                                break;
                            case 1:
                                formula.Append(" - ");
                                break;
                        }
                    }
                    formula.Append(component);

                    first = false;
                }
                costTypes.CreateString("formula", formula.ToString());
            }
            else
            {
                dbaUsers.SelectAvailCCs(dbAccess, ctId, out dataTable);
                var tGrid = new _TGrid();
                InitializeCostCategoryColumns(tGrid);
                tGrid.SetDataTable(dataTable);
                string tgridData;
                tGrid.Build(out tgridData);
                costTypes.CreateString("tgridData", tgridData);
            }
        }

        private static void PopulateNamesAndIds(DBAccess dbAccess, int ctId, CStruct costTypes)
        {
            DataTable dataTable;
            dbaCostTypes.SelectCostTypesForCalc(dbAccess, ctId, out dataTable);
            var fields = costTypes.CreateSubStruct("fields");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var field = fields.CreateSubStruct("field");
                const string CtId = "CT_ID";
                field.CreateInt(CtId, SqlDb.ReadIntValue(dataRow[CtId]));
                field.CreateString("CT_NAME", SqlDb.ReadStringValue(dataRow["CT_NAME"], ""));
            }
        }

        private static void PopulateCFGrid(DBAccess dbAccess, int ctId, CStruct costTypes)
        {
            DataTable dataTable;
            dbaCostTypes.SelectInitializedCostTypeCustomFields(dbAccess, ctId, out dataTable);
            var tGrid = new _TGrid();
            InitializeCustomFieldColumns(tGrid);
            tGrid.SetDataTable(dataTable);
            string tgridData;
            tGrid.Build(out tgridData);
            costTypes.CreateString("tgridCFData", tgridData);
        }

        private static void PopulateCalendar(CStruct costTypes, DBAccess dbAccess)
        {
            var calendars = costTypes.CreateSubStruct("calendars");
            var item = calendars.CreateSubStruct("item");
            item.CreateIntAttr("id", -1);
            item.CreateStringAttr("name", "[None]");
            {
                DataTable dataTable;
                dbaCalendars.SelectCalendars(dbAccess, out dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    item = calendars.CreateSubStruct("item");
                    var nCalendar = SqlDb.ReadIntValue(row["CB_ID"]);
                    item.CreateIntAttr("id", nCalendar);
                    item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CB_NAME"]));
                }
            }
        }

        private static int PopulateBasicCostTypeAttributes(CStruct costTypes, DataTable dataTable)
        {
            costTypes.Initialize("costtype");
            var nEditMode = (int)CTEditMode.ctBudget;
            if (dataTable.Rows.Count == 1)
            {
                var row = dataTable.Rows[0];
                costTypes.CreateIntAttr("CT_ID", SqlDb.ReadIntValue(row["CT_ID"]));
                costTypes.CreateStringAttr("CT_NAME", SqlDb.ReadStringValue(row["CT_NAME"]));
                nEditMode = SqlDb.ReadIntValue(row["CT_EDIT_MODE"]);
                costTypes.CreateIntAttr("CT_EDIT_MODE", nEditMode);
                var selectedCalendar = SqlDb.ReadIntValue(row["CT_CB_ID"]);
                costTypes.CreateIntAttr("CT_CB_ID", selectedCalendar);
                costTypes.CreateIntAttr("CT_INITIAL_LEVEL", SqlDb.ReadIntValue(row["INITIAL_LEVEL"]));
                costTypes.CreateIntAttr("CT_NAMEDRATES", SqlDb.ReadIntValue(row["CT_ALLOW_NAMED_RATES"]));
            }
            else
            {
                costTypes.CreateIntAttr("CT_ID", 0);
                costTypes.CreateStringAttr("CT_NAME", "New Cost Type");
                costTypes.CreateIntAttr("CT_EDIT_MODE", nEditMode);
                costTypes.CreateIntAttr("CT_CB_ID", -1);
                costTypes.CreateIntAttr("CT_INITIAL_LEVEL", 1);
                costTypes.CreateIntAttr("CT_NAMEDRATES", 0);
            }
            return nEditMode;
        }

        private static string GetCostTotalsInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            int nCTId = Int32.Parse(xData.InnerText);
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    CStruct xCostTotals = new CStruct();
                    xCostTotals.Initialize("costTotals");
                    _TGrid tg = new _TGrid();
                    tg.AddColumn(title: "ID", width: 50, name: "CB_ID", isId: true, hidden: true);
                    tg.AddColumn(title: "Calendar", width: 200, name: "CB_NAME", type: _TGrid.Type.text, maincol: true, editable: false);
                    _TGrid.TCol col = tg.AddColumn(title: "Total Field", width: 218, name: "BUDGET_TOTAL_FIELD", editable: true, type: _TGrid.Type.combo);
                    DataTable dt;
                    dbaCostTypes.SelectBudgetTotalList(dba, out dt);
                    col.AddKeyValuePair(0, "[None]");
                    foreach (DataRow row in dt.Rows)
                    {
                        col.AddKeyValuePair(DBAccess.ReadIntValue(row["FA_FIELD_ID"]), DBAccess.ReadStringValue(row["FA_NAME"]));
                    }

                    dbaCostTypes.SelectCostTotalsInfo(dba, nCTId, out dt);
                    tg.SetDataTable(dt);
                    string tableData;
                    tg.Build(out tableData);
                    xCostTotals.CreateString("tableData", tableData);
                    sReply = xCostTotals.XML();

                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.GetCostTotalsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string UpdateCostTotalsInfo(HttpContext Context, CStruct xData)
        {
            int nCTID = xData.GetIntAttr("CT_ID");
            string stgridCostTotals = xData.GetString("tgridCostTotals");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    _TGrid tg = new _TGrid();
                    tg.AddColumn(title: "ID", width: 50, name: "CB_ID", isId: true, hidden: true);
                    tg.AddColumn(title: "Calendar", width: 200, name: "CB_NAME", type: _TGrid.Type.text, maincol: true, editable: false);
                    _TGrid.TCol col = tg.AddColumn(title: "Total Field", width: 210, name: "BUDGET_TOTAL_FIELD", editable: true, type: _TGrid.Type.combo);
                    DataTable dt;
                    //dbaCostTypes.SelectBudgetTotalList(dba, out dt);
                    //col.AddKeyValuePair(0, "[None]");
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    col.AddKeyValuePair(DBAccess.ReadIntValue(row["FA_FIELD_ID"]), DBAccess.ReadStringValue(row["FA_NAME"]));
                    //}
                    tg.SetXmlData(stgridCostTotals);
                    dt = tg.GetDataTable();

                    if (dbaCostTypes.UpdateCostTotalsInfo(dba, nCTID, dt, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo2", dba.StatusText);
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTotalsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string GetSecurityInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            int nCTId = Int32.Parse(xData.InnerText);
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    DataTable dt;
                    dbaGroups.SelectCostTypeSecurityGroups(dba, nCTId, out dt);
                    _TGrid tg = new _TGrid();
                    InitializeSecurityColumns(tg);
                    tg.SetDataTable(dt);
                    string tgridSecurity = "";
                    tg.Build(out tgridSecurity);
                    CStruct xCostTypes = new CStruct();
                    xCostTypes.Initialize("costtype");
                    xCostTypes.CreateIntAttr("CT_ID", nCTId);
                    xCostTypes.CreateString("tgridSecurity", tgridSecurity);
                    sReply = xCostTypes.XML();
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.GetSecurityInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string UpdateSecurityInfo(HttpContext Context, CStruct xData)
        {
            int nCTID = xData.GetIntAttr("CT_ID");
            string stgridSecurity = xData.GetString("tgridSecurity");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    // pick up lines from CFs grid - a flat list
                    CStruct xSGs = new CStruct();
                    xSGs.Initialize("SGs");

                    if (stgridSecurity.Length > 0)
                    {
                        CStruct xGrid = new CStruct();
                        xGrid.LoadXML(stgridSecurity);
                        CStruct xBody = xGrid.GetSubStruct("Body");
                        CStruct xB = xBody.GetSubStruct("B");
                        List<CStruct> listIParent = xB.GetList("I");

                        foreach (CStruct xI in listIParent)
                        {
                            int nGroupId = xI.GetIntAttr("GROUP_ID");
                            int nReadable = xI.GetIntAttr("DS_READ");
                            int nEditable = xI.GetIntAttr("DS_EDIT");
                            if (nEditable > 0 || nReadable > 0)
                            {
                                CStruct xSG = xSGs.CreateSubStruct("SG");
                                xSG.CreateIntAttr("ID", nGroupId);
                                xSG.CreateIntAttr("Readable", nReadable);
                                xSG.CreateIntAttr("Editable", nEditable);
                            }
                        }
                    }
                    if (dbaCostTypes.UpdateCostTypeSecurityInfo(dba, nCTID, xSGs, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo2", dba.StatusText);
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.UpdateSecurityInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string UpdateCostTypeInfo(HttpContext Context, CStruct xData)
        {
            int nCTID = xData.GetIntAttr("CT_ID");
            string sName = xData.GetStringAttr("CT_NAME");
            int nNamedRates = xData.GetIntAttr("CT_NAMEDRATES");
            int nInitialLevel = xData.GetIntAttr("CT_INITIAL_LEVEL");
            int nInputCalendar = xData.GetIntAttr("CT_CB_ID");
            int nEditMode = xData.GetIntAttr("CT_EDIT_MODE");
            string stgridCFData = xData.GetString("tgridCFData");
            string stgridData = xData.GetString("tgridData");
            string sFormula = xData.GetStringAttr("formula");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    CStruct xAvailCCs = new CStruct();
                    xAvailCCs.Initialize("AvailCCs");
                    CStruct xCalcs = new CStruct();
                    xCalcs.Initialize("Calcs");

                    List<CStruct> listIParent = new List<CStruct>();

                    // pick up lines from Available CCs or Calcs in bottom grid
                    if (stgridData.Length > 0)
                    {
                        CStruct xGrid = new CStruct();
                        xGrid.LoadXML(stgridData);
                        CStruct xBody = xGrid.GetSubStruct("Body");
                        CStruct xB = xBody.GetSubStruct("B");
                        listIParent = xB.GetList("I");

                        if (nEditMode == (int)CTEditMode.ctCalculated || nEditMode == (int)CTEditMode.ctCalculatedCumulative)
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
                            List<int> availCCs = new List<int>();
                            // the result of this call is to go through the cc structure and get all ccs which are selected into the availCCs List
                            GetCCs(listIParent, availCCs);

                            foreach (int nItem in availCCs)
                            {
                                CStruct xAvailCC = xAvailCCs.CreateSubStruct("AvailCC");
                                xAvailCC.CreateIntAttr("BC_UID", nItem);
                            }
                        }
                    }

                    // pick up lines from CFs grid - a flat list
                    CStruct xCFs = new CStruct();
                    xCFs.Initialize("CFs");

                    if (stgridCFData.Length > 0)
                    {
                        CStruct xGrid = new CStruct();
                        xGrid.LoadXML(stgridCFData);
                        CStruct xBody = xGrid.GetSubStruct("Body");
                        CStruct xB = xBody.GetSubStruct("B");
                        listIParent = xB.GetList("I");

                        foreach (CStruct xI in listIParent)
                        {
                            int nFieldId = xI.GetIntAttr("FA_FIELD_ID");
                            int nEditable = xI.GetIntAttr("CF_EDITABLE");
                            int nVisible = xI.GetIntAttr("CF_VISIBLE");
                            int nFrozen = xI.GetIntAttr("CF_FROZEN");
                            int nIdentity = xI.GetIntAttr("CF_IDENTITY");
                            int nRequired = xI.GetIntAttr("CF_REQUIRED");
                            if (nEditable > 0 || nVisible > 0 || nFrozen > 0 || nIdentity > 0 || nRequired > 0)
                            {
                                CStruct xCalc = xCFs.CreateSubStruct("CF");
                                xCalc.CreateIntAttr("ID", nFieldId);
                                xCalc.CreateIntAttr("Editable", nEditable);
                                xCalc.CreateIntAttr("Visible", nVisible);
                                xCalc.CreateIntAttr("Frozen", nFrozen);
                                xCalc.CreateIntAttr("Identity", nIdentity);
                                xCalc.CreateIntAttr("Required", nRequired);
                            }
                        }
                    }

                    if (dbaCostTypes.UpdateCostTypeInfo(dba, ref nCTID, sName, nEditMode, nInitialLevel, nInputCalendar, nNamedRates, xAvailCCs, xCFs, sFormula, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo2", dba.StatusText);
                    }
                    else
                    {
                        //  needed to update list after SAVE
                        CStruct xCosttype = new CStruct();
                        xCosttype.Initialize("costtype");
                        xCosttype.CreateIntAttr("CT_ID", nCTID);
                        xCosttype.CreateStringAttr("CT_NAME", sName);
                        sReply = xCosttype.XML();
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.UpdateCostTypesInfo3", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string DeleteCostType(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nCTId = xData.GetIntAttr("CT_ID");
                try
                {
                    dbaCostTypes.DeleteCostType(dba, nCTId, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.DeleteCostType", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string GetPostOptionsInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            int nCTId = Int32.Parse(xData.InnerText);
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    CStruct xPostOptions = new CStruct();
                    xPostOptions.Initialize("postOptions");
                    CStruct xCalendars = xPostOptions.CreateSubStruct("calendars");
                    DataTable dt;
                    dbaCostTypes.SelectCostTypePostOptions(dba, nCTId, out dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        int calendarId = DBAccess.ReadIntValue(row["CB_ID"]);
                        //if (editmode != 1 || calendarId != ctCalendarId)
                        {
                            CStruct xItem = xCalendars.CreateSubStruct("item");
                            xItem.CreateIntAttr("id", calendarId);
                            xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CB_NAME"], ""));
                            xItem.CreateIntAttr("used", DBAccess.ReadIntValue(row["used"]));
                        }
                    }

                    xPostOptions.CreateBooleanAttr("autoPostOnRateChange", dbaCostTypes.IsAutoPostEnabledOnRatePerProjectChange(dba, nCTId));
                    sReply = xPostOptions.XML();

                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.GetPostOptionsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string UpdatePostOptionsInfo(HttpContext Context, CStruct xData)
        {
            int nCTID = xData.GetIntAttr("CT_ID");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    // pick up comma separated list of calendars 
                    string sCalendars = xData.GetStringAttr("calendars");
                    var autoPostOnRateChange = xData.GetBooleanAttr("autoPostOnRateChange", false);

                    if (dbaCostTypes.UpdatePostOptionsInfo(dba, nCTID, sCalendars, autoPostOnRateChange, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostTypes.UpdatePostOptionsInfo", dba.StatusText);
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypes.UpdatePostOptionsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static bool GetCCs(List<CStruct> listItems, List<int> availCCs)
        {
            foreach (CStruct xI in listItems)
            {
                int nId = xI.GetIntAttr("BC_UID");
                int bChecked = xI.GetIntAttr("BC_UID_incl");
                if (bChecked > 0) { availCCs.Add(nId); }
                List<CStruct> listIParent = new List<CStruct>();
                listIParent = xI.GetList("I");
                if (listIParent.Count > 0) { GetCCs(listIParent, availCCs); }
            }
            return true;
        }

        private static string ReadCalendarsForCostType(DBAccess dba, int nCTId)
        {
            return PostCostValuesHandler.ReadCalendarsForCostType(dba, nCTId);
        }

        private static string PostCostValues(DBAccess dba, CStruct xData, string basePath)
        {
            return PostCostValuesHandler.PostCostValues(dba, xData, basePath);
        }

        #endregion
    }

}