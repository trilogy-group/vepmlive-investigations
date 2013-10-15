using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class Lookups : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.Lookups";
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

        private static void InitializeLookupColumns(_TGrid tg)
        {
            tg.AddColumn(title: "ID", width: 50, name: "LV_UID", isId: true, hidden: true);
            tg.AddColumn(title: "Name", width: 180, name: "LV_VALUE", maincol: true, editable: true);
            tg.AddColumn(title: "Inactive", width: 60, name: "LV_INACTIVE", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Level", width: 60, name: "LV_LEVEL", mainlevelcol: true, hidden: true);
        }

        public static string LookupsRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadLookupInfo":
                    {
                        int nLookupId = Int32.Parse(xData.InnerText);
                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        DataAccess da = new DataAccess(sBaseInfo);
                        DBAccess dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            DataTable dt;
                            if (dbaLookups.SelectLookup(dba, nLookupId, out dt) != StatusEnum.rsSuccess)
                            {
                                sReply = WebAdmin.FormatError("exception", "Lookups.ReadLookupInfo", dba.StatusText);
                            }
                            else
                            {
                                CStruct xLookup = new CStruct();
                                xLookup.Initialize("Lookup");

                                if (dt.Rows.Count == 1)
                                {
                                    DataRow row = dt.Rows[0];
                                    xLookup.CreateIntAttr("LOOKUP_UID", DBAccess.ReadIntValue(row["LOOKUP_UID"]));
                                    xLookup.CreateStringAttr("LOOKUP_NAME", DBAccess.ReadStringValue(row["LOOKUP_NAME"]));
                                    xLookup.CreateStringAttr("LOOKUP_DESC", DBAccess.ReadStringValue(row["LOOKUP_DESC"]));
                                }
                                else
                                {
                                    xLookup.CreateIntAttr("LOOKUP_UID", 0);
                                    xLookup.CreateStringAttr("LOOKUP_NAME", "New Lookup");
                                    xLookup.CreateStringAttr("LOOKUP_DESC", "");
                                }

                                {
                                    if (dbaLookups.SelectLookupValues(dba, nLookupId, out dt) != StatusEnum.rsSuccess)
                                    {
                                        sReply = WebAdmin.FormatError("exception", "Lookups.ReadLookupInfo", dba.StatusText);
                                    }
                                    else
                                    {
                                        _TGrid tg = new _TGrid();
                                        tg.DragAndDrop = true;
                                        InitializeLookupColumns(tg);
                                        tg.SetDataTable(dt);
                                        string tgridData = "";
                                        tg.Build(out tgridData);
                                        xLookup.CreateString("tgridLVData", tgridData);
                                    }
                                }

                                dba.Close();
                                sReply = xLookup.XML();
                                }
                            }
                        }
                        break;
                    case "UpdateLookupInfo":
                    {
                        sReply = UpdateLookupInfo(Context, xData);
                        break;
                    }
                    case "DeleteLookupInfo":
                    {
                        sReply = DeleteLookupInfo(Context, xData);
                        break;
                    }
                    case "CanDeleteLookupRows":
                    {
                        sReply = CanDeleteLookupRows(Context, xData);
                        break;
                    }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "Lookups.LookupsRequest", ex.Message);
            }

            return sReply;
        }
        private static string UpdateLookupInfo(HttpContext Context, CStruct xData)
        {
            int nLOOKUP_UID = xData.GetIntAttr("LOOKUP_UID");
            string sLOOKUP_NAME = xData.GetStringAttr("LOOKUP_NAME");
            string sLOOKUP_DESC = xData.GetStringAttr("LOOKUP_DESC");
            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    _TGrid tg = new _TGrid();
                    InitializeLookupColumns(tg);
                    string stgridLV = xData.InnerText;
                    DataTable dt = tg.SetXmlData(stgridLV);
                    
                    if (dbaLookups.UpdateLookupInfo(dba, ref nLOOKUP_UID, sLOOKUP_NAME, sLOOKUP_DESC, dt, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "Lookups.UpdateLookupsInfo2", dba.StatusText);
                    }
                    else
                    {
                    //  needed to update list after SAVE
                    CStruct xLookups = new CStruct();
                    xLookups.Initialize("Lookup");
                    xLookups.CreateIntAttr("LOOKUP_UID", nLOOKUP_UID);
                    xLookups.CreateStringAttr("LOOKUP_NAME", sLOOKUP_NAME);
                    xLookups.CreateStringAttr("LOOKUP_DESC", sLOOKUP_DESC);
                    sReply = xLookups.XML();
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Lookups.UpdateLookupsInfo3", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string DeleteLookupInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nLOOKUP_UID = xData.GetIntAttr("LOOKUP_UID");
                try
                {
                    dbaLookups.DeleteLookup(dba, nLOOKUP_UID, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Lookups.DeleteLookupInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string CanDeleteLookupRows(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sLVUIDs = xData.InnerText;
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    dbaLookups.CanDeleteLookupItems(dba, sLVUIDs, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostCategories.DeleteCostCategoryInfo", ex.Message);
                }
                dba.Close();
            }

            return sReply;
        }
        #endregion
    }
}
