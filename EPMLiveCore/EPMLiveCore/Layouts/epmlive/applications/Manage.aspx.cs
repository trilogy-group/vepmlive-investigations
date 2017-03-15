using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using EPMLiveCore.API;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class Manage : LayoutsPageBase
    {
        protected string sWebUrl;
        protected string sFullWebUrl;

        private string GetProperty(SPList oList, SPListItem oListItem, string Property)
        {
            try
            {
                SPField oField = oList.Fields.GetFieldByInternalName(Property);
                return oListItem[oField.Id].ToString();
            }
            catch { }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if (act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            SPWeb oWeb = SPContext.Current.Web;

            sWebUrl = (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl;
            sFullWebUrl = oWeb.Url;

            SPList oList = oWeb.Lists.TryGetList("Installed Applications");
            if (oList != null)
            {
                LoadCustom(oWeb, oList);
            }
        }

        private void LoadCustom(SPWeb oWeb, SPList oList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SortOrder");
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("Icon");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Default");

            SPQuery query = new SPQuery();
            query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            foreach (SPListItem li in oList.GetItems(query))
            {
                string icon = GetProperty(oList, li, "Icon");
                try
                {
                    icon = new SPFieldUrlValue(icon).Url;
                }
                catch { }

                var sortOrder = GetSortOrder(li.ID.ToString(), oWeb, oList);

                if (string.IsNullOrEmpty(sortOrder))
                {
                    SetCustomOrder(oList.GetItems(query), oWeb, oList);
                }

                dt.Rows.Add(new object[] { sortOrder, li.ID.ToString(), li["Title"].ToString(), GetProperty(oList, li, "Description"), icon, GetProperty(oList, li, "Visible"), GetProperty(oList, li, "Default") });
            }

            dt.DefaultView.Sort = "SortOrder";
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void SetCustomOrder(SPListItemCollection list, SPWeb oWeb, SPList oList)
        {
            var customOrder = new Dictionary<string, string>();
            var counter = 1;

            foreach (SPListItem item in list)
            {
                customOrder.Add(item.ID.ToString(), counter.ToString());
                counter++;
            }

            //only do this if get returns 0
            MyPersonalization.SetPersonalizations(customOrder, oWeb.CurrentUser.ID.ToString(), 0, oList.ID, oWeb.ID, oWeb.Site.ID, oWeb.Site.Url);
        }

        private void UpdateCustomOrder(string key, string newValue, SPWeb oWeb, SPList oList)
        {
            var updateValues = new Dictionary<string, string> { { key, newValue } };

            //MyPersonalization.SetPersonalizations(updateValues, oWeb.CurrentUser.ID.ToString(), 0, oList.ID, oWeb.ID, oWeb.Site.ID, oWeb.Site.Url);
        }

        private string GetSortOrder(string id, SPWeb oWeb, SPList oList)
        {
            return MyPersonalization.GetPersonalizationValue(id, oWeb, oList);
        }

        protected void GridView_PreRender(object sender, EventArgs e)
        {
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow dr = ((DataRowView)e.Row.DataItem).Row;

                if (dr["Icon"].ToString() == "")
                {
                    e.Row.Cells[0].Text = "<img src=\"/_layouts/epmlive/images/blanktemplate.png\">";
                }
                else
                {
                    e.Row.Cells[0].Text = "<img src=\"" + dr["Icon"].ToString() + "\">";
                }

                e.Row.Cells[1].Text = "<b>" + dr["Title"].ToString() + "</b><br>" + dr["Description"].ToString();

            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Del":

                    break;
                default:
                    break;
            };
        }

        [WebMethod]
        public static void UpdateCommunitiesOrder(string message)
        {
            var serializer = new JavaScriptSerializer();
            var dictionary = serializer.Deserialize<Dictionary<string, string>>(message);

            SPWeb oWeb = SPContext.Current.Web;
            SPList oList = oWeb.Lists.TryGetList("Installed Applications");

            MyPersonalization.UpdatePersonalizationValue(dictionary, oWeb.CurrentUser.ID.ToString(), oList.ID, oWeb.ID, oWeb.Site.ID, oWeb.Site.Url);
        }

        [WebMethod]
        public static void DeleteCommunitiesOrder(string key)
        {
            SPWeb oWeb = SPContext.Current.Web;
            SPList oList = oWeb.Lists.TryGetList("Installed Applications");

            MyPersonalization.DeletePersonalization(key, oWeb.CurrentUser.ID.ToString(), oList.ID, oWeb.ID, oWeb.Site.ID, oWeb.Site.Url);
        }

        protected string DelButton(object id)
        {
            return "Del('" + id.ToString() + "');return false;";
        }

        protected string EditButton(object id)
        {
            return "Edit('" + id.ToString() + "');return false;";
        }

        protected string ManageApps(object id)
        {
            return "ManageApps('" + id.ToString() + "');return false;";
        }

        protected string QLButton(object id)
        {
            return "EditQL('" + id.ToString() + "');return false;";
        }

        protected string TNButton(object id)
        {
            return "EditTN('" + id.ToString() + "');return false;";
        }
    }
}
