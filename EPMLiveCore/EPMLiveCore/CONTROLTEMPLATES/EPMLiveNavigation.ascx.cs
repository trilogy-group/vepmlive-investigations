using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    [MdsCompliant(true)]
    public partial class EPMLiveNavigation : UserControl
    {
        #region Fields (2) 

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";
        private string _selectedTlNode;

        #endregion Fields 

        #region Properties (12) 

        public IEnumerable<NavNode> AllNodes
        {
            get
            {
                List<NavNode> nodes = TopNodes.ToList();
                nodes.AddRange(BottomNodes);

                return nodes;
            }
        }

        public IEnumerable<NavNode> BottomNodes { get; set; }

        public bool IsRootWeb
        {
            get { return SPContext.Current.Web.IsRootWeb; }
        }

        public bool Pinned { get; private set; }

        public string SelectedNode { get; private set; }

        public string SelectedTlNode
        {
            get { return _selectedTlNode ?? "epm-nav-top-ql"; }
        }

        public string StaticProviderLinks { get; private set; }

        public IEnumerable<NavNode> TopNodes { get; set; }

        public string UserId
        {
            get { return SPContext.Current.Web.CurrentUser.ID.ToString(CultureInfo.InvariantCulture); }
        }

        public string WebId
        {
            get { return SPContext.Current.Web.ID.ToString(); }
        }

        public string WebUrl
        {
            get { return SPContext.Current.Web.ServerRelativeUrl; }
        }

        public bool WorkspaceCreationEnabled
        {
            get
            {
                try
                {
                    string flag = CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLiveDisableMyWorkspaces");
                    return string.IsNullOrEmpty(flag) || !bool.Parse(flag);
                }
                catch { }

                return true;
            }
        }

        #endregion Properties 

        #region Methods (6) 

        // Protected Methods (3) 

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            foreach (string style in new[] {"controls/navigation/epmnav.min"})
            {
                SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "stylesheets/" + style + ".css");
            }

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "@libraries/jquery.cookie", "libraries/slimScroll", "@libraries/bindWithDelay",
                "@EPMLive.Navigation"
            });

            CalculatePinState();

            string userAgent = Request.UserAgent;
            if (userAgent != null && userAgent.Contains("Chrome"))
            {
                SPPageContentManager.RegisterStyleFile(LAYOUT_PATH +
                                                       "stylesheets/controls/navigation/epmnav.chrome.min.css");
            }

            LoadSelectedNodeLinks();

            if (WorkspaceCreationEnabled) return;

            NavNode wsNode = null;
            foreach (NavNode node in TopNodes.Where(n => !string.IsNullOrEmpty(n.Id) && n.Id.Equals("workspaces")))
            {
                wsNode = node;
            }

            if (wsNode == null) return;

            List<NavNode> nodes = TopNodes.ToList();
            nodes.Remove(wsNode);

            TopNodes = nodes;
        }

        protected void OnTreeViewPreRender(object sender, EventArgs e)
        {
            var spTreeView = ((SPTreeView) sender);

            SPContext spContext = SPContext.Current;

            if (spContext.Web.IsRootWeb)
            {
                TreeNode wpNode =
                    spTreeView.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Text.Trim().ToLower().Equals("global my workplace"));

                if (wpNode != null)
                {
                    spTreeView.Nodes.Remove(wpNode);
                }
            }

            GetAssociatedItems(spContext, spTreeView);

            spTreeView.ExpandAll();
        }

        protected void Page_Load(object sender, EventArgs e) { }

        // Private Methods (3) 

        private void CalculatePinState()
        {
            int userId = SPContext.Current.Web.CurrentUser.ID;

            HttpCookie selectedTlNodeCookie = Request.Cookies.Get("epmnav-selected-tlnode-u-" + userId);
            if (selectedTlNodeCookie != null)
            {
                _selectedTlNode = selectedTlNodeCookie.Value;
            }

            Pinned = true;

            HttpCookie pinStateCookie = Request.Cookies.Get("epmnav-pin-state-u-" + userId);
            if (pinStateCookie != null)
            {
                Pinned = pinStateCookie.Value.Equals("pinned");
            }
        }

        private static void GetAssociatedItems(SPContext spContext, SPTreeView spTreeView)
        {
            var linkProvider = new AssociatedItemsLinkProvider(
                spContext.Site.ID,
                spContext.Web.ID,
                spContext.Web.CurrentUser.LoginName);

            List<INavObject> links = linkProvider.GetLinks().ToList();

            if (!links.Any()) return;

            var rootNode = new TreeNode {Text = links.First().Title};

            foreach (INavObject link in links.Skip(1))
            {
                rootNode.ChildNodes.Add(new TreeNode
                {
                    Text = link.Title,
                    NavigateUrl = link.Url
                });
            }

            spTreeView.Nodes.Add(rootNode);
        }

        private void LoadSelectedNodeLinks()
        {
            if (SelectedTlNode.Equals("epm-nav-top-ql")) return;

            try
            {
                string nodeId = SelectedTlNode.Replace("epm-nav-top-", string.Empty);
                string provider = (from node in AllNodes
                    where !node.Separator
                    let id = node.Id
                    where !string.IsNullOrEmpty(id)
                    where id.Equals(nodeId)
                    select node.LinkProvider).FirstOrDefault();

                SelectedNode = provider;

                var navService = new NavigationService(provider, SPContext.Current.Web);
                StaticProviderLinks = navService.GetLinks().EncodeToBase64();
            }
            catch { }
        }

        #endregion Methods 
    }
}