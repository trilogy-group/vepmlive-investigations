using System;
using System.Web;
using System.IO;
using WorkEnginePPM;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using PortfolioEngineCore;

namespace PPM
{

    public partial class PageRequest : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            const string this_class = "PPM.PageRequest";
            string s = "";
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

        public static string Prioritization(HttpContext Context, string sXML)
        {
            string basePath = WebAdmin.GetBasePath();
            string sReply = "";
            //string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            //PortfolioEngineCore.ResourcePlans rp = new PortfolioEngineCore.ResourcePlans(sBaseInfo);
            try
            {
                sReply = PPM.Prioritization.SaveWeightData(Context, basePath, sXML);
                //rp.HandleRequest(sXML, out sReply);
            }
            catch (Exception ex)
            {
                sReply = HandleException("Prioritization", 99999, ex);
            }
            //finally
            //{
            //    rp = null;
            //}

            return sReply;
        }
        public static string Permissions(HttpContext Context, string sXML)
        {
            string basePath = WebAdmin.GetBasePath();
            string sReply = "";
            try
            {
                sReply = xepkadmin1.UpdatePermissions(basePath, sXML);
            }
            catch (Exception ex)
            {
                sReply = HandleException("Permissions", 99999, ex);
            }

            return sReply;
        }

        private static string HandleException(string sFunction, int nStatus,Exception ex)
        {
            CStruct xReply = new CStruct();
            xReply.Initialize("Reply");
            xReply.CreateString("HRESULT", "0");
            xReply.CreateString("STATUS", "9222");
            xReply.CreateString("Error", "EPKRequest Exception : " + ex.Message.ToString());
            return xReply.XML();
        }

        #endregion
    }

    internal class Prioritization
    {
        public static string SaveWeightData(HttpContext Context, string sContextInfo, string sData)
        {
            string sReply = "";
            try
            {
                CStruct xGrid = new CStruct();
                if (xGrid.FromString(sData, true) == false)
                {
                    sReply = "SaveWeightData : Unable to load Grid XML";
                    return sReply;
                }
                else
                {
                    //WebAdmin.
                    //string sDBConnect = WebAdmin.GetConnectionString(sContextInfo);
                    //DBAccess dba = new DBAccess(sDBConnect);
                    string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                    DataAccess da = new DataAccess(sBaseInfo);
                    DBAccess dba = da.dba;
                    if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

                    DataTable dt;
                    if (dbaPrioritz.SelectComponents(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

                    List<int> Components = new List<int>();
                    foreach (DataRow row in dt.Rows)
                    {
                        int lFieldID = DBAccess.ReadIntValue(row["CC_COMPONENT"]);
                        Components.Add(lFieldID);
                    }

                    CStruct xBody = xGrid.GetSubStruct("Body");
                    CStruct xB = xBody.GetSubStruct("B");
                    List<CStruct> listI = xB.GetList("I");

                    List<EPKPriFormula> c_formulas = new List<EPKPriFormula>();
                    foreach (CStruct xI in listI)
                    {
                        EPKPriFormula formula = new EPKPriFormula();
                        formula.name = xI.GetStringAttr("Scenario");
                        formula.uid = xI.GetIntAttr("FieldID");

                        foreach (int Component in Components)
                        {
                            ComponentWeight cw = new ComponentWeight();
                            cw.ScenarioId = formula.uid;
                            cw.ComponentId = Component;
                            cw.Weight = xI.GetDoubleAttr("C_" + Component.ToString(), 0);
                            formula.components.Add(cw);
                        }
                        c_formulas.Add(formula);
                    }

                    int lRowsAffected;
                    if (dbaPrioritz.UpdateWeights(dba, c_formulas, out lRowsAffected) != StatusEnum.rsSuccess)
                        goto Exit_Function;

                }
            }
            catch (Exception ex)
            {
                sReply = HandleException(ex);
            }

        Exit_Function:
        Status_Error:

            return sReply;
        }

        public static string HandleException(Exception ex)
        {
            return "Prioritization Exception : " + ex.Message;
        }
    }

    #region Nested type: PublicAPI

    public class PublicAPI : Attribute
    {
        // positional parameters
        public PublicAPI(bool isPublic)
        {
            IsPublic = isPublic;
        }

        // property for named parameter
        public bool IsPublic { get; set; }
    }

    #endregion
}
