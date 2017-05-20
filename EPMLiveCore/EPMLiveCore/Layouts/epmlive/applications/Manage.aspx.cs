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
using System.Web.UI;
using System.Text.RegularExpressions;
using EPMLiveCore.Controls.Navigation;
using EPMLiveCore.Infrastructure;
using static EPMLiveCore.Services.DataContracts.SocialEngine.SEActivities;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class Manage : LayoutsPageBase
    {
        protected string sWebUrl;
        protected string sFullWebUrl;
        private const string INSTALLED_APPS = "Installed Applications";

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

            if (!Page.IsPostBack)
            {
                CheckForQuickLaunchField(SPContext.Current.Web);
                var dt = GetDataTable();

                if (dt != null)
                    LoadCustom(dt);
            }
            else
            {
                HandleNAcase();
            }
        }

        private void CheckForQuickLaunchField(SPWeb spWeb)
        {
            spWeb.AllowUnsafeUpdates = true;

            SPList list = spWeb.Lists.TryGetList(INSTALLED_APPS);
            if (list != null)
            {
                if (!list.Fields.ContainsFieldWithInternalName("QuickLaunchOrder"))
                {
                    SPFieldNumber fldQuickLaunchOrder = (SPFieldNumber)list.Fields.CreateNewField(SPFieldType.Number.ToString(), "QuickLaunchOrder");

                    fldQuickLaunchOrder.Title = "QuickLaunchOrder";
                    fldQuickLaunchOrder.DisplayFormat = SPNumberFormatTypes.NoDecimal;
                    fldQuickLaunchOrder.Indexed = false;
                    list.Fields.Add(fldQuickLaunchOrder);
                    list.Update();

                    fldQuickLaunchOrder = list.Fields["QuickLaunchOrder"] as SPFieldNumber;
                    fldQuickLaunchOrder.Title = "QuickLaunchOrder";
                    fldQuickLaunchOrder.ShowInListSettings = true;
                    fldQuickLaunchOrder.DefaultValue = "1000";
                    fldQuickLaunchOrder.ShowInDisplayForm = true;
                    fldQuickLaunchOrder.ShowInNewForm = true;
                    fldQuickLaunchOrder.ShowInEditForm = true;
                    fldQuickLaunchOrder.Hidden = false;
                    fldQuickLaunchOrder.Update();

                    SPView tdefaultList = list.DefaultView;
                    tdefaultList.ViewFields.Add("QuickLaunchOrder");
                    tdefaultList.Update();

                    int index = 0;
                    SPQuery query = new SPQuery();
                    query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

                    foreach (SPListItem li in list.GetItems(query))
                    {
                        if (spWeb.ParentWeb == null && li["Title"].ToString().Equals("Global My Workplace", StringComparison.InvariantCultureIgnoreCase))
                            li["QuickLaunchOrder"] = "-1";
                        else
                            li["QuickLaunchOrder"] = index++;
                        li.Update();
                    }
                }
            }

            spWeb.AllowUnsafeUpdates = false;
        }

        private DataTable GetDataTable()
        {
            DataTable dt = null;
            SPWeb oWeb = SPContext.Current.Web;

            sWebUrl = (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl;
            sFullWebUrl = oWeb.Url;

            SPList oList = oWeb.Lists.TryGetList("Installed Applications");

            if (oList != null)
            {
                dt = new DataTable();

                dt.Columns.Add("QuickLaunchOrder");
                dt.Columns.Add("ID");
                dt.Columns.Add("Title");
                dt.Columns.Add("Description");
                dt.Columns.Add("Icon");
                dt.Columns.Add("Visible");
                dt.Columns.Add("Default");

                SPQuery query = new SPQuery();
                query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='QuickLaunchOrder'/></OrderBy>";

                Dictionary<string, int> dictOrder = new Dictionary<string, int>();

                int index = 0;
                foreach (SPListItem li in oList.GetItems(query))
                {
                    string icon = GetProperty(oList, li, "Icon");
                    try
                    {
                        icon = new SPFieldUrlValue(icon).Url;
                    }
                    catch { }

                    index++;
                    if (GetProperty(oList, li, "QuickLaunchOrder") != "" && GetProperty(oList, li, "QuickLaunchOrder") != "-1"
                        && GetProperty(oList, li, "QuickLaunchOrder") != "1000")
                        dictOrder[li["Title"].ToString()] = int.Parse(GetProperty(oList, li, "QuickLaunchOrder"));
                    else if (GetProperty(oList, li, "QuickLaunchOrder") == "1000")
                        dictOrder[li["Title"].ToString()] = index;

                    dt.Rows.Add(new object[] { GetProperty(oList, li, "QuickLaunchOrder"), li.ID.ToString(), li["Title"].ToString(), GetProperty(oList, li, "Description"), icon, GetProperty(oList, li, "Visible"), GetProperty(oList, li, "Default") });
                }

                ViewState["dictOrder"] = dictOrder;
            }

            return dt;
        }

        private void LoadCustom(DataTable dt)
        {
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
        }

        protected void lnkSaveOrder_OnClicked(object sender, EventArgs e)
        {
            SPWeb oWeb = SPContext.Current.Web;
            SPList oList = oWeb.Lists.TryGetList("Installed Applications");

            foreach (GridViewRow dRow in GridView1.Rows)
            {
                DropDownList ddlOrder = dRow.FindControl("ddlOrder") as DropDownList;

                if (ddlOrder == null || ddlOrder.Items.Count == 0 || ddlOrder.SelectedValue == "") continue;

                int rowIndex = int.Parse(ddlOrder.SelectedValue);
                string title = StripHTML(dRow.Cells[1].Text);

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + title + "</Value></Eq></Where>";

                SPListItemCollection items = oList.GetItems(query);
                if (items != null && items.Count > 0)
                {
                    SPListItem li = oList.GetItems(query)[0];
                    li["QuickLaunchOrder"] = ddlOrder.SelectedValue;
                    li.Update();
                }
            }

            SPSite data = new SPSite(SPContext.Current.Site.ID);
            CacheStore.Current.RemoveSafely(Web.Url, new Infrastructure.CacheStoreCategory(oWeb).Navigation);
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

                DropDownList ddl = e.Row.FindControl("ddlOrder") as DropDownList;
                if (dr["QuickLaunchOrder"] != null && dr["QuickLaunchOrder"].ToString() == "-1")
                {
                    e.Row.Cells[2].Text = "N/A";
                    ddl.Visible = false;
                }
                else
                {
                    var filtered = dr.Table.Select("QuickLaunchOrder <> '-1'");
                    for (int i = 0; i < filtered.Length; i++)
                    {
                        ddl.Items.Add((i + 1).ToString());
                    }

                    int numOfExcluededRows = dr.Table.Rows.Count - filtered.Length;
                    ddl.SelectedValue = (e.Row.RowIndex + 1 - numOfExcluededRows).ToString();

                    var dictOrder = ViewState["dictOrder"] as Dictionary<string, int>;
                    dictOrder[StripHTML(e.Row.Cells[1].Text)] = e.Row.RowIndex + 1 - numOfExcluededRows;
                    ViewState["dictOrder"] = dictOrder;
                }
            }

        }

        protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, int> dictOrder = ViewState["dictOrder"] as Dictionary<string, int>;

            DropDownList ddlOrders = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlOrders.NamingContainer;

            DataTable dt = GetDataTable();
            int oldIndex = dictOrder[StripHTML(row.Cells[1].Text)];

            int newIndex = int.Parse(ddlOrders.SelectedValue);
            dictOrder[StripHTML(row.Cells[1].Text)] = newIndex;

            foreach (GridViewRow dRow in GridView1.Rows)
            {
                if (dRow.RowIndex == row.RowIndex)
                    continue;

                DropDownList ddlOrder = dRow.FindControl("ddlOrder") as DropDownList;

                if (ddlOrder == null || ddlOrder.Items.Count == 0 || ddlOrder.SelectedValue == "") continue;

                int rowIndex = int.Parse(ddlOrder.SelectedValue);

                if (oldIndex > newIndex)
                {
                    if (rowIndex >= newIndex && rowIndex < oldIndex)
                    {
                        ddlOrder.SelectedValue = (rowIndex + 1).ToString();
                        dictOrder[StripHTML(dRow.Cells[1].Text)] = rowIndex + 1;
                    }
                }
                else
                {
                    if (rowIndex > oldIndex && rowIndex <= newIndex)
                    {
                        ddlOrder.SelectedValue = (rowIndex - 1).ToString();
                        dictOrder[StripHTML(dRow.Cells[1].Text)] = rowIndex - 1;
                    }
                }
            }

            ViewState["dictOrder"] = dictOrder;
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

        private void HandleNAcase()
        {
            foreach (GridViewRow dRow in GridView1.Rows)
            {
                DropDownList ddlOrder = dRow.FindControl("ddlOrder") as DropDownList;

                if (ddlOrder != null && ddlOrder.Items.Count == 0)
                {
                    ddlOrder.Visible = false;
                    dRow.Cells[2].Text = "N/A";
                }
            }
        }


        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
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
