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

    public partial class CostCategories : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.CostCategories";
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

        public static string CostCategoriesRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadMajorCategoryItems":
                        {
                            int nId = Int32.Parse(xData.InnerText);
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                DataTable dt;
                                dbaGeneral.SelectLookup(dba, nId, out dt);
                                CStruct xMajorCategoryItems = new CStruct();
                                xMajorCategoryItems.Initialize("MajorCategoryItems");

                                foreach (DataRow row in dt.Rows)
                                {
                                    CStruct xItem = xMajorCategoryItems.CreateSubStruct("Item");
                                    xItem.CreateIntAttr("id", DBAccess.ReadIntValue(row["LV_UID"]));
                                    xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["LV_FULLVALUE"]));
                                }
                                sReply = xMajorCategoryItems.XML();
                            }
                            dba.Close();
                            break;
                        }
                    case "DeleteCostCategoryInfo":
                        sReply = DeleteCostCategoryInfo(Context, xData);
                        break;
                    case "SaveCostCategoryInfo":
                        sReply = SaveCostCategoryInfo(Context, xData);
                        break;
                    case "ReadCostCategoryRatesInfo":
                        sReply = ReadCostCategoryRatesInfo(Context, xData);
                        break;
                    case "ReadCalendarFTEsInfo":
                        sReply = ReadCalendarFTEsInfo(Context, xData);
                        break;
                    case "SaveCostCategoryRatesInfo":
                        sReply = SaveCostCategoryRatesInfo(Context, xData);
                        break;
                    case "SaveCalendarFTEsInfo":
                        sReply = SaveCalendarFTEsInfo(Context, xData);
                        break;
                    default:
                        sReply = WebAdmin.FormatError("error", "CostCategoriesRequest", "Unknown Request : " + sRequestContext);
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "CostCategories.CustomfieldRequest", ex.Message);
            }

            return sReply;
        }
        //private static void InitializeColumns(_TGrid tg)
        //{
        //    tg.AddColumn(title: "ID", width: 50, name: "RT_UID", isId: true, hidden: true);
        //    tg.AddColumn(title: "Name", width: 180, name: "LV_VALUE", editable: true);
        //    tg.AddColumn(title: "Effective Date", width: 180, name: "LV_VALUE", editable: true);
        //    tg.AddColumn(title: "Rate", width: 180, name: "LV_LEVEL", editable: true);
        //}
        private static string ReadCostCategoryRatesInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    int nId = Int32.Parse(xData.InnerText);
                    DataTable dt;
                    decimal baserate;
                    dbaCostCategories.ReadCostCategoryRates(dba, nId, out baserate, out dt);
                    _TGrid tg = new _TGrid();
                    tg.AddColumn(title: "Effective Date", width: 180, name: "BC_EFFECTIVE_DATE", editable: true, type: _TGrid.Type.date);
                    tg.AddColumn(title: "Rate", width: 180, name: "BC_RATE", editable: true, type: _TGrid.Type.number);
                    tg.SetDataTable(dt);
                    string tgridRates = "";
                    tg.Build(out tgridRates);
                    CStruct xCostCategory = new CStruct();
                    xCostCategory.Initialize("costcategory");
                    xCostCategory.CreateIntAttr("BC_UID", nId);
                    xCostCategory.CreateDecimalAttr("baserate", baserate);
                    xCostCategory.CreateString("tgridRates", tgridRates);
                    sReply = xCostCategory.XML();
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.ReadCostCategoryRatesInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string SaveCostCategoryRatesInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    int nCA_UID = xData.GetIntAttr("CA_UID");
                    decimal baserate = xData.GetDecimalAttr("baserate",0);
                    _TGrid tg = new _TGrid();
                    tg.AddColumn(title: "Effective Date", width: 180, name: "BC_EFFECTIVE_DATE", editable: true, type: _TGrid.Type.date);
                    tg.AddColumn(title: "Rate", width: 180, name: "BC_RATE", editable: true, type: _TGrid.Type.number);

                    string stgridRates = xData.InnerText;
                    DataTable dt = tg.SetXmlData(stgridRates);
                    if (dbaCostCategories.UpdateCostCategoryRates(dba, nCA_UID, baserate, dt, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostCategorys.SaveCostCategoryRatesInfo", dba.StatusText);
                    }
                    else
                    {
                        // recalculate Cost Category Rates - not sure if this should be done by Job Server, right now there isn't an option set up so do it synchronously
                        // this is done now after changing any rate as well as if press save on the main Cost Categories page
                        if (!AdminFunctions.CalcCategoryRates(dba, out sReply))
                        {
                            sReply = DBAccess.FormatAdminError("error", "CostCategories.SaveCostCategoryRatesInfo", sReply);
                        }
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.SaveCostCategoryRatesInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string SaveCostCategoryInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    int nMCLookupId = xData.GetIntAttr("majorcategoryid");
                    int nMCDefaultId = xData.GetIntAttr("majorcategorydefault");

                    _TGrid tg = new _TGrid();
                    tg.AddColumn(title: "ID", width: 50, name: "CA_UID", isId: true, hidden: true);
                    tg.AddColumn(title: "Category", width: 180, name: "CA_NAME", maincol: true, editable: true);
                    tg.AddColumn(title: "UoM", width: 180, name: "CA_UOM", editable: true);
                    tg.AddColumn(title: "Level", width: 180, name: "CA_LEVEL", mainlevelcol: true, hidden: true);
                    tg.AddColumn(title: "Role", width: 180, name: "CA_ROLE", hidden: true);


                    string sTreegridData = xData.InnerText;
                    DataTable dt = tg.SetXmlData(sTreegridData);
                    if (dbaCostCategories.SaveCostCategories(dba, nMCLookupId, nMCDefaultId, dt, out sReply) != StatusEnum.rsSuccess)
                    { }
                    else
                    {
                        CStruct xQueue;
                        // recalculate FTE values IF using default values
                        xQueue = new CStruct();
                        xQueue.Initialize("Queue");
                        xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcCalcDefaultFTEs);
                        xQueue.CreateString("Context", "Edit Periods");
                        xQueue.CreateString("Comment", "Calculate Default FTE values");
                        xQueue.CreateString("Data", "No Context Data");
                        AdminFunctions.SubmitJobRequest(dba, 0, xQueue.XML());

                        // recalculate Cost Category Rates - not sure if this should be done by Job Server, right now there isn't an option set up so do it synchronously
                        if (!AdminFunctions.CalcCategoryRates(dba, out sReply))
                        {
                            sReply = DBAccess.FormatAdminError("error", "CostCategories.SaveCostCategoryInfo", sReply);
                        }
                        else
                        {
                            // If we are  in version >= V43 then need to push updated cost categories to WE
                            
                            // when Job Server moved out of Webservice.asmx.cs Job 200 was dropped as it couldn't work doing it that way
                            //xQueue = new CStruct();
                            //xQueue.Initialize("Queue");
                            //xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcRefreshRoles);
                            //xQueue.CreateString("Context", "CostCategories");
                            //xQueue.CreateString("Comment", "Refresh Roles");
                            //xQueue.CreateString("Data", "No Context Data");
                            //AdminFunctions.SubmitJobRequest(dba, 0, xQueue.XML());

                            // need to run Refresh Roles Synchronously - this is what the Job Server WAS doing for job 200 (qjcRefreshRoles)
                            PortfolioEngineAPI pFeAPI = new PortfolioEngineAPI();
                            pFeAPI.Execute("RefreshRoles", "");
                            pFeAPI.Dispose();

                        }
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.SaveCostCategoryInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string DeleteCostCategoryInfo(HttpContext Context, CStruct xData)
        {
            // this checks if a list of BCUIDs can be deleted, nothing is actually deleted
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                string sUIDs = xData.GetStringAttr("CA_UIDs");
                try
                {
                    dbaCostCategories.CanDeleteCostCategory(dba, sUIDs, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.DeleteCostCategoryInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static void InitializeFTEColumns(DBAccess dba, int nCalendarId, _TGrid tg)
        {
            DataTable dt;
            DataTable dtPeriods;
            dbaCalendars.SelectCalendarPeriods(dba, nCalendarId, out dtPeriods);

            // looks like following stmnt might not be used?
            dbaCalendars.ReadCalendarFTEs(dba, nCalendarId, out dt);

            tg.AddColumn(title: "ID", width: 50, name: "BC_UID", isId: true, hidden: true);
            tg.AddColumn(title: "Category", width: 180, name: "BC_NAME", maincol: true);
            //tg.AddColumn(title: "UoM", width: 180, name: "BC_UOM", editable: true);
            tg.AddColumn(title: "Level", width: 180, name: "BC_LEVEL", mainlevelcol: true, hidden: true);
            tg.AddColumn(title: "Role", width: 180, name: "BC_ROLE", hidden: true);
            foreach (DataRow row in dtPeriods.Rows)
            {
                int periodid = DBAccess.ReadIntValue(row["PRD_ID"]);
                string periodname = DBAccess.ReadStringValue(row["PRD_NAME"]);
                tg.AddColumn(title: periodname, width: 70, name: "P" + periodid.ToString(), editable: true, align: _TGrid.Align.center);
            }
        }
        private static string ReadCalendarFTEsInfo(HttpContext Context, CStruct xData)
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
                    CStruct xCostCategory = new CStruct();
                    xCostCategory.Initialize("FTEs");
                    xCostCategory.CreateIntAttr("CB_ID", nCalendarId);
                    DataTable dt;
                    dbaCalendars.SelectCalendars(dba, out dt);
                    CStruct xCalendars = xCostCategory.CreateSubStruct("calendars");
                    CStruct xItem = xCalendars.CreateSubStruct("item");
                    xItem.CreateIntAttr("id", -1);
                    xItem.CreateStringAttr("name", "--Select a Calendar--");
                    foreach (DataRow row in dt.Rows)
                    {
                        xItem = xCalendars.CreateSubStruct("item");
                        int nCalendar = DBAccess.ReadIntValue(row["CB_ID"]);
                        xItem.CreateIntAttr("id", nCalendar);
                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CB_NAME"]));
                    }
                    
                    _TGrid tg = new _TGrid();
                    InitializeFTEColumns(dba, nCalendarId, tg);
                    dbaCalendars.ReadCalendarFTEs(dba, nCalendarId, out dt);
                    tg.SetDataTable(dt);
                    string tgridFTEs = "";
                    tg.Build(out tgridFTEs);
                    xCostCategory.CreateString("tgridFTEs", tgridFTEs);
                    sReply = xCostCategory.XML();
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.ReadCalendarFTEsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        private static string SaveCalendarFTEsInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    int nCalendarId = xData.GetIntAttr("CB_ID");
                    _TGrid tg = new _TGrid();
                    InitializeFTEColumns(dba, nCalendarId, tg);

                    string stgridFTEs = xData.InnerText;
                    DataTable dt = tg.SetXmlData(stgridFTEs);
                    if (dbaCostCategories.UpdateCostCategoryFTEs(dba, nCalendarId, dt, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostCategories.SaveCalendarFTEsInfo", dba.StatusText);
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.SaveCalendarFTEsInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        #endregion
    }
}
