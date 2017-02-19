﻿using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;

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

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);


            SPWeb oWeb = SPContext.Current.Web;

            sWebUrl = (oWeb.ServerRelativeUrl == "/") ? "" : oWeb.ServerRelativeUrl;
            sFullWebUrl = oWeb.Url;

            SPList oList = oWeb.Lists.TryGetList("Installed Applications");
            if(oList != null)
            {
                LoadCustom(oWeb, oList);
            }

        }

        private void LoadCustom(SPWeb oWeb, SPList oList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Description");
            dt.Columns.Add("Icon");
            dt.Columns.Add("Visible");
            dt.Columns.Add("Default");

            SPQuery query = new SPQuery();
            query.Query = "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            foreach(SPListItem li in oList.GetItems(query))
            {
                string icon = GetProperty(oList, li, "Icon");
                try
                {
                    icon = new SPFieldUrlValue(icon).Url;
                }
                catch { }

                dt.Rows.Add(new object[] { li.ID.ToString(), li["Title"].ToString(), GetProperty(oList, li, "Description"), icon, GetProperty(oList, li, "Visible"), GetProperty(oList, li, "Default") });
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow dr = ((DataRowView)e.Row.DataItem).Row;

                if(dr["Icon"].ToString() == "")
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
            switch(e.CommandName)
            {
                case "Del":

                    break;
                default:
                    break;
            };
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