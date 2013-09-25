using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPMLiveIntegrationService
{
    public partial class PostItemSimple : System.Web.UI.Page
    {
        protected string Resp;

        protected void Page_Load(object sender, EventArgs e)
        {
            Integration i = new Integration();
            Resp = i.PostItemSimple(Request["IntegrationKey"], Request["ID"]);
        }
    }
}