using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Collections;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ListLookupConfig : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuTemplate propertyNameListMenu = new MenuTemplate();

            propertyNameListMenu.ID = "PropertyNameListMenu";

            MenuItemTemplate testMenu = new MenuItemTemplate("Edit Lookup", "/_layouts/images/edit.gif");

            testMenu.ClientOnClickNavigateUrl = "ListLookupEdit.aspx?field=%NAME%&List=" + Request["List"];

            propertyNameListMenu.Controls.Add(testMenu);

            //MenuItemTemplate testMenu2 = new MenuItemTemplate("Delete Planner", "/_layouts/images/delete.gif");

            //testMenu2.ClientOnClickNavigateUrl = "ListLookupEdit.aspx?delete=%NAME%&List=" + Request["List"];

            //propertyNameListMenu.Controls.Add(testMenu2);

            this.Controls.Add(propertyNameListMenu);


            DataTable dt = new DataTable();
            dt.Columns.Add("displayname");
            dt.Columns.Add("internalname");
            dt.Columns.Add("enabled");
            dt.Columns.Add("style");
            dt.Columns.Add("cascading");
            dt.Columns.Add("security");

            SPList list = Web.Lists[new Guid(Request["List"])];

            GridGanttSettings gSettings = new GridGanttSettings(list);
            string[] LookupArray = gSettings.Lookups.Split('|');

            Hashtable hshLookups = new Hashtable();
            foreach(string sLookup in LookupArray)
            {
                if(sLookup != "")
                {
                    string[] sLookupInfo = sLookup.Split('^');
                    hshLookups.Add(sLookupInfo[0], sLookupInfo);
                }
            }

            foreach(SPField field in list.Fields)
            {
                if(field.Type == SPFieldType.Lookup && !field.Hidden && field.Reorderable)
                {
                    SPFieldLookup lookup = (SPFieldLookup)field;
                    if(lookup.LookupList != "")
                    {

                        string display = field.Title;
                        string internalname = field.InternalName;
                        string enabled = "No";
                        string style = "";
                        string cascading = "";
                        string security = "";

                        if(hshLookups.Contains(field.InternalName))
                        {
                            string []sLookupInfo = (string[])hshLookups[field.InternalName];
                            enabled = "Yes";
                            try
                            {
                                if(sLookupInfo[1] == "2")
                                    style = "Auto Complete";
                                else
                                    style = "Standard";
                            }
                            catch { style = "Standard"; }

                            try
                            {
                                if(sLookupInfo[2] != "")
                                    cascading = "Yes";
                                else
                                    cascading = "No";
                            }
                            catch { cascading = "No"; }

                            try
                            {
                                if(sLookupInfo[4].ToLower() == "true")
                                    security = "Yes";
                                else
                                    security = "No";
                            }
                            catch { security = "No"; }
                        }

                        dt.Rows.Add(new object[] { display, internalname, enabled, style, cascading, security });

                    }
                }
            }

            gvPlans.DataSource = dt;
            gvPlans.DataBind();
        }
    }
}
