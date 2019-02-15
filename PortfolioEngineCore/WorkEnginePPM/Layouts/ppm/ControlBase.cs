using System.Web.UI;
using PPM;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public class ControlBase : UserControl
    {
        private string m_sURL = string.Empty;
        public string FileVersion
        {
            get { return PfEAssemblyInfo.FileVersion(); }
        }
        public string URL
        {
            get
            {
                if (string.IsNullOrWhiteSpace(m_sURL))
                {
                    m_sURL = "/";
                }
                return m_sURL;
            }
            set
            {
                m_sURL = value.Trim();
                if (!m_sURL.EndsWith("/"))
                {
                    m_sURL += "/";
                }
            }
        }
        public string WEPID { get; set; } = string.Empty;
        public string TicketVal { get; set; } = string.Empty;
        public string ViewIDVal { get; set; } = string.Empty;
        public string ViewNameVal
        {
            get { return ViewIDVal; }
            set { ViewIDVal = value; }
        }
    }
}