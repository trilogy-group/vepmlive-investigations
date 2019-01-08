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