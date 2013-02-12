using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class ManageApps : LayoutsPageBase
    {
        protected string sWebUrl;
        protected string sFullWebUrl;

        private string GetProperty(SPList oList, SPListItem oListItem, string Property)
        {
            try
            {
                SPField oField = oList.Fields.GetFieldByInternalName(Property);
                
                if(oField.Type == SPFieldType.DateTime)
                    return DateTime.Parse(oListItem[oField.Id].ToString()).ToShortDateString();
                else if(oField.Type == SPFieldType.User)
                {
                    SPFieldUserValue uv = new SPFieldUserValue(oList.ParentWeb, oListItem[oField.Id].ToString());
                    return uv.LookupValue;
                }
                else
                    return oListItem[oField.Id].ToString();
            }
            catch { }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            SPWeb oWeb = SPContext.Current.Web;

            sWebUrl = (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl;
            sFullWebUrl = oWeb.Url;

            SPList oList = oWeb.Lists.TryGetList("Installed Applications");
            if(oList != null)
            {
                LoadInstalled(oWeb, oList);
            }

        }

        private void LoadInstalled(SPWeb  oWeb, SPList oList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("Icon");
            dt.Columns.Add("EXTID");
            dt.Columns.Add("Version");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Default");
            dt.Columns.Add("InstallDate");
            dt.Columns.Add("InstalledBy");

            SPQuery query = new SPQuery();
            query.Query = "<Where><And><IsNotNull><FieldRef Name='EXTID'/></IsNotNull><Or><Eq><FieldRef Name='Status'/><Value Type='Text'>Installed</Value></Eq><Eq><FieldRef Name='Status'/><Value Type='Text'>Install Failed</Value></Eq></Or></And></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            foreach(SPListItem li in oList.GetItems(query))
            {
                string icon = GetProperty(oList, li, "Icon");
                try
                {
                    icon = new SPFieldUrlValue(icon).Url;
                }
                catch { }

                dt.Rows.Add(new object[] { li.ID.ToString(), li["Title"].ToString(), GetProperty(oList, li, "Description"), icon, GetProperty(oList, li, "EXTID"), GetProperty(oList, li, "AppVersion"), GetProperty(oList, li, "Visible"), GetProperty(oList, li, "Default"), GetProperty(oList, li, "Created"), GetProperty(oList, li, "Author") });
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow dr = ((DataRowView)e.Row.DataItem).Row;

                //if(dr["Icon"].ToString() == "")
                //{
                //    e.Row.Cells[0].Text = "<img src=\"/_layouts/epmlive/images/blanktemplate.png\">";
                //}
                //else
                //{
                //    e.Row.Cells[0].Text = "<img src=\"" + dr["Icon"].ToString() + "\">";
                //}

                e.Row.Cells[0].Text = "<b>" + dr["Title"].ToString() + "</b><br>" + dr["Description"].ToString();

            }
        }

        protected string UnInstButton(object id)
        {
            return "Uninstall('" + id.ToString() + "');return false;";
        }

    }
}
