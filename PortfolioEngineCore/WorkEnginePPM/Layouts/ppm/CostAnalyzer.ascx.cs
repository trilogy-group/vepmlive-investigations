using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class CostAnalyzerControl : System.Web.UI.UserControl
    {
        private const string WebserviceSuffix = "/_vti_bin/CostAnalyzer.asmx";
        private string m_sWebservice = "";
        private string m_sURL = "";

        public string FileVersion
        {
            get
            {
                return PPM.PfEAssemblyInfo.FileVersion();
            }
        }
        
        public string URL
        {
            get
            {
                if (m_sURL == "")
                    m_sURL = "/";
                return m_sURL;
            }
            set
            {
                m_sURL = value.Trim();
                if (m_sURL.EndsWith("/") == false)
                    m_sURL += "/";
            }
        }
        private string m_sWEPID = "";
        public string WEPID
        {
            get { return m_sWEPID; }
            set { m_sWEPID = value; }
        }



        private string m_sTicket = "";
        public string TicketVal
        {
            get { return m_sTicket; }
            set { m_sTicket = value; }
        }

        private string m_sViewID = "";
        public string ViewIDVal
        {
            get { return m_sViewID; }
            set { m_sViewID = value; }
        }
        public string ViewNameVal
        {
            get { return m_sViewID; }
            set { m_sViewID = value; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            sm1.Services.Add(new ServiceReference(Webservice));
        }
    }
}
