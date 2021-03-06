﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Security.Principal;
using ResourceValues;
using Microsoft.SharePoint;
using System.Reflection;
using System.Globalization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using PortfolioEngineCore;


namespace WorkEnginePPM
{
    /// <summary>
    /// Summary description for EditCosts
    /// </summary>
    [WebService(Namespace = "WorkEnginePPM")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]

    public class EditCalendar : System.Web.Services.WebService
    {
        private const int MaxHeight = 300;
        private const int LeftWidth = 500;
        private const string CharIds = "0123456789";

        private string GetSPSessionBasePath()
        {
            //using (SPWeb web = SPContext.Current.Web)
            SPWeb web = SPContext.Current.Web;
            {
                return ConfigFunctions.getConfigSetting(web, "EPKBasepath");
            }
        }


        [WebMethod(EnableSession = true)]
        public string Execute(string Function, string Dataxml)
        {
            string sStage;

            if (WebAdmin.AuthenticateUserAndProduct(this.Context, out sStage) == true)
            {
                try
                {
                    Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                    Type thisClass = assemblyInstance.GetType("WorkEnginePPM.EditCalendar", true, true);
                    MethodInfo m = thisClass.GetMethod(Function);
                    object result = m.Invoke(null, new object[] { this.Context, Dataxml });

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    return HandleError("Execute", 99999, string.Format("Error executing function: {0}", ex.Message));
                }
            }
            else
                return HandleError("Execute", 99999, string.Format("PfE User Authentication Failed. Stage: {0}", sStage));
        }

        [WebMethod(EnableSession = true)]
        public string ExecuteJSON(string Function, string Dataxml)
        {
            string sReply = "";
            //string ids = "";
            try
            {
                sReply = Execute(Function, Dataxml);
            }
            catch (Exception ex)
            {
                sReply = HandleError("ExecuteJSON", 99999, string.Format("Error executing function: {0}", ex.Message));
            }

            return CStruct.ConvertXMLToJSON(sReply);
        }


