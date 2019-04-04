using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class sitepermissions : LayoutsPageBase
    {
        protected string account_ref;
        protected Guid accountid;
        protected string quantity;
        protected string strBarColor;
        protected string strWidth;
        protected string version;
        protected string weburl;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb mySite = SPContext.Current.Web;
            weburl = mySite.Url;
            
            if (!IsPostBack)
            {
                fillData(mySite.Site);
            }
            
            lblTitle.Text = "Manage Site Permissions";

            bool canEdit = false;

            foreach (SPGroup group in mySite.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    canEdit = true;
                    break;
                }
            }

            if (!canEdit)
            {
                GridView1.Columns[4].Visible = false;
            }
        }
        
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SPWeb web = SPContext.Current.Web;

                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton2");
                string cmd = l.CommandArgument;

                l = (LinkButton)e.Row.FindControl("LinkButton1");
                if (l.CommandArgument.ToUpper() == hdnUserId.Value.ToUpper())
                    l.Visible = false;


                l.Attributes.Add("onclick",
                    "javascript:return confirm('Are you sure you want to delete " + 
                    $"{DataBinder.Eval(e.Row.DataItem, "name")} from your site?')");
                l.CommandArgument = cmd;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;

                SPUser user = web.AllUsers[e.CommandArgument.ToString().Replace("\\\\", "\\")];
                foreach (SPGroup group in web.Groups)
                {
                    if (group.CanCurrentUserEditMembership)
                    {
                        try
                        {
                            group.RemoveUser(user);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/sitepermissions.aspx?", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            if (e.CommandName == "Edi")
            {


                SPWeb mySite = SPContext.Current.Web;

                pnlEdit.Visible = true;
                pnl.Visible = false;
                string username = e.CommandArgument.ToString().Replace("\\\\", "\\");

                HiddenUsername.Value = username;
                try
                {
                    lblName.Text = mySite.AllUsers[username].Name;
                    lblUsername.Text = username;
                    lblEmail.Text = mySite.AllUsers[username].Email;
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

                if (mySite.UserIsSiteAdmin)
                {
                    if (mySite.AllUsers[username].IsSiteAdmin)
                        pnlGroups.Controls.Add(
                            new LiteralControl(
                                "<input type=\"checkbox\" name=\"Groups\" checked value=\"@\"> Site Collection Administrator"));
                    else
                        pnlGroups.Controls.Add(
                            new LiteralControl(
                                "<input type=\"checkbox\" name=\"Groups\" value=\"@\"> Site Collection Administrator"));
                    pnlGroups.Controls.Add(new LiteralControl("<br>"));
                }


                SPUser user = mySite.AllUsers[username];
                foreach (SPGroup g in mySite.Groups)
                {
                    string group = g.Name;
                    bool canEdit = mySite.SiteGroups[group].CanCurrentUserEditMembership;
                    bool found = false;
                    foreach (SPGroup ugroup in user.Groups)
                    {
                        if (ugroup.Name == group)
                            found = true;
                    }
                    if (found)
                        if (canEdit)
                            pnlGroups.Controls.Add(
                                new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"" + group +
                                                   "\">" + group));
                        else
                            pnlGroups.Controls.Add(
                                new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"" + group +
                                                   "\" disabled>" + group));
                    else if (canEdit)
                        pnlGroups.Controls.Add(
                            new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"" + group + "\">" +
                                               group));
                    else
                        pnlGroups.Controls.Add(
                            new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"" + group +
                                               "\" disabled>" + group));
                    pnlGroups.Controls.Add(new LiteralControl("<br>"));
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            SPWeb mySite = SPContext.Current.Web;
            mySite.AllowUnsafeUpdates = true;

            pnlEdit.Visible = false;
            GridView1.Visible = true;
            Hashtable myHash = new Hashtable();
            SPUser user = mySite.AllUsers[HiddenUsername.Value];


            bool hasGroup = false;
            bool addGroup = false;
            foreach (SPGroup group in user.Groups)
            {
                try
                {
                    string g = mySite.Groups[group.Name].Name;
                    hasGroup = true;
                }
                catch
                {
                }
            }

            bool setSiteAdmin = false;

            if (Request["Groups"] != null)
            {
                string[] groups = Request["Groups"].Split(',');
                if (groups.Length > 0)
                {
                    foreach (string group in groups)
                    {
                        if (group == "@")
                        {
                            setSiteAdmin = true;
                        }
                        else
                        {
                            try
                            {
                                myHash.Add(group, "");
                                mySite.Groups[group].AddUser(user);
                                addGroup = true;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            
            foreach (SPGroup g in mySite.SiteGroups)
            {
                string group = g.Name;
                if (mySite.SiteGroups[group].CanCurrentUserEditMembership)
                {
                    if (!myHash.Contains(group))
                    {
                        try
                        {
                            mySite.Groups[group].RemoveUser(user);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            if (mySite.UserIsSiteAdmin)
            {
                if (setSiteAdmin)
                {
                    user.IsSiteAdmin = true;
                    user.Update();
                }
                else
                {
                    user.IsSiteAdmin = false;
                    user.Update();
                }
            }
            
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/sitepermissions.aspx?", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/sitepermissions.aspx?", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }
    }
}