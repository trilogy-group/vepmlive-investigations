using System;

namespace AdminSite
{
    public partial class addproduct : System.Web.UI.Page
    {
        protected string CurrentTab;

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentTab = Request["tab"] ?? "1";
        }

        protected string EnableForEditOnly()
        {
            return string.IsNullOrEmpty(Request["id"]) ? "style=\"display:none;\"" : "";
        }
    }
}