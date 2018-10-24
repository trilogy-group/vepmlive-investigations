using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class OptimizerControl : ControlBase
    {
        private const string WebserviceSuffix = "/_vti_bin/Optimizer.asmx";
        private string m_sWebservice = "";
        private string m_sListID = "";

        public string ListIdVal
        {
            get { return m_sListID; }
            set { m_sListID = value; }
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
