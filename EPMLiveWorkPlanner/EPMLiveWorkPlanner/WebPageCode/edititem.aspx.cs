using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EPMLiveCore.Helpers;
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
                ItemHelper.SetCloseAndBackButtons(ListFormWebPart1);
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