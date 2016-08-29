using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
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
            string sReply = "";
            try
            {
                int nPROJECT_ID;
                string sBaseInfo;                    
                DataAccess da;
                DBAccess dba;

               switch (sRequestContext)
                {
                    case "ClosePI":
                    {
                        nPROJECT_ID = xData.GetIntAttr("PROJECT_ID");
                        sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        da = new DataAccess(sBaseInfo);
                        dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            try
                            {
                                if (dbaDBAdmin.ClosePI(dba, nPROJECT_ID, out sReply) != StatusEnum.rsSuccess)
                                {
                                    if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "DBAdmin.ClosePI", dba.StatusText);
                                }
                                else
                                {
                                    sReply = GetPIXML(dba, nPROJECT_ID);
                                }
                            }
                            catch (Exception ex)
                            {
                                sReply = WebAdmin.FormatError("exception", "DBAdmin.ClosePI", ex.Message);
                            }
                            dba.Close();
                        }
                        break;
                    }
                    case "OpenPI":
                    {
                        nPROJECT_ID = xData.GetIntAttr("PROJECT_ID");
                        sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        da = new DataAccess(sBaseInfo);
                        dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            try
                            {
                                if (dbaDBAdmin.OpenPI(dba, nPROJECT_ID, out sReply) != StatusEnum.rsSuccess)
                                {
                                    if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "DBAdmin.OpenPI", dba.StatusText);
                                }
                                else
                                {
                                    sReply = GetPIXML(dba, nPROJECT_ID);
                                }
                            }
                            catch (Exception ex)
                            {
                                sReply = WebAdmin.FormatError("exception", "DBAdmin.OpenPI", ex.Message);
                            }
                            dba.Close();
                        }
                        break;
                    }
                    case "CheckInPI":
                    {
                        nPROJECT_ID = xData.GetIntAttr("PROJECT_ID");
                        sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        da = new DataAccess(sBaseInfo);
                        dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            try
                            {
                                if (dbaDBAdmin.CheckInPI(dba, nPROJECT_ID, out sReply) != StatusEnum.rsSuccess)
                                {
                                    if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "DBAdmin.CheckInPI", dba.StatusText);
                                }
                                else
                                {
                                    sReply = GetPIXML(dba, nPROJECT_ID);
                                }
                            }
                            catch (Exception ex)
                            {
                                sReply = WebAdmin.FormatError("exception", "DBAdmin.CheckInPI", ex.Message);
                            }
                            dba.Close();
                        }
                        break;
                    }
                    case "DeletePI":
                    {
                        nPROJECT_ID = xData.GetIntAttr("PROJECT_ID");
                        sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        da = new DataAccess(sBaseInfo);
                        dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            try
                            {
                                if (dbaDBAdmin.DeletePI(dba, nPROJECT_ID, out sReply) != StatusEnum.rsSuccess)
                                {
                                    if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "DBAdmin.DeletePI", dba.StatusText);
                                }
                            }
                            catch (Exception ex)
                            {
                                sReply = WebAdmin.FormatError("exception", "DBAdmin.DeletePI", ex.Message);
                            }
                            dba.Close();
                        }
                        break;
                    }
                    case "CanDeleteRes":
                    {
                        int nWRES_ID = xData.GetIntAttr("WRES_ID");
                        sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        da = new DataAccess(sBaseInfo);
                        dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            try
                            {
                                if (dbaDBAdmin.CanDeleteResource(dba, nWRES_ID, out sReply) != StatusEnum.rsSuccess)
                                {
                                    // if  status != success then sreply already fully formatted with error   
                                    //sReply = WebAdmin.FormatError("exception", "DBAdmin.CanDeleteRes1", dba.StatusText);
                                }
                                else if (sReply.Length > 0)
                                {
                                    // error reply just needs formatting
                                    sReply = "This resource cannot be deleted, it is used as follows:" + "\n" + sReply;
                                    sReply = WebAdmin.FormatError("error", "CanDeleteResource", sReply);
                                }
                                else
                                {
                                    if (dbaDBAdmin.CanDeleteResourceWarning(dba, nWRES_ID, out sReply) != StatusEnum.rsSuccess)
                                    {
                                        // if  status != success then sreply already fully formatted with error   
                                        //if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "DBAdmin.CanDeleteRes2", dba.StatusText);
                                    }
                                    else if (sReply.Length > 0)
                                    {
                                        sReply = "This resource can be deleted, references will be changed to point to you:" + "\n" + sReply;
                                        sReply = WebAdmin.FormatWarning(sReply);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                sReply = WebAdmin.FormatError("exception", "DBAdmin.CanDeleteRes", ex.Message);
                            }
                            dba.Close();
                        }
                        break;
                    }
                    case "DeleteRes":
                    {
                        int nWRES_ID = xData.GetIntAttr("WRES_ID");
                        sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        da = new DataAccess(sBaseInfo);
                        dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            try
                            {
                                if (nWRES_ID == da.UserId)
                                {
                                    sReply = "You are logged in as this resource, cannot delete";
                                }
                                else
                                {
                                    if (dbaDBAdmin.DeleteResource(dba, nWRES_ID, out sReply) != StatusEnum.rsSuccess)
                                    {
                                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "DBAdmin.DeleteResource", dba.StatusText);
                                    }
                                    else
                                    {
                                        ////  needed to update list after SAVE
                                        //CStruct xCostviews = new CStruct();
                                        //xCostviews.Initialize("Costview");
                                        //xCostviews.CreateIntAttr("VIEW_UID", nVIEW_UID);
                                        //xCostviews.CreateStringAttr("VIEW_NAME", sVIEW_NAME);
                                        //xCostviews.CreateStringAttr("VIEW_DESC", sVIEW_DESC);
                                        //sReply = xCostviews.XML();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                sReply = WebAdmin.FormatError("exception", "DBAdmin.DeleteRes", ex.Message);
                            }
                            dba.Close();
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "DBAdmin.DBAdminRequest", ex.Message);
            }

            return sReply;
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
