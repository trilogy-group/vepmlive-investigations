using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class EditCalendarControl : System.Web.UI.UserControl
    {
        private const string WebserviceSuffix = "/_vti_bin/editcalendar.asmx";
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
