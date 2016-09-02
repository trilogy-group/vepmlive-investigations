using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
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
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "GetCostTypesInfo":
                        {
                            int nCTId = Int32.Parse(xData.InnerText);
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                DataTable dt;
                                int nSelectedCalendar = -1;
                                if (dbaCostTypes.SelectCostType(dba, nCTId, out dt) != StatusEnum.rsSuccess)
                                {
                                    sReply = WebAdmin.FormatError("exception", "CostTypes.GetCostTypesInfo", dba.StatusText);
                                }
                                else
                                {
                                    CStruct xCostTypes = new CStruct();
                                    xCostTypes.Initialize("costtype");
                                    int nEditMode = (int)CTEditMode.ctBudget;
                                    if (dt.Rows.Count == 1)
                                    {
                                        DataRow row = dt.Rows[0];
                                        xCostTypes.CreateIntAttr("CT_ID", DBAccess.ReadIntValue(row["CT_ID"]));
                                        xCostTypes.CreateStringAttr("CT_NAME", DBAccess.ReadStringValue(row["CT_NAME"]));
                                        nEditMode = DBAccess.ReadIntValue(row["CT_EDIT_MODE"]);
                                        xCostTypes.CreateIntAttr("CT_EDIT_MODE", nEditMode);
                                        nSelectedCalendar = DBAccess.ReadIntValue(row["CT_CB_ID"]);
                                        xCostTypes.CreateIntAttr("CT_CB_ID", nSelectedCalendar);
                                        xCostTypes.CreateIntAttr("CT_INITIAL_LEVEL", DBAccess.ReadIntValue(row["INITIAL_LEVEL"]));
                                        xCostTypes.CreateIntAttr("CT_NAMEDRATES", DBAccess.ReadIntValue(row["CT_ALLOW_NAMED_RATES"]));
                                    }
                                    else
                                    {
                                        xCostTypes.CreateIntAttr("CT_ID", 0);
                                        xCostTypes.CreateStringAttr("CT_NAME", "New Cost Type");
                                        xCostTypes.CreateIntAttr("CT_EDIT_MODE", nEditMode);
                                        xCostTypes.CreateIntAttr("CT_CB_ID", -1);
                                        xCostTypes.CreateIntAttr("CT_INITIAL_LEVEL", 1);
                                        xCostTypes.CreateIntAttr("CT_NAMEDRATES", 0);
                                    }

                                    CStruct xCalendars = xCostTypes.CreateSubStruct("calendars");
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

                                    {
                                        dbaCostTypes.SelectInitializedCostTypeCustomFields(dba, nCTId, out dt);
                                        _TGrid tg = new _TGrid();
                                        InitializeCustomFieldColumns(tg);
                                        tg.SetDataTable(dt);
                                        string tgridData = "";
                                        tg.Build(out tgridData);
                                        xCostTypes.CreateString("tgridCFData", tgridData);
                                    }

                                    dbaCostTypes.SelectCostTypesForCalc(dba, nCTId, out dt);
                                    CStruct xFields = xCostTypes.CreateSubStruct("fields");
                                    foreach (DataRow row2 in dt.Rows)
                                    {
                                        CStruct xField = xFields.CreateSubStruct("field");
                                        xField.CreateInt("CT_ID", DBAccess.ReadIntValue(row2["CT_ID"]));
                                        xField.CreateString("CT_NAME", DBAccess.ReadStringValue(row2["CT_NAME"], ""));
                                    }

                                    if (nEditMode == (int)CTEditMode.ctCalculated || nEditMode == (int)CTEditMode.ctCalculatedCumulative)
                                    {
                                        //  why is this here?  maybe it is needed to ensure TGrid initializes correctly even when not used? Maybe can switch to it w/o going back to server?
                                        dbaUsers.SelectAvailCCs(dba, nCTId, out dt);
                                        _TGrid tg = new _TGrid();
                                        InitializeCostCategoryColumns(tg);
                                        tg.SetDataTable(dt);
                                        string tgridData = "";
                                        tg.Build(out tgridData);
                                        xCostTypes.CreateString("tgridData", tgridData);

                                        string sFormula = "";
                                        dbaCostTypes.SelectCostTypeFormula(dba, nCTId, out dt);
                                        bool bFirst = true;
                                        foreach (DataRow row2 in dt.Rows)
                                        {
                                            string sComponent = DBAccess.ReadStringValue(row2["CT_NAME"], "");
                                            int nOp = DBAccess.ReadIntValue(row2["CL_OP"]);

                                            if (bFirst == false)
                                            {
                                                switch (nOp)
                                                {
                                                    case 0:
                                                        sFormula += " + ";
                                                        break;
                                                    case 1:
                                                        sFormula += " - ";
                                                        break;
                                                }
                                            }
                                            sFormula += sComponent;

                                            bFirst = false;

                                        }
                                        xCostTypes.CreateString("formula", sFormula);
                                    }
                                    else
                                    {
                                        dbaUsers.SelectAvailCCs(dba, nCTId, out dt);
                                        _TGrid tg = new _TGrid();
                                        InitializeCostCategoryColumns(tg);
                                        tg.SetDataTable(dt);
                                        string tgridData = "";
                                        tg.Build(out tgridData);
                                        xCostTypes.CreateString("tgridData", tgridData);
                                    }
                                    dba.Close();
                                    sReply = xCostTypes.XML();
                                }
                            }
                            break;
                        }
                    case "GetCostTotalsInfo":
                        {
                            sReply = GetCostTotalsInfo(Context, xData);
                            break;
                        }
                    case "UpdateCostTotalsInfo":
                        {
                            sReply = UpdateCostTotalsInfo(Context, xData);
                            break;
                        }
                    case "GetSecurityInfo":
                        {
                            sReply = GetSecurityInfo(Context, xData);
                            break;
                        }
                    case "GetPostOptionsInfo":
                        {
                            sReply = GetPostOptionsInfo(Context, xData);
                            break;
                        }
                    case "UpdateSecurityInfo":
                        {
                            sReply = UpdateSecurityInfo(Context, xData);
                            break;
                        }
                    case "UpdatePostOptionsInfo":
                        {
                            sReply = UpdatePostOptionsInfo(Context, xData);
                            break;
                        }
                    case "UpdateCosttypeInfo":
                        {
                            sReply = UpdateCostTypeInfo(Context, xData);
                            break;
                        }
                    case "DeleteCostType":
                        {
                            sReply = DeleteCostType(Context, xData);
                            break;
                        }
                    case "ValidateFormula":
                        {
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                int nCTId2 = xData.GetIntAttr("CT_ID");
                                string sFormula = xData.GetStringAttr("formula");
                                sReply = dbaCostTypes.ValidateAndSaveCostTypeFormula(dba, nCTId2, ref sFormula, false);
                            }
                            dba.Close();
                            break;
                        }
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
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "CostTypes.CostTypesRequest", ex.Message);
            }

            return sReply;
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

                    if (dbaCostTypes.UpdatePostOptionsInfo(dba, nCTID, sCalendars, out sReply) != StatusEnum.rsSuccess)
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

            int lMethod = 0;
            if (lMethod == 0)
            {
                // add job to Queue for immediate execution
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
            }
            else if (lMethod == 1)
            {
                // execute synchronously - NAX Version
                CStruct xRequest = new CStruct();
                xRequest.Initialize("Data");
                CStruct xCB = xRequest.CreateSubStruct("CB");
                xCB.CreateIntAttr("Id", nCBId);
                CStruct xCT = xRequest.CreateSubStruct("CT");
                xCT.CreateIntAttr("Id", nCTId);

                string sResult = "";
                string sPostInstruction = "";
                bool bUpdateOK = true;

                bUpdateOK = dbaCostValues.PostCostValues(dba, xRequest.XML(), out sResult, out sPostInstruction);

                //Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                //bUpdateOK = adminCore.PostCostValues(xDataInputElement.XML(), out sResult, out sPostInstruction);

                //if (!AdminFunctions.CalcCategoryRates(dba, out sReply))
                //{
                //    sReply = DBAccess.FormatAdminError("error", "Post Cost Values.Post", sReply);
                //    dba.Status = StatusEnum.rsRequestCannotBeCompleted;
                //}
                //else
                //{
                //    //CStruct xCalendar = new CStruct();
                //    //xCalendar.Initialize("calendar");
                //    //xCalendar.CreateIntAttr("calendarid", nCalendarId);
                //    //xCalendar.CreateStringAttr("name", sCalendarName);
                //    //sReply = xCalendar.XML();
                //}
            }
            else if (lMethod == 2)
            {
                // add job to Queue for immediate execution - NAX version
                CStruct xQueue = new CStruct();
                xQueue.Initialize("Queue");
                xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcPostCostValues);
                xQueue.CreateString("Context", "Post Cost Values");
                xQueue.CreateString("Comment", "from Admin Page");

                CStruct xRequest = new CStruct();
                xRequest.Initialize("Data");
                CStruct xCB = xRequest.CreateSubStruct("CB");
                xCB.CreateIntAttr("Id", nCBId);
                CStruct xCT = xRequest.CreateSubStruct("CT");
                xCT.CreateIntAttr("Id", nCTId);

                xQueue.CreateString("Data", xRequest.XML());
                AdminFunctions.SubmitJobRequest(dba, dba.UserWResID, xQueue.XML());

            }

            return sReply;
        }

        #endregion
    }

}