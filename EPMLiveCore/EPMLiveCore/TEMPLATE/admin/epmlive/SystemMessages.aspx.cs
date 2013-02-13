using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveCore.Layouts.EPMLiveCore
{
    public partial class SystemMessages : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                MenuTemplate propertyNameListMenu = new MenuTemplate();
                propertyNameListMenu.ID = "PropertyNameListMenu";
                MenuItemTemplate testMenu = new MenuItemTemplate("Edit Message", "/_layouts/images/edit.gif");
                testMenu.ClientOnClickNavigateUrl = "EditMessage.aspx?id=%NAME%";

                propertyNameListMenu.Controls.Add(testMenu);

                this.Controls.Add(propertyNameListMenu);


                


            }
        }
    }
}
