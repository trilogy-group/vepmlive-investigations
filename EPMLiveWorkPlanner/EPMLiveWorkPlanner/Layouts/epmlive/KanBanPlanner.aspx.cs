using System;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWorkPlanner
{
    public partial class KanBanPlanner : LayoutsPageBase
    {
        #region Fields (1)

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";

        #endregion Fields

        #region Properties (2)

        public string strPlanner
        {
            get { return Convert.ToString(Request["planner"]); }
        }

        public string strProjectId
        {
            get { return Convert.ToString(Request["ID"]); }
        }

        #endregion Properties

        #region Methods (2)

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "styles/kanban/kanban.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/slimScroll","kanban/jquery.dotdotdot.min"
            });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion Methods
    }
}