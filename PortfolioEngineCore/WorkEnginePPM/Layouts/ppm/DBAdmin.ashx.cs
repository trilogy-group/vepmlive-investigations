using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using PortfolioEngineCore;
using WorkEnginePPM.ControlTemplates.WorkEnginePPM;

namespace WorkEnginePPM
{

    public partial class DBAdminHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.DBAdminHandler";
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

        public static string DBAdminRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            var reply = string.Empty;
            try
            {
                switch (sRequestContext)
                {
                    case "ClosePI":
                    {
                        HandleClosePiCase(Context, xData, ref reply);
                        break;
                    }
                    case "OpenPI":
                    {
                        HandleOpenPiCase(Context, xData, ref reply);
                        break;
                    }
                    case "CheckInPI":
                    {
                        HandleCheckInPiCase(Context, xData, ref reply);
                        break;
                    }
                    case "DeletePI":
                    {
                        HandleDeletePiCase(Context, xData, ref reply);
                        break;
                    }
                    case "CanDeleteRes":
                    {
                        HandleCanDeleteResCase(Context, xData, ref reply);
                        break;
                    }
                    case "DeleteRes":
                    {
                        HandleDeleteResCase(Context, xData, ref reply);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                reply = WebAdmin.FormatError("exception", "DBAdmin.DBAdminRequest", ex.Message);
            }

            return reply;
        }

        private static void HandleDeleteResCase(HttpContext context, CStruct data, ref string reply)
        {
            var wResId = data.GetIntAttr("WRES_ID");
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        if (wResId == dataAccess.UserId)
                        {
                            reply = "You are logged in as this resource, cannot delete";
                        }
                        else
                        {
                            if (dbaDBAdmin.DeleteResource(dataAccessDba, wResId, out reply) != StatusEnum.rsSuccess && reply.Length == 0)
                            {
                                reply = WebAdmin.FormatError("exception", "DBAdmin.DeleteResource", dataAccessDba.StatusText);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "DBAdmin.DeleteRes", ex.Message);
                    }
                    dataAccessDba.Close();
                }
            }
        }

        private static void HandleCanDeleteResCase(HttpContext context, CStruct data, ref string reply)
        {
            var wResId = data.GetIntAttr("WRES_ID");
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        if (dbaDBAdmin.CanDeleteResource(dataAccessDba, wResId, out reply) == StatusEnum.rsSuccess)
                        {
                            if (reply.Length > 0)
                            {
                                reply = string.Format("This resource cannot be deleted, it is used as follows:\n{0}", reply);
                                reply = WebAdmin.FormatError("error", "CanDeleteResource", reply);
                            }
                            else
                            {
                                if (dbaDBAdmin.CanDeleteResourceWarning(dataAccessDba, wResId, out reply) == StatusEnum.rsSuccess && reply.Length > 0)
                                {
                                    reply = string.Format(
                                        "This resource can be deleted, references will be changed to point to you:\n{0}",
                                        reply);
                                    reply = WebAdmin.FormatWarning(reply);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "DBAdmin.CanDeleteRes", ex.Message);
                    }
                    dataAccessDba.Close();
                }
            }
        }

        private static void HandleDeletePiCase(HttpContext context, CStruct data, ref string reply)
        {
            var projectId = data.GetIntAttr("PROJECT_ID");
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        if (dbaDBAdmin.DeletePI(dataAccessDba, projectId, out reply) != StatusEnum.rsSuccess && reply.Length == 0)
                        {
                            reply = WebAdmin.FormatError("exception", "DBAdmin.DeletePI", dataAccessDba.StatusText);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "DBAdmin.DeletePI", ex.Message);
                    }
                    dataAccessDba.Close();
                }
            }
        }

        private static void HandleCheckInPiCase(HttpContext context, CStruct data, ref string reply)
        {
            var projectId = data.GetIntAttr("PROJECT_ID");
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        if (dbaDBAdmin.CheckInPI(dataAccessDba, projectId, out reply) != StatusEnum.rsSuccess)
                        {
                            if (reply.Length == 0)
                            {
                                reply = WebAdmin.FormatError("exception", "DBAdmin.CheckInPI", dataAccessDba.StatusText);
                            }
                        }
                        else
                        {
                            reply = GetPIXML(dataAccessDba, projectId);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "DBAdmin.CheckInPI", ex.Message);
                    }
                }
            }
        }

        private static void HandleOpenPiCase(HttpContext context, CStruct data, ref string reply)
        {
            var projectId = data.GetIntAttr("PROJECT_ID");
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        if (dbaDBAdmin.OpenPI(dataAccessDba, projectId, out reply) != StatusEnum.rsSuccess)
                        {
                            if (reply.Length == 0)
                            {
                                reply = WebAdmin.FormatError("exception", "DBAdmin.OpenPI", dataAccessDba.StatusText);
                            }
                        }
                        else
                        {
                            reply = GetPIXML(dataAccessDba, projectId);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "DBAdmin.OpenPI", ex.Message);
                    }
                }
            }
        }

        private static void HandleClosePiCase(HttpContext context, CStruct data, ref string reply)
        {
            var projectId = data.GetIntAttr("PROJECT_ID");
            var baseInfo = WebAdmin.BuildBaseInfo(context);
            using (var dataAccess = new DataAccess(baseInfo))
            using (var dataAccessDba = dataAccess.dba)
            {
                if (dataAccessDba.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        if (dbaDBAdmin.ClosePI(dataAccessDba, projectId, out reply) != StatusEnum.rsSuccess)
                        {
                            if (reply.Length == 0)
                            {
                                reply = WebAdmin.FormatError("exception", "DBAdmin.ClosePI", dataAccessDba.StatusText);
                            }
                        }
                        else
                        {
                            reply = GetPIXML(dataAccessDba, projectId);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        reply = WebAdmin.FormatError("exception", "DBAdmin.ClosePI", ex.Message);
                    }
                }
            }
        }

        protected static string GetPIXML(DBAccess dba, int nPROJECT_ID)
        {
            string sXML = "";
            try
            {
                DataTable dt;
                string cmdText = "SELECT PROJECT_ID,PROJECT_NAME,PROJECT_MARKED_DELETION,PROJECT_SECURITY,PROJECT_CREATED,PROJECT_CHECKEDOUT,RES_NAME,PROJECT_CHECKEDOUT_DATE,PROJECT_EXT_UID"
                                + " FROM EPGP_PROJECTS"
                                + " LEFT JOIN EPG_RESOURCES ON PROJECT_CHECKEDOUT_BY = WRES_ID"
                                + " WHERE PROJECT_ID = @p1";
                if (dba.SelectDataById(cmdText, nPROJECT_ID, (StatusEnum)99998, out dt) != StatusEnum.rsSuccess)
                {
                    //lblGeneralError.Text = "SelectData Error : " + dba.Status.ToString() + " - " + dba.StatusText;
                    //lblGeneralError.Visible = true;
                }
                else
                {
                    if (dt.Rows.Count == 1)
                    {
                        DataRow row = dt.Rows[0];
                        CStruct xPI = new CStruct();
                        xPI.Initialize("PI");
                        xPI.CreateIntAttr("PROJECT_ID", DBAccess.ReadIntValue(row["PROJECT_ID"]));
                        xPI.CreateStringAttr("PROJECT_NAME", DBAccess.ReadStringValue(row["PROJECT_NAME"]));
                        xPI.CreateIntAttr("PROJECT_MARKED_DELETION", DBAccess.ReadIntValue(row["PROJECT_MARKED_DELETION"]));
                        xPI.CreateIntAttr("PROJECT_CHECKEDOUT", DBAccess.ReadIntValue(row["PROJECT_CHECKEDOUT"]));
                        xPI.CreateStringAttr("RES_NAME", DBAccess.ReadStringValue(row["RES_NAME"]));
                        xPI.CreateDateAttr("PROJECT_CHECKEDOUT_DATE", DBAccess.ReadDateValue(row["PROJECT_CHECKEDOUT_DATE"]));
                        sXML = xPI.XML();
                    }
                }
            }
            catch (PFEException pex)
            {
                //if (pex.ExceptionNumber == 9999)
                //    Response.Redirect(this.Site.Url + "/_layouts/ppm/NoPerm.aspx?requesturl='" + Request.RawUrl + "'");
                //lblGeneralError.Text = "PFE Exception : " + pex.ExceptionNumber.ToString() + " - " + pex.Message;
                //lblGeneralError.Visible = true;
            }
            catch (Exception ex)
            {
                //lblGeneralError.Text = ex.Message;
                //lblGeneralError.Visible = true;
            }
            finally
            {
                if (dba != null)
                    dba.Close();
            }
            return sXML;
        }
        #endregion
    }
}
