using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Manage : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //==================================Integration Menu=================================

            MenuTemplate propertyNameListMenu = new MenuTemplate();
            propertyNameListMenu.ID = "IntegrationMenu";

            MenuItemTemplate testMenu = new MenuItemTemplate("Edit Connection", "/_layouts/epmlive/images/integration/editcon.png");
            testMenu.ClientOnClickNavigateUrl = "connection.aspx?intlistid=%INTLISTID%&LIST=%LISTID%&ret=Manage";
            propertyNameListMenu.Controls.Add(testMenu);

            MenuItemTemplate testMenu2 = new MenuItemTemplate("Edit Properties", "/_layouts/images/edit.gif");
            testMenu2.ClientOnClickNavigateUrl = "properties.aspx?intlistid=%INTLISTID%&LIST=%LISTID%&ret=Manage";
            propertyNameListMenu.Controls.Add(testMenu2);

            MenuItemTemplate testMenu3 = new MenuItemTemplate("Edit Columns", "/_layouts/epmlive/images/integration/editcols.png");
            testMenu3.ClientOnClickNavigateUrl = "columns.aspx?intlistid=%INTLISTID%&LIST=%LISTID%&ret=Manage";
            propertyNameListMenu.Controls.Add(testMenu3);

            MenuItemTemplate testMenu4 = new MenuItemTemplate("View Log", "/_layouts/epmlive/images/integration/log.png");
            testMenu4.ClientOnClickNavigateUrl = "log.aspx?intlistid=%INTLISTID%&LIST=%LISTID%&ret=Manage";
            propertyNameListMenu.Controls.Add(testMenu4);

            MenuItemTemplate testMenu5 = new MenuItemTemplate("Delete Integration", "/_layouts/images/delete.gif");
            testMenu5.ClientOnClickScript = "DeleteIntegration('%INTLISTID%');";
            propertyNameListMenu.Controls.Add(testMenu5);

            this.Controls.Add(propertyNameListMenu);
            //===================================================================================
            MenuTemplate propertyNameListMenu2 = new MenuTemplate();
            propertyNameListMenu2.ID = "IntegrationGroupMenu";

            MenuItemTemplate testMenu6 = new MenuItemTemplate("Add Integration", "/_layouts/images/add.gif");
            testMenu6.ClientOnClickNavigateUrl = "Add.aspx?LIST=%LISTID%&ret=Manage";
            propertyNameListMenu2.Controls.Add(testMenu6);

            MenuItemTemplate testMenu7 = new MenuItemTemplate("Edit Fields", "/_layouts/images/edit.gif");
            testMenu7.ClientOnClickScript = "EditFields('%LISTID%')";
            propertyNameListMenu2.Controls.Add(testMenu7);

            this.Controls.Add(propertyNameListMenu2);
            
            

            //===================================================================================
            SPMenuField colMenu = new SPMenuField();
            colMenu.HeaderText = "";
            colMenu.TextFields = "ListName"; // GroupName field, bind to a List column
            colMenu.MenuTemplateId = "IntegrationGroupMenu";
            colMenu.TokenNameAndValueFields = "LISTID=LIST_ID";
            colMenu.SortExpression = "ListName";
            colMenu.MenuFormat = MenuFormat.ArrowAlwaysVisible;
            
            gvIntegrations.GroupMenu = colMenu;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
                cn.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT     dbo.INT_MODULES.Title, dbo.INT_MODULES.Description, dbo.INT_MODULES.Icon, dbo.INT_LISTS.INT_LIST_ID, dbo.INT_LISTS.LIST_ID, dbo.INT_LISTS.ACTIVE
                    FROM         dbo.INT_MODULES INNER JOIN
                      dbo.INT_LISTS ON dbo.INT_MODULES.MODULE_ID = dbo.INT_LISTS.MODULE_ID where SITE_ID=@siteid", cn);
                cmd.Parameters.AddWithValue("@siteid", Web.Site.ID);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                dt.Columns.Add("ListName");

                Hashtable hshLists = new Hashtable();
                ArrayList arrExists = new ArrayList();
                ArrayList arrIgnore = new ArrayList();

                foreach (SPList list in Web.Lists)
                {
                    if (!list.Hidden)
                    {
                        hshLists.Add(list.ID, list.Title);
                    }

                    if(bIsSystemList(list.Title) || list.BaseType == SPBaseType.DocumentLibrary)
                    {
                        arrIgnore.Add(list.ID);
                    }
                }

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        Guid ListId = new Guid(dr["LIST_ID"].ToString());

                        if (hshLists.Contains(ListId))
                        {
                            dr["ListName"] = hshLists[ListId].ToString();
                            arrExists.Add(ListId);
                        }
                    }
                    catch { }
                }

                foreach (DictionaryEntry de in hshLists)
                {
                    if (!arrExists.Contains(de.Key) && !arrIgnore.Contains(de.Key))
                    {
                        DataRow dr = dt.NewRow();
                        dr["List_Id"] = de.Key;
                        dr["ListName"] = de.Value;
                        dr["Title"] = "No Integrations";

                        dt.Rows.Add(dr);
                    }
                }

                gvIntegrations.DataSource = ds;
                gvIntegrations.DataBind();

                cn.Close();
            });
        }

        protected bool bIsSystemList(string list)
        {
            switch (list)
            {
                case "Roles":
                case "My Timesheet":
                case "My Work":
                case "Department":
                case "Holiday Schedules":
                case "My Links":
                case "Work Hours":
                case "Non Work":
                case "Resource Center":
                case "Departments":
                case "Holidays":
                    return true;
            }
            return false;
        }


        protected void gvIntegrations_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow) //the header Row is also considered for data bound 
            {
                if (((DataRowView)e.Row.DataItem).Row["INT_LIST_ID"].ToString() == "")
                {
                    
                    e.Row.Cells[1].Controls.RemoveAt(0);
                    e.Row.Cells[1].Controls.Add(new System.Web.UI.LiteralControl("No Integrations"));
                }
            } 
        }
    }
}
