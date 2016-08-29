using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class IntegrationList : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuTemplate propertyNameListMenu = new MenuTemplate();

            propertyNameListMenu.ID = "PropertyNameListMenu";



            MenuItemTemplate testMenu = new MenuItemTemplate("Edit Connection", "/_layouts/epmlive/images/integration/editcon.png");

            testMenu.ClientOnClickNavigateUrl = "connection.aspx?intlistid=%INTLISTID%&LIST=" + Request["List"];

            propertyNameListMenu.Controls.Add(testMenu);

            


            MenuItemTemplate testMenu2 = new MenuItemTemplate("Edit Properties", "/_layouts/images/edit.gif");

            testMenu2.ClientOnClickNavigateUrl = "properties.aspx?intlistid=%INTLISTID%&LIST=" + Request["List"];

            propertyNameListMenu.Controls.Add(testMenu2);



            MenuItemTemplate testMenu3 = new MenuItemTemplate("Edit Columns", "/_layouts/epmlive/images/integration/editcols.png");

            testMenu3.ClientOnClickNavigateUrl = "columns.aspx?intlistid=%INTLISTID%&LIST=" + Request["List"];

            propertyNameListMenu.Controls.Add(testMenu3);


            MenuItemTemplate testMenu4 = new MenuItemTemplate("View Log", "/_layouts/epmlive/images/integration/log.png");

            testMenu4.ClientOnClickNavigateUrl = "log.aspx?intlistid=%INTLISTID%&LIST=" + Request["List"];

            propertyNameListMenu.Controls.Add(testMenu4);



            MenuItemTemplate testMenu5 = new MenuItemTemplate("Delete Integration", "/_layouts/images/delete.gif");

            testMenu5.ClientOnClickScript = "DeleteIntegration('%INTLISTID%');";

            propertyNameListMenu.Controls.Add(testMenu5);



            this.Controls.Add(propertyNameListMenu);

            API.Integration.IntegrationCore integration = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);

            
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                gvPlans.DataSource = integration.GetIntegrationsForList(new Guid(Request["List"]));
                gvPlans.DataBind();
            });
        }
    }
}
