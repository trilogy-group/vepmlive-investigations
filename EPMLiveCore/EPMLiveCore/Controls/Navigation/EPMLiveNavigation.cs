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
        private readonly List<NavNode> _bottomNodes;
        private readonly List<NavNode> _topNodes;

        public EPMLiveNavigation()
        {
            _topNodes = new List<NavNode>();
            _bottomNodes = new List<NavNode>();
        }

        #region Overrides of Control

        private const string ASCX_PATH = @"~/_controltemplates/EPMLiveNavigation.ascx";

        protected override void CreateChildControls()
        {
            var control = (CONTROLTEMPLATES.EPMLiveNavigation) Page.LoadControl(ASCX_PATH);
            control.TopNodes = TopNodes;
            control.BottomNodes = BottomNodes;
            Controls.Add(control);
        }

        #endregion

        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<NavNode> TopNodes
        {
            get { return _topNodes; }
        }

        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public List<NavNode> BottomNodes
        {
            get { return _bottomNodes; }
        }
    }
}