        public static string GetCalendarInfo(HttpContext Context, string sXML)
        {
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            PortfolioEngineCore.Calendars cal = new PortfolioEngineCore.Calendars(sBaseInfo);
            try
            {
                string sCalInfoXML = "";
                if (cal.ReadCalendarListXML(out sCalInfoXML) == false)
                {
                    sReply = HandleError("GetCalendarInfo", cal.Status, cal.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("GetCalendarInfo", 0);
                    xResult.AppendXML(sCalInfoXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetCalendarInfo", 99999, ex);
            }
            return sReply;
        }

        public static string GetCalendarDetailsInfo(HttpContext Context, string sXML)
        {
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            PortfolioEngineCore.Calendars cal = new PortfolioEngineCore.Calendars(sBaseInfo);
            try
            {
                string sCalInfoXML = "";
                if (cal.ReadCalendarDataXML(int.Parse(sXML), out sCalInfoXML) == false)
                {
                    sReply = HandleError("GetCalendarDetailsInfo", cal.Status, cal.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("GetCalendarDetailsInfo", 0);
                    xResult.AppendXML(sCalInfoXML);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetCalendarDetailsInfo", 99999, ex);
            }
            return sReply;
        }

        public static string DeleteCalendar(HttpContext Context, string sXML)
        {
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            PortfolioEngineCore.Calendars cal = new PortfolioEngineCore.Calendars(sBaseInfo);
            try
            {
                if (cal.DeleteCalendar(int.Parse(sXML)) == false)
                {
                    sReply = HandleError("DeleteCalendar", cal.Status, cal.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("DeleteCalendar", 0);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("DeleteCalendar", 99999, ex);
            }
            return sReply;
        }

        public static string CreateNewCalendar(HttpContext Context, string sXML)
        {
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            PortfolioEngineCore.Calendars cal = new PortfolioEngineCore.Calendars(sBaseInfo);
            try
            {
                CStruct xData = new CStruct();
                xData.LoadXML(sXML);

                string calName = xData.GetStringAttr("CalName");
                string calDesc = xData.GetStringAttr("CalDesc");
                int calID = cal.AddCalendar(calName,calDesc);


                if (calID == 0)
                {
                    sReply = HandleError("CreateNewCalendar", cal.Status, cal.FormatErrorText());
                }
                else
                {
                    CStruct xResult = BuildResultXML("Calendars", 0);
                    xResult.CreateIntAttr("NewCalendarID", calID);
                    sReply = xResult.XML();
                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("GetCalendarInfo", 99999, ex);
            }

            return sReply;

        }
 
        public static string GetCalendarPeriodsGrid(HttpContext Context, string sXML)
        {

            CStruct xC = null;

            var xGrid = CreateCalendarGrid();

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xHeader1 = xGrid.CreateSubStruct("Header");

            xHeader1.CreateIntAttr("Spanned", -1);
            xHeader1.CreateIntAttr("SortIcons", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "Period");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xHeader1.CreateStringAttr("Period", "Period");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "PeriodName");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateStringAttr("Width", "100");
            xHeader1.CreateStringAttr("PeriodName", "Name");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "PeriodStart");
            xC.CreateStringAttr("Type", "Date");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateStringAttr("Width", "120");
            xHeader1.CreateStringAttr("PeriodStart", "Start");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "PeriodFinish");
            xC.CreateStringAttr("Type", "Date");
            xC.CreateBooleanAttr("CanEdit", true);
            xC.CreateStringAttr("Width", "120");
            xHeader1.CreateStringAttr("PeriodFinish", "Finish");

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "PeriodBlank");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xHeader1.CreateStringAttr("PeriodBlank", " ");

            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");


            xI.CreateStringAttr("id", "0");

            return xGrid.XML();
        }

        public static string GetCalendarFTESGrid(HttpContext Context, string sXML)
        {

            CStruct xC = null;

            var xGrid = CreateCalendarGrid();

            CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xHeader1 = xGrid.CreateSubStruct("Header");

            xHeader1.CreateIntAttr("Spanned", -1);
            xHeader1.CreateIntAttr("SortIcons", 0);

            xC = xLeftCols.CreateSubStruct("C");
            xC.CreateStringAttr("Name", "CostCat");
            xC.CreateStringAttr("Type", "Text");
            xC.CreateBooleanAttr("CanEdit", false);
            xHeader1.CreateStringAttr("CostCat", "Cost Category");
            xC.CreateStringAttr("Width", "120");
 
  
            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct xI = xBody.CreateSubStruct("I");


            xI.CreateStringAttr("id", "0");

            return xGrid.XML();
        }

        public static string SetCalendarData(HttpContext Context, string sXML)
        {

            CStruct xData = new CStruct();
            xData.LoadXML(sXML);
            string sReply = ""; ;

            int calid = xData.GetIntAttr("ID");

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            PortfolioEngineCore.Calendars cal = new PortfolioEngineCore.Calendars(sBaseInfo);
            try
            {
                if (cal.SaveCalendarPeriods(calid, sXML) == false)
                {
                    sReply = HandleError("SetCalendarDataPeriods", cal.Status, cal.FormatErrorText());
                    return "";

                }
                if (cal.SaveCalendarRatesFTES(calid, sXML) == false)
                {
                    sReply = HandleError("SetCalendarDataFTES", cal.Status, cal.FormatErrorText());
                    return "";

                }
            }
            catch (Exception ex)
            {
                sReply = HandleException("SetCalendarData", 99999, ex);
            }
            
            return "";
        }
      
       
       

        private static CStruct BuildResultXML(string sContext = "", int nStatus = 0)
        {
            CStruct xResult = new CStruct();
            xResult.Initialize("Result");
            xResult.CreateStringAttr("Context", sContext);
            xResult.CreateIntAttr("Status", nStatus);
            return xResult;
        }

        private static string HandleError(string sContext, int nStatus, string sError)
        {
            CStruct xResult = BuildResultXML(sContext, nStatus);
            CStruct xError = xResult.CreateSubStruct("Error");
            //xError.Value = sError;
            xError.CreateIntAttr("ID", 100);
            xError.CreateStringAttr("Value", sError);
            return xResult.XML();
        }

        private static string HandleException(string sContext, int nStatus, Exception ex)
        {
            return HandleError(sContext, nStatus, "Exception in EditCalendar.asmx : '" + ex.Message.ToString() + "'");
        }

        private static CStruct CreateCalendarGrid()
        {
            var grid = new CStruct();
            grid.Initialize("Grid");

            var toolbar = grid.CreateSubStruct("Toolbar");
            toolbar.CreateIntAttr("Visible", 0);

            var panel = grid.CreateSubStruct("Panel");
            panel.CreateIntAttr("Visible", 1);
            panel.CreateIntAttr("Delete", 0);

            var config = grid.CreateSubStruct("Cfg");

            config.CreateIntAttr("MaxHeight", MaxHeight);

            config.CreateIntAttr("ShowDeleted", 0);
            config.CreateIntAttr("Deleting", 0);
            config.CreateIntAttr("Selecting", 0);
            config.CreateIntAttr("ColResizing", 1);

            config.CreateBooleanAttr("DateStrings", true);
            config.CreateBooleanAttr("NoTreeLines", true);

            config.CreateIntAttr("MaxWidth", 1);
            config.CreateIntAttr("AppendId", 0);
            config.CreateIntAttr("FullId", 0);
            config.CreateStringAttr("IdChars", CharIds);
            config.CreateIntAttr("NumberId", 1);
            config.CreateIntAttr("FilterEmpty", 1);
            config.CreateIntAttr("Dragging", 0);
            config.CreateIntAttr("DragEdit", 0);
            config.CreateIntAttr("ExportFormat", 1);

            config.CreateStringAttr("IdPrefix", "R");
            config.CreateStringAttr("IdPostfix", "x");
            config.CreateIntAttr("CaseSensitiveId", 0);
            config.CreateIntAttr("FilterEmpty", 1);

            config.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            config.CreateStringAttr("Style", "GM");
            config.CreateStringAttr("CSS", "ResPlanAnalyzer");

            config.CreateIntAttr("LeftWidth", LeftWidth);

            config.CreateIntAttr("SuppressCfg", 1);

            config.CreateIntAttr("Sorting", 0);
            return grid;
        }
    }
}

