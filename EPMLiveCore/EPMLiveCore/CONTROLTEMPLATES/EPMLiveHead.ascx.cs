using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    public partial class EPMLiveHead : UserControl
    {
        #region Properties (1) 

        public string EPMLiveVersion { get; private set; }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            EPMLiveVersion = EPMLiveScriptManager.FileVersion;
        }

        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods 
    }
}