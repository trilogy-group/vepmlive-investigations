using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web;
using PortfolioEngineCore;
using WorkEnginePPM.Layouts.ppm;

namespace WorkEnginePPM
{

    public partial class CostTypeCustomFieldsHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.CostTypeCustomFieldsHandler";
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

        public static string CostTypeCustomFieldsRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            var reply = string.Empty;
            try
            {
                reply = CustomFieldHelper.CreateCustomFieldRequest(
                    Context,
                    sRequestContext,
                    xData,
                    ReadCustomFieldInfo,
                    UpdateCustomFieldInfo,
                    DeleteCustomFieldInfo);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                reply = WebAdmin.FormatError("exception", "CostTypeCustomFields.CustomfieldRequest", ex.Message);
            }

            return reply;
        }

        private static void InitializeColumns(_TGrid grid)
        {
            CustomFieldHelper.InitializeColumns(grid);
        }

        private static string ReadLookup(DBAccess dbAccess, int lookupuId)
        {
            return CustomFieldHelper.ReadLookup(dbAccess, lookupuId);
        }

        private static string ReadCustomFieldInfo(DBAccess dba, int nFieldId)
        {
            return CustomFieldHelper.ReadCustomFieldInfo(dba, nFieldId, dbaCostTypes.SelectCostTypeCustomField);
        }

        private static string UpdateCustomFieldInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nFieldId = xData.GetIntAttr("FA_FIELD_ID");
                string sFieldName = xData.GetStringAttr("FA_NAME");
                string sFieldDesc = xData.GetStringAttr("FA_DESC");
                int nLookupID = xData.GetIntAttr("FA_LOOKUP_UID");
                int nLeafOnly = xData.GetIntAttr("FA_LEAFONLY");
                int nUseFullName = xData.GetIntAttr("FA_USEFULLNAME");
                try
                {
                    if (dbaCostTypes.UpdateCostTypeCustomFieldInfo(dba, nFieldId, sFieldName, sFieldDesc,nLookupID,nLeafOnly,nUseFullName, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostTypeCustomFields.UpdateCustomFieldInfo", dba.StatusText);
                    }
                    else
                    {
                        sReply = ReadCustomFieldInfo(dba, nFieldId);
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypeCustomFields.UpdateCustomFieldInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string DeleteCustomFieldInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nFieldId = xData.GetIntAttr("FA_FIELD_ID");
                try
                {
                    if (dbaCostTypes.DeleteCostTypeCustomField(dba, nFieldId, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "CostTypeCustomFields.UpdateCustomFieldInfo", dba.StatusText);
                    }
                    else
                    {
                        sReply = ReadCustomFieldInfo(dba, nFieldId);
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "CostTypeCustomFields.DeleteCustomFieldInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        #endregion
    }
}
