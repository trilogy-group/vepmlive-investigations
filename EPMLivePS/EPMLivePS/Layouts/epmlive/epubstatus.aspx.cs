using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DiagTrace = System.Diagnostics.Trace;
using Microsoft.SharePoint;
using EPMLiveCore;
using Microsoft.SharePoint.WebControls;

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

                MenuItemTemplate testMenu = new MenuItemTemplate("Remove From Database", "/_layouts/images/delete.gif");
                testMenu.ClientOnClickScript = "javascript:if(confirm('Are you sure you want to remove this project from the EPM Live Database?')){location.href='epubstatus.aspx?action=delete&projectid=%NAME%';}";
                propertyNameListMenu.Controls.Add(testMenu);

                testMenu = new MenuItemTemplate("Link Workspace", "/_layouts/epmlive/images/linkworkspace.gif");
                testMenu.ClientOnClickScript = "javascript:linkworkspace('%NAME%');";
                propertyNameListMenu.Controls.Add(testMenu);

                testMenu = new MenuItemTemplate("Unlink Workspace", "/_layouts/epmlive/images/unlinkworkspace.gif");
                testMenu.ClientOnClickScript = "javascript:if(confirm('Are you sure you want to unlink that workspace?')){location.href='epubstatus.aspx?action=unlink&projectid=%NAME%';}";
                propertyNameListMenu.Controls.Add(testMenu);

                testMenu = new MenuItemTemplate("View Publish Log", "/_layouts/images/txt16.gif");
                testMenu.ClientOnClickNavigateUrl = "eviewlog.aspx?projectid=%NAME%";
                propertyNameListMenu.Controls.Add(testMenu);

                this.Controls.Add(propertyNameListMenu);

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    using (var connection =
                        new SqlConnection(CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id)))
                    {
                        connection.Open();
                        if (!string.IsNullOrWhiteSpace(action))
                        {
                            switch (action)
                            {
                                case "delete":
                                    using (var command = new SqlCommand(
                                        "DELETE FROM publishercheck where projectguid=@projectguid",
                                        connection))
                                    {
                                        command.Parameters.AddWithValue("@projectguid", Request["projectid"]);
                                        command.ExecuteNonQuery();
                                    }
                                    break;
                                case "unlink":
                                    using (var command = new SqlCommand(
                                        "UPDATE publishercheck set weburl='',webguid=NULL where projectguid=@projectguid",
                                        connection))
                                    {
                                        command.Parameters.AddWithValue("@projectguid", Request["projectid"]);
                                        command.ExecuteNonQuery();
                                    }
                                    break;
                                default:
                                    DiagTrace.TraceError($"Unexpected action '{action}'.");
                                    break;
                            }

                            Response.Redirect($"{SPContext.Current.Web.Url}/_layouts/epmlive/epubstatus.aspx");
                        }

                        var dataSet = new DataSet();
                        using (var command =
                            new SqlCommand("select * from vwGetProjectStatus order by projectname", connection))
                        {
                            using (var adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dataSet);
                            }
                        }

                        GvItems.DataSource = dataSet;
                        GvItems.DataBind();
                    }
                });
            }
            catch (Exception exception)
            {
                DiagTrace.TraceError(exception.ToString());
                Response.Write($"Error: {exception.Message}");
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
