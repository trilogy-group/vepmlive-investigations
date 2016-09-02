using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWorkPlanner
{
    public partial class edititem : System.Web.UI.Page
    {
        protected ListFormWebPart ListFormWebPart1;
        protected string pageClose;

        protected string webUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            webUrl = SPContext.Current.Web.Url;
            if (Request["close"] != "1")
            {
                Button closebutton = new Button();
                closebutton.Text = "Close";
                closebutton.CssClass = "ms-ButtonHeightWidth";
                closebutton.OnClientClick = "closePage();";

                Button closebutton2 = new Button();
                closebutton2.Text = "Close";
                closebutton2.CssClass = "ms-ButtonHeightWidth";
                closebutton2.OnClientClick = "closePage();";
                ListFormWebPart1.Controls[0].FindControl("toolBarTbltop").FindControl("RightRptControls").Controls.AddAt(4, closebutton);
                ListFormWebPart1.Controls[0].FindControl("toolBarTbl").FindControl("RightRptControls").Controls.AddAt(2, closebutton2);

                GoBackButton btn = (GoBackButton)ListFormWebPart1.Controls[0].FindControl("toolBarTbltop").FindControl("RightRptControls").FindControl("ctl02");

                btn.Visible = false;
                btn = (GoBackButton)ListFormWebPart1.Controls[0].FindControl("toolBarTbl").FindControl("RightRptControls").FindControl("ctl01");
                btn.Visible = false;
            }
        }

        protected void ListFormWebPart1_Init(object sender, EventArgs e)
        {
            try
            {
                if (Request["close"] == "1")
                {
                    pageClose = "true";
                }
                else
                {
                    pageClose = "false";
                }
                Guid id = new Guid(Request["listId"]);
                SPWeb web = SPContext.Current.Web;

                SPList list = web.Lists[id];

                SPListItem li = null;
                try
                {
                    li = list.GetItemById(int.Parse(Request["ID"]));
                }
                catch { }
                if (li != null || Request["close"] == "1")
                {
                    ListFormWebPart1.ListName = list.ID.ToString();
                    ListFormWebPart1.ListTitle = list.ID.ToString();
                    ListFormWebPart1.Title = list.Title;
                    ListFormWebPart1.ListItemId = int.Parse(Request["ID"]);
                    ListFormWebPart1.BorderStyle = BorderStyle.None;
                    ListFormWebPart1.ChromeType = PartChromeType.None;

                    if (Request["Mode"] == "1")
                    {
                        ListFormWebPart1.FormType = 4;
                        ListFormWebPart1.ControlMode = SPControlMode.Display;
                    }
                }
                else
                {
                    Response.Redirect("showerror.aspx?error=Task does not exist. You need to save your workplan first.");
                }
                //web.Close();
            }
            catch (Exception ex)
            {
                //Response.Redirect("showerror.aspx?error=" + ex.Message);
            }
        }
    }
}