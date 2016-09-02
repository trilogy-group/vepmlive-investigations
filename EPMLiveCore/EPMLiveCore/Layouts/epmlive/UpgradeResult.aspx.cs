using System;
using EPMLiveCore.API;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class UpgradeResult : LayoutsPageBase
    {
        #region Fields (1) 

        private string _upgradeDetails;

        #endregion Fields 

        #region Properties (1) 

        protected string UpgradeDetails
        {
            get { return _upgradeDetails; }
        }

        #endregion Properties 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            _upgradeDetails = Timer.GetTimerJobStatus(Web.Site.ID, Web.ID, 201, true)
                                   .InnerText.Replace("\r\n", "<br/>")
                                   .Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        }

        #endregion Methods 
    }
}