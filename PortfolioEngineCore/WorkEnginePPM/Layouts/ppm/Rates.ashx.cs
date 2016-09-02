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

    public partial class Rates : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.Rates";
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

        public static string RatesRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "SaveRatesInfo":
                        sReply = SaveRatesInfo(Context, xData);
                        break;
                    default:
                        sReply = WebAdmin.FormatError("error", "RatesRequest", "Unknown Request : " + sRequestContext);
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "Rates.RatesRequest", ex.Message);
            }

            return sReply;
        }
        private static string SaveRatesInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    _TGrid tg = new _TGrid();
                    tg.AddColumn(title: "ID", width: 50, name: "RT_UID", isId: true, hidden: true);
                    tg.AddColumn(title: "Name", width: 180, name: "RT_NAME", maincol: true, editable: true);
                    tg.AddColumn(title: "Level", width: 180, name: "RT_LEVEL", mainlevelcol: true, hidden: true);
                    tg.AddColumn(title: "Resources", width: 180, name: "res_names");
                    tg.AddColumn(title: "wres_ids", width: 180, name: "wres_ids"/*, hidden: true*/);
                    tg.AddColumn(title: "rates", width: 180, name: "rates"/*, hidden: true*/);


                    string sTreegridData = xData.InnerText;
                    DataTable dt = tg.SetXmlData(sTreegridData);

                    if (dbaRates.UpdateRatesInfo(dba, dt, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "Rates.UpdateRatesInfo2", dba.StatusText);
                    }
                    else
                    {
                        //  nothing sent back here after successfull SAVE
                        sReply = "";
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Rates.SaveRatesInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        #endregion
    }
}
