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
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Data.SqlClient;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveEnterprise.Layouts.epmlive
{
    public partial class epubstatus : LayoutsPageBase
    {
        protected Microsoft.SharePoint.WebControls.SPGridView GvItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string action = Request["action"];

                MenuTemplate propertyNameListMenu = new MenuTemplate();
                propertyNameListMenu.ID = "PropertyNameListMenu";

                MenuItemTemplate testMenu = new MenuItemTemplate("Remove From Database", "/_layouts/15/images/delete.gif");
                testMenu.ClientOnClickScript = "javascript:if(confirm('Are you sure you want to remove this project from the EPM Live Database?')){location.href='epubstatus.aspx?action=delete&projectid=%NAME%';}";
                propertyNameListMenu.Controls.Add(testMenu);

                testMenu = new MenuItemTemplate("Link Workspace", "/_layouts/15/epmlive/images/linkworkspace.gif");
                testMenu.ClientOnClickScript = "javascript:linkworkspace('%NAME%');";
                propertyNameListMenu.Controls.Add(testMenu);

                testMenu = new MenuItemTemplate("Unlink Workspace", "/_layouts/15/epmlive/images/unlinkworkspace.gif");
                testMenu.ClientOnClickScript = "javascript:if(confirm('Are you sure you want to unlink that workspace?')){location.href='epubstatus.aspx?action=unlink&projectid=%NAME%';}";
                propertyNameListMenu.Controls.Add(testMenu);

                testMenu = new MenuItemTemplate("View Publish Log", "/_layouts/15/images/txt16.gif");
                testMenu.ClientOnClickNavigateUrl = "eviewlog.aspx?projectid=%NAME%";
                propertyNameListMenu.Controls.Add(testMenu);

                this.Controls.Add(propertyNameListMenu);

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                    cn.Open();
                    SqlCommand cmd;
                    if (action != null && action != "")
                    {
                        switch (action)
                        {
                            case "delete":
                                cmd = new SqlCommand("DELETE FROM publishercheck where projectguid=@projectguid", cn);
                                cmd.Parameters.AddWithValue("@projectguid", Request["projectid"]);
                                cmd.ExecuteNonQuery();
                                break;
                            case "unlink":
                                cmd = new SqlCommand("UPDATE publishercheck set weburl='',webguid=NULL where projectguid=@projectguid", cn);
                                cmd.Parameters.AddWithValue("@projectguid", Request["projectid"]);
                                cmd.ExecuteNonQuery();
                                break;
                        };

                        cn.Close();
                        Response.Redirect(SPContext.Current.Web.Url + "/_layouts/15/epmlive/epubstatus.aspx");
                    }

                    cmd = new SqlCommand("select * from vwGetProjectStatus order by projectname", cn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    GvItems.DataSource = ds;
                    GvItems.DataBind();

                    cn.Close();

                });
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void GvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //SPMenuField menu = (SPMenuField)e.Row.Controls[0];
            }
        }
    }
}
