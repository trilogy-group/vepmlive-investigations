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

namespace EPMLiveCore
{
    public partial class tpsetup : System.Web.UI.Page
    {

        protected Panel pnlFeature;
        protected LinkButton lnkButton;
        protected Panel pnlMain;
        protected ListBox lstUsed;
        protected ListBox lstAvailable;
        protected Button btnAdd;
        protected Button btnDelete;
        protected GridView GridView1;
        protected GridView GridView2;
        protected Panel pnlAdmin;
        protected HyperLink hlAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;



                string url = "";

                url = CoreFunctions.getConfigSetting(web, "EPMLiveTimePhasedURL").Trim();

                if (url != "" && url.ToLower() != web.Url.ToLower())
                {
                    pnlAdmin.Visible = true;
                    hlAdmin.NavigateUrl = url + "/_layouts/epmlive/tpsetup.aspx";
                    pnlMain.Visible = false;
                }
                else
                {

                    bool failed = false;

                    try
                    {
                        SPList list = web.Lists["EPMLivePeriods"];
                    }
                    catch { failed = true; }
                    try
                    {

                        SPList list = web.Lists["EPMLiveValueTypes"];
                    }
                    catch { failed = true; }
                    try
                    {

                        SPList list = web.Lists["EPMLiveOutlineCodes"];
                    }
                    catch { failed = true; }

                    if (failed)
                    {
                        pnlMain.Visible = false;
                        pnlFeature.Visible = true;
                    }
                    else
                    {
                        loadValueTypes(web);
                        loadOutlineCodes(web);
                        loadPeriods(web);
                    }
                }

            }
        }

        private void loadPeriods(SPWeb web)
        {
            SPList list = web.Lists["EPMLivePeriods"];

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("start");
            dt.Columns.Add("end");
            dt.Columns.Add("item_id");
            dt.Columns.Add("capacity");

            foreach (SPListItem li in list.Items)
            {
                dt.Rows.Add(new string[] { li.Title, DateTime.Parse(li["StartDate"].ToString()).ToShortDateString(), DateTime.Parse(li["EndDate"].ToString()).ToShortDateString(), li.UniqueId.ToString(), li["Capacity"].ToString()});
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        private void loadOutlineCodes(SPWeb web)
        {
            SPList list = web.Lists["EPMLiveOutlineCodes"];

            DataTable dt = new DataTable();
            dt.Columns.Add("type");
            dt.Columns.Add("field");
            dt.Columns.Add("disp");
            dt.Columns.Add("item_id");

            foreach (SPListItem li in list.Items)
            {
                dt.Rows.Add(new string[] { li["OutlineCodeType"].ToString(), li.Title, li["DisplayName"].ToString(), li.UniqueId.ToString() });
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void loadValueTypes(SPWeb web)
        {
            ArrayList arrAvail = new ArrayList();
            ArrayList arrUsed = new ArrayList();

            arrAvail.Add("Cost");
            arrAvail.Add("ActualCost");
            arrAvail.Add("BaselineCost");
            arrAvail.Add("Work");
            arrAvail.Add("ActualWork");
            arrAvail.Add("BaselineWork");

            SPList list = web.Lists["EPMLiveValueTypes"];

            foreach(SPListItem li in list.Items)
            {
                if (arrAvail.Contains(li.Title))
                {
                    arrUsed.Add(li.Title);
                    arrAvail.Remove(li.Title);
                }
            }

            lstAvailable.Items.Clear();
            lstUsed.Items.Clear();

            foreach (string s in arrAvail)
            {
                lstAvailable.Items.Add(s);
            }

            foreach (string s in arrUsed)
            {
                lstUsed.Items.Add(s);
            }

        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            try
            {
                site.Features.Add(new Guid("25aec3aa-cf9d-4c50-9a29-2c0784781769"), true);
            }
            catch { }

            SPWeb web = SPContext.Current.Web;
            try
            {
                web.Features.Add(new Guid("df1358d7-453e-4f41-8e24-fd09c0bd676c"), true);
            }
            catch { }
            string url = web.ServerRelativeUrl;

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/tpsetup.aspx?rnd=" + Guid.NewGuid().ToString(), Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstAvailable.SelectedIndex != -1)
            {

                SPWeb web = SPContext.Current.Web;

                SPList list = web.Lists["EPMLiveValueTypes"];

                SPListItem li = list.Items.Add();
                li["Title"] = lstAvailable.SelectedItem.Text;
                li.Update();

                loadValueTypes(web);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstUsed.SelectedIndex != -1)
            {

                SPWeb web = SPContext.Current.Web;

                SPList list = web.Lists["EPMLiveValueTypes"];

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>" + lstUsed.SelectedItem.Text + "</Value></Eq></Where>";

                ArrayList arrItems = new ArrayList();

                foreach (SPListItem li in list.GetItems(query))
                {
                    arrItems.Add(li);
                }

                foreach (SPListItem li in arrItems)
                {
                    li.Delete();
                }

                loadValueTypes(web);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;
                web.Site.CatchAccessDeniedException = false;
                string id = e.CommandArgument.ToString();

                SPList list = web.Lists["EPMLiveOutlineCodes"];
                SPListItem li = list.Items[new Guid(id)];

                deleteWebPeriod(web, li.Title, web.Url);

                li.Delete();

                loadOutlineCodes(web);
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;
                web.Site.CatchAccessDeniedException = false;
                string id = e.CommandArgument.ToString();

                SPList list = web.Lists["EPMLivePeriods"];
                SPListItem li = list.Items[new Guid(id)];

                deleteWebPeriod(web, li.Title, web.Url);

                li.Delete();

                loadPeriods(web);
            }
        }

        private void deleteWebPeriod(SPWeb web, string period, string url)
        {
            try
            {
                if (CoreFunctions.getConfigSetting(web, "EPMLiveTimePhasedURL").ToLower() == url.ToLower())
                {
                    SPList list = web.Lists["EPMLiveTimePhased"];
                    SPField f = list.Fields.GetFieldByInternalName(period.Replace(" ", "_x0020_"));
                    f.Delete();
                }
            }
            catch { }
            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    deleteWebPeriod(w, period, url);
                }
                catch { }
                w.Close();
            }
        }

        

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete " +
                    DataBinder.Eval(e.Row.DataItem, "disp") + "?')");

                l = (LinkButton)e.Row.FindControl("LinkButton2");
                l.Attributes.Add("onclick", "javascript:editOC('" + DataBinder.Eval(e.Row.DataItem, "item_id") + "');return false;");
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete " +
                    DataBinder.Eval(e.Row.DataItem, "name") + "? ALL DATA WILL BE LOST!')");
            }
        }
    }
}