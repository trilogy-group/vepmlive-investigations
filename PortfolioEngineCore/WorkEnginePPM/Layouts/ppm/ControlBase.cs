using System.Web.UI;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public class ControlBase : UserControl
    {
        private string m_sURL = string.Empty;
        private string m_sWEPID = string.Empty;
        private string m_sTicket = string.Empty;
        private string m_sViewID = string.Empty;
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
                if (m_sURL == string.Empty)
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
        public string WEPID
        {
            get { return m_sWEPID; }
            set { m_sWEPID = value; }
        }
        public string TicketVal
        {
            get { return m_sTicket; }
            set { m_sTicket = value; }
        }
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
    }
}