using System;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class PerformUpgrade : LayoutsPageBase
    {
        #region Properties (1) 

        public string ProxyUrl
        {
            get
            {
                string url = "Upgraders/proxy.aspx";

                if (!string.IsNullOrEmpty(Request["V"])) url += "?V=" + Request["V"];

                return url;
            }
        }

        #endregion Properties 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods 
    }
}