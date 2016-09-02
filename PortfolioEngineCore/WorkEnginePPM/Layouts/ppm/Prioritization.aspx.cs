using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    //public class ComponentWeight
    //{
    //    public int ScenarioId;
    //    public int ComponentId;
    //    public double Weight;
    //}

    //public class EPKPriFormula
    //{
    //    public int uid;
    //    public string name;
    //    public List<ComponentWeight> components;

    //    public EPKPriFormula()
    //    {
    //        components = new List<ComponentWeight>();
    //    }
    //}

    public partial class Prioritization : LayoutsPageBase
    {
        //private void EnsureScriptManager()
        //{
        //    ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        //    if (scriptManager == null)
        //    {
        //        scriptManager = new ScriptManager();
        //        scriptManager.EnablePageMethods = true;
        //        if (Page.Form != null)
        //        {
        //            Page.Form.Controls.AddAt(0, scriptManager);
        //        }
        //    }
        //    scriptManager.EnablePageMethods = true;
        //}

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    EnsureScriptManager();
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            DBAccess dba = null;
            if (!IsPostBack)
            {
                buttonbar1.EventHandler("buttonbar1_event");
                buttonbar1.AddButton("btnSave", "<u>S</u>ave", "", "images/save.gif", "alt text", "7em", "s", true);
                buttonbar1.Render();

                //string basePath = WebAdmin.GetBasePath();
                ////hiddenData.Value = basePath;
                //string sDBConnect = WebAdmin.GetConnectionString(basePath);
                //dba = new DBAccess(sDBConnect);
                //if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                DataAccess da = new DataAccess(sBaseInfo);
                dba = da.dba;
                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;
                DataTable dt;

                Dictionary<int, string> Fields = new Dictionary<int, string>();
                //ListItem liField;
                if (dbaPrioritz.SelectFields(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;
                foreach (DataRow row in dt.Rows)
                {
                    int nFieldID = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                    string sField = DBAccess.ReadStringValue(row["FA_NAME"]);
                    Fields.Add(nFieldID, sField);
                }

                string sFieldName;
                if (dbaPrioritz.SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                lstComponents.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                    if (Fields.TryGetValue(lFieldID, out sFieldName))
                    {
                        ListItem listItem = new ListItem();
                        listItem.Value = lFieldID.ToString();
                        listItem.Text = sFieldName;
                        lstComponents.Items.Add(listItem);
                    }
                }

                if (dbaPrioritz.SelectFormulas(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                lstFormulas.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int lFieldID = DBAccess.ReadIntValue(row["CW_RESULT"]);
                    if (Fields.TryGetValue(lFieldID, out sFieldName))
                    {
                        ListItem listItem = new ListItem();
                        listItem.Value = lFieldID.ToString();
                        listItem.Text = sFieldName;
                        lstFormulas.Items.Add(listItem);
                    }
                }

                DataTable dt_Weights;
                if (dbaPrioritz.SelectWeights(dba, out dt_Weights) != StatusEnum.rsSuccess) goto Status_Error;
                CStruct xGridLayout = BuildGridLayout(lstComponents.Items);
                idGridLayout.Value = xGridLayout.ToString(true);
                CStruct xGridData = BuildGridData(dt, dt_Weights);
                idGridData.Value = xGridData.ToString(true);
                dba.Close();
            }

            return;
        Status_Error:
            if (dba != null)
            {
                dba.Close();
                lblGeneralError.Text = dba.FormatErrorText();
                lblGeneralError.Visible = true;
            }
        }

        private CStruct BuildGridLayout(ListItemCollection Components)
        {
            CStruct xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Delete", 0);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 3);
            xCfg.CreateIntAttr("InEditMode", 0);
            xCfg.CreateIntAttr("Sorting", 0);
            xCfg.CreateIntAttr("Selecting", 0);
            xCfg.CreateIntAttr("Dragging", 0);
            xCfg.CreateIntAttr("Dropping", 0);
            xCfg.CreateIntAttr("ColsMoving", 0);
            xCfg.CreateIntAttr("ColsPostLap", 0);
            xCfg.CreateIntAttr("ColsLap", 0);
            xCfg.CreateBooleanAttr("NoTreeLines", true);
            xCfg.CreateIntAttr("MaxHeight", 0);
            xCfg.CreateBooleanAttr("ShowDeleted", true);
            xCfg.CreateBooleanAttr("DateStrings", true);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            xCfg.CreateIntAttr("NumberId", 1);
            xCfg.CreateIntAttr("LastId", 1);
            xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "RPEditor");

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            CStruct xHeader = xGrid.CreateSubStruct("Header");
            xHeader.CreateIntAttr("Visible", 1);
            xHeader.CreateIntAttr("SortIcons", 0);

            // Add FieldID column
            CStruct xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "FieldID");
            xC.CreateStringAttr("Type", "Int");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateBooleanAttr("Visible", false);
            
            // Add formula column
            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Scenario");
            xHeader.CreateStringAttr("Scenario", " Scenario");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xC.CreateIntAttr("MinWidth", 60);

            foreach (ListItem li in Components)
            {
                xC = xCols.CreateSubStruct("C");
                xC.CreateStringAttr("Name", "C_" + li.Value);
                xHeader.CreateStringAttr("C_" + li.Value, li.Text);
                xC.CreateStringAttr("Type", "Float");
                xC.CreateStringAttr("Format", "0.###");
                xC.CreateBooleanAttr("CanEdit", true);
                xC.CreateIntAttr("MinWidth", 45);
            }

            return xGrid;
        }

        private CStruct BuildGridData(DataTable dt, DataTable dt_Weights)
        {
            CStruct xGrid = new CStruct();
            xGrid.Initialize("Grid");
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xIParent = xB;

            List<ComponentWeight> Weights = new List<ComponentWeight>();
            if (dt_Weights != null)
            {
                foreach (DataRow row in dt_Weights.Rows)
                {
                    ComponentWeight cw = new ComponentWeight();
                    cw.ScenarioId = DBAccess.ReadIntValue(row["CW_RESULT"]);
                    cw.ComponentId = DBAccess.ReadIntValue(row["CW_COMPONENT"]);
                    cw.Weight = DBAccess.ReadDoubleValue(row["CW_RATIO"]);
                    Weights.Add(cw);
                }
            }

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    CStruct xI = xIParent.CreateSubStruct("I");
                    int lScenario = DBAccess.ReadIntValue(row["CW_RESULT"]);
                    xI.CreateIntAttr("FieldID", lScenario);
                    xI.CreateStringAttr("Scenario", DBAccess.ReadStringValue(row["FA_NAME"]));
                    xI.CreateStringAttr("Color", "254,254,254");
                    xI.CreateIntAttr("NoColorState", 1);

                    foreach (ComponentWeight cw in Weights)
                    {
                        if (lScenario == cw.ScenarioId) xI.CreateDoubleAttr("C_" + cw.ComponentId, cw.Weight);
                    }

                    xI.CreateBooleanAttr("CanEdit", true);
                }
            }
            return xGrid;
        }

    //    [System.Web.Services.WebMethod]
    //    public static string SavePageData(string sContextInfo, string sData)
    //    {
    //        return SaveWeightData(sContextInfo, sData);
    //    }

    //    private static string SaveWeightData(string sContextInfo, string sData)
    //    {
    //        string sReply = "";
    //        try
    //        {
    //            CStruct xGrid = new CStruct();
    //            if (xGrid.FromString(sData, true) == false)
    //            {
    //                sReply = "SaveWeightData : Unable to load Grid XML";
    //                return sReply;
    //            }
    //            else
    //            {
    //                //WebAdmin.
    //                string sDBConnect = WebAdmin.GetConnectionString(sContextInfo);
    //                DBAccess dba = new DBAccess(sDBConnect);
    //                if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

    //                DataTable dt;
    //                if (dbaPrioritz.SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

    //                List<int> Components = new List<int>();
    //                foreach (DataRow row in dt.Rows)
    //                {
    //                    int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
    //                    Components.Add(lFieldID);
    //                }

    //                CStruct xBody = xGrid.GetSubStruct("Body");
    //                CStruct xB = xBody.GetSubStruct("B");
    //                List<CStruct> listI = xB.GetList("I");

    //                List<EPKPriFormula> c_formulas = new List<EPKPriFormula>();
    //                foreach (CStruct xI in listI)
    //                {
    //                    EPKPriFormula formula = new EPKPriFormula();
    //                    formula.name = xI.GetStringAttr("Scenario");
    //                    formula.uid = xI.GetIntAttr("FieldID");

    //                    foreach (int Component in Components)
    //                    {
    //                        ComponentWeight cw = new ComponentWeight();
    //                        cw.ScenarioId = formula.uid;
    //                        cw.ComponentId = Component;
    //                        cw.Weight = xI.GetDoubleAttr("C_" + Component.ToString(), 0);
    //                        formula.components.Add(cw);
    //                    }
    //                    c_formulas.Add(formula);
    //                }

    //                int lRowsAffected;
    //                if (dbaPrioritz.UpdateWeights(dba, c_formulas, out lRowsAffected) != StatusEnum.rsSuccess) goto Exit_Function;

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            sReply = HandleException(ex);
    //        }

    //    Exit_Function:
    //    Status_Error:

    //        return sReply;
    //    }

    //    public static string HandleException(Exception ex)
    //    {
    //        return "Prioritization Exception : " + ex.Message.ToString();
    //    }
    //}

    }
}
