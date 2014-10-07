using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class RPEditorControl : UserControl
    {
        private const string WebserviceSuffix = "/_vti_bin/rpeditor.asmx";
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

        private string m_sTicketVal = "";
        public string TicketVal
        {
            get { return m_sTicketVal; }
            set { m_sTicketVal = value; }
        }

        private string m_sIsResource = "";
        public string IsResource
        {
            get { return m_sIsResource; }
            set { m_sIsResource = value; }
        }
        private string m_sIsDlg = "";
        public string IsDlg
        {
            get { return m_sIsDlg; }
            set { m_sIsDlg = value.TrimStart().Substring(0,1); }
        }

        private string m_hideCloseBtn = "";
        public string HideCloseBtn
        {
            get { return m_hideCloseBtn; }
            set { m_hideCloseBtn = value; }
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
