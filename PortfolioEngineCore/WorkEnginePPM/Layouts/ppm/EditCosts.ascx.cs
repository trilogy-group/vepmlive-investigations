using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class EditCostsControl : System.Web.UI.UserControl
    {
        private const string WebserviceSuffix = "/_vti_bin/editcosts.asmx";
        private string m_sWebservice = "";
        private string m_sURL = "";
        //private string m_sRuntimeID = "";
        //private string m_sGridStyle = "GM";
        //private string m_sGridCSS = "EditCosts";
        //private string m_sDHTMLXSkin = "aqua_sky";

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

        private int m_nProjectID = 0;
        public int ProjectID
        {
            get { return m_nProjectID; }
            set { m_nProjectID = value; }
        }

        private string m_sWEPID = "";
        public string WEPID
        {
            get { return m_sWEPID; }
            set { m_sWEPID = value; }
        }

        private int m_nViewUID = 0;
        public int ViewUID
        {
            get { return m_nViewUID; }
            set { m_nViewUID = value; }
        }

        private string m_sIsDlg = "";
        public string IsDlg
        {
            get { return m_sIsDlg; }
            set { m_sIsDlg = value; }
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
