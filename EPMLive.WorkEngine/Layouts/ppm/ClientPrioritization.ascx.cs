using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class ClientPrioritizationControl : System.Web.UI.UserControl
    {
        private const string WebserviceSuffix = "/_vti_bin/ClientPrioritization.asmx";
        private string m_sURL = ""; //"http://localhost:620/site3/";
        private string m_sWebservice = "";
        private string m_sRuntimeID = "";
        private string m_sGridStyle = "GM";
        private string m_sGridCSS = "WorkEngine";

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
                //m_sWebservice = this.URL + WebserviceSuffix;
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

        protected void Page_Init(object sender, EventArgs e)
        {
            //this.Page.ClientScript.RegisterClientScriptResource(typeof(PEUserControls.ClientPrioritization), "PEUserControls.ClientPrioritization.ascx.js");
            //this.Page.ClientScript.RegisterClientScriptResource(typeof(PEUserControls.ClientPrioritization), "PEUserControls.general.js");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sm1.Services.Add(new ServiceReference(Webservice));
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
    }
}
