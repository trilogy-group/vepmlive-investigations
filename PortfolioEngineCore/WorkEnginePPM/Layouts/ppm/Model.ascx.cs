using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class ModelControl : System.Web.UI.UserControl
    {
        private const string WebserviceSuffix = "/_vti_bin/Model.asmx";
        private string m_sWebservice = "";
        private string m_sURL = "";
        private string m_sRuntimeID = "";
        private string m_sGridStyle = "GM";
        private string m_sGridCSS = "Modeler";

        public string URL
        {
            get
            {
                if (m_sURL == "")
                    m_sURL = "/";
                //m_sURL = this.Request.ApplicationPath + "/";
                return m_sURL;
            }
            set
            {
                m_sURL = value.Trim();
                if (m_sURL.EndsWith("/") == false)
                    m_sURL += "/";
            }
        }
        public string Webservice
        {
            get
            {
                if (m_sWebservice == "")
                    m_sWebservice = "~" + WebserviceSuffix;
                return m_sWebservice;
            }
            set { m_sWebservice = value.Trim(); }
        }

        public string RuntimeID
        {
            get
            {
                return m_sRuntimeID;
            }
            set
            {
                m_sRuntimeID = value.Trim();
            }
        }

        public string GridStyle
        {
            get { return m_sGridStyle; }
            set { m_sGridStyle = value; }
        }

        public string GridCSS
        {
            get { return m_sGridCSS; }
            set { m_sGridCSS = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //string includeTemplate = "<link rel='stylesheet' text='text/css' href='{0}' />";
            //string includeLocation = this.Page.ClientScript.GetWebResourceUrl(typeof(PEUserControls.Model), "PEUserControls.Model.ascx.css");
            //LiteralControl include = new LiteralControl(String.Format(includeTemplate, includeLocation));
            //((HtmlHead)Page.Header).Controls.Add(include);
            //this.Page.ClientScript.RegisterClientScriptResource(typeof(PEUserControls.Model), "PEUserControls.Model.ascx.js");
            //this.Page.ClientScript.RegisterClientScriptResource(typeof(PEUserControls.Model), "PEUserControls.general.js");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sm1.Services.Add(new ServiceReference(Webservice));
        }

        private int m_nProjectID = 0;
        public int ProjectID
        {
            get { return m_nProjectID; }
            set { m_nProjectID = value; }
        }
        private int m_nViewUID = 0;
        public int ViewUID
        {
            get { return m_nViewUID; }
            set { m_nViewUID = value; }
        }
        private string m_sTicket = "";
        public string TicketVal
        {
            get { return m_sTicket; }
            set { m_sTicket = value; }
        }
        private string m_sModel = "";
        public string ModelVal
        {
            get { return m_sModel; }
            set { m_sModel = value; }
        }
        private string m_sVersions = "";
        public string VersionsVal
        {
            get { return m_sVersions; }
            set { m_sVersions = value; }
        }
        private string m_sViewID = "";
        public string ViewIDVal
        {
            get { return m_sViewID; }
            set { m_sViewID = value; }
        }
        private string m_sViewName = "";
        public string ViewNameVal
        {
            get { return m_sViewName; }
            set { m_sViewName = value; }
        }
    }
}