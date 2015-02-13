using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Xml;
using EPMLiveCore.API;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ImportResourceStatus : LayoutsPageBase
    {
        #region Fields (1) 

        private string _jobId;

        #endregion Fields 

        #region Properties (2) 

        protected string JobId
        {
            get { return _jobId; }
        }

        protected string Version
        {
            get
            {
                string version = string.Empty;

                string temp;
                if (!IsInDebugMode(out temp))
                {
                    string fileVersion =
                        FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

                    if (string.IsNullOrEmpty(fileVersion) || fileVersion.Equals("1.0.0.0"))
                    {
                        fileVersion = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
                    }

                    version = "?v=" + fileVersion;
                }

                return version;
            }
        }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            _jobId = Request.Params["jobid"] ?? string.Empty;
            string format = Request.Params["format"] ?? string.Empty;
            bool isImportCancelled = Convert.ToBoolean(Request.Params["isCancelImportResourceJob"]);

            if (!isImportCancelled)
            {
                if (!format.Trim().ToLower().Equals("json"))
                {
                    if (string.IsNullOrEmpty(_jobId))
                    {
                        MissingJobIdErrorLabel.Visible = true;
                    }
                    else
                    {
                        Panel.Visible = true;
                        ScriptLink.Register(Page, "/_layouts/epmlive/javascripts/libraries/jquery.min.js", false);
                    }
                }
                else
                {
                    string response = "{warmingUp:true}";

                    if (string.IsNullOrEmpty(_jobId))
                    {
                        response = "{error:\"No Job ID was provided.\"}";
                    }
                    else
                    {
                        XmlNode timerJobStatus = Timer.GetTimerJobStatus(Web, new Guid(_jobId));

                        XmlNode node = timerJobStatus.FirstChild;
                        if (node != null)
                        {
                            response = node.Value;
                        }
                    }

                    Response.Clear();
                    Response.ContentType = "application/json; charset=utf-8";
                    Response.Write(Server.HtmlDecode(response));
                    Response.End();
                }
            }
            else
            {
                Timer.CancelTimerJob(Web.Site.ID, new Guid(_jobId));
            }
        }

        // Private Methods (1) 

        private bool IsInDebugMode(out string epmDebug)
        {
            epmDebug = Page.Request.Params["epmdebug"];
            return !string.IsNullOrEmpty(epmDebug);
        }

        #endregion Methods 
    }
}