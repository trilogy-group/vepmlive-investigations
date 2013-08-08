using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Controls.Navigation
{
    [MdsCompliant(true)]
    [ParseChildren(true)]
    public class EPMLiveNavigation : WebControl
    {
        private readonly List<NavLink> _topLevelLinks;

        public EPMLiveNavigation()
        {
            _topLevelLinks = new List<NavLink>();
        }

        #region Overrides of Control

        private const string ASCX_PATH = @"~/_controltemplates/EPMLiveNavigation.ascx";

        protected override void CreateChildControls()
        {
            var control = (CONTROLTEMPLATES.EPMLiveNavigation) Page.LoadControl(ASCX_PATH);
            control.TopLevelLinks = TopLevelLinks;
            Controls.Add(control);
        }

        #endregion

        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<NavLink> TopLevelLinks
        {
            get { return _topLevelLinks; }
        }
    }

    public class NavControl
    {
        public string LinkId { get; set; }
        public Control Control { get; set; }
    }
}