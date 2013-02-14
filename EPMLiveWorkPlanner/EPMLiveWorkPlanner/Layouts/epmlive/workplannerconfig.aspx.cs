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
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace EPMLiveWorkPlanner
{
    public partial class workplannerconfig : LayoutsPageBase
    {
        protected GridView GridView1;
        protected Panel pnlMain;

        protected TextBox txtAddField;
        protected DropDownList ddlAddCalculation;
        protected TextBox txtPercentComplete;
        protected Panel pnlAdmin;
        protected HyperLink hlAdmin;

        static WorkPlannerProperties wps;

        protected CheckBox chkEnableWP;
        protected DropDownList ddlProjectCenter;
        protected DropDownList ddlTaskCenter;
        protected CheckBox chkWPResPool;

        protected class WorkPlannerProperty
        {
            public string field;
            public string val;
        }

        protected class WorkPlannerProperties
        {

            SortedList hshProperties = new SortedList();

            public int count()
            {
                return hshProperties.Count;
            }
            public WorkPlannerProperties(string data)
            {
                if (data != null && data != "")
                {
                    string[] sProps = data.Split('\n');
                    foreach (string sProp in sProps)
                    {
                        string[] sField = sProp.Split('|');
                        hshProperties.Add(sField[0], sField[1]);
                    }
                }
            }
            public void set(string key, string val)
            {
                if (hshProperties.Contains(key))
                    hshProperties[key] = val;
                else
                    hshProperties.Add(key, val);
            }
            public void delete(string key)
            {
                if (hshProperties.Contains(key))
                    hshProperties.Remove(key);
            }
            public WorkPlannerProperty get(string key)
            {
                WorkPlannerProperty wp = null;
                if (hshProperties.Contains("key"))
                {
                    wp = new WorkPlannerProperty();
                    wp.field = key;
                    wp.val = hshProperties[key].ToString();
                }
                return wp;
            }
            public WorkPlannerProperty GetByIndex(int i)
            {
                WorkPlannerProperty wp = new WorkPlannerProperty();
                wp.field = hshProperties.GetKey(i).ToString();
                wp.val = hshProperties.GetByIndex(i).ToString();
                return wp;
            }
            public override string ToString()
            {
                string output = "";
                foreach (DictionaryEntry de in hshProperties)
                {
                    output += "\n" + de.Key + "|" + de.Value;
                }
                if (output.Length > 1)
                    output = output.Substring(1);
                return output;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                SPWeb web = SPContext.Current.Web;

                wps = new WorkPlannerProperties(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWorkPlannerFields"));

                Guid lWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);

                if (lWeb != web.ID)
                {
                    using(SPWeb w = web.Site.OpenWeb(lWeb))
                    {
                        pnlAdmin.Visible = true;
                        hlAdmin.NavigateUrl = w.ServerRelativeUrl + "/_layouts/epmlive/workplannerconfig.aspx";
                        pnlMain.Visible = false;
                    }
                }
                else
                {
                    loadFields(web);
                }

                //string url = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL").Trim();
                //bool showRes = false;
                //try
                //{
                //    if (url != "")
                //    {
                //        using (SPSite site = new SPSite(url))
                //        {
                //            site.CatchAccessDeniedException = false;
                //            using (SPWeb w = site.OpenWeb())
                //            {
                //                if (w.Url.ToLower() == url.ToLower())
                //                {
                //                    SPList list = w.Lists["Resources"];
                //                    if (list.ItemCount > 0)
                //                        showRes = true;
                //                }
                //            }
                //        }
                //    }
                //}
                //catch { }

                foreach (SPList list in web.Lists)
                {
                    if (!list.Hidden)
                    {
                        ddlProjectCenter.Items.Add(list.Title);
                        ddlTaskCenter.Items.Add(list.Title);
                    }
                }
                try
                {
                    ddlProjectCenter.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPProjectCenter");
                }
                catch { }
                try
                {
                    ddlTaskCenter.SelectedValue = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPTaskCenter");
                }
                catch { }
                try
                {
                    chkEnableWP.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPEnable"));
                }
                catch { }
                try
                {
                    chkWPResPool.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPUseResPool"));
                }
                catch { }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "";

            SPWeb web = SPContext.Current.Web;
            {
                url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

                if (txtPercentComplete.Text != "")
                {
                    wps.set("PercentComplete", txtPercentComplete.Text);
                }
                else
                {
                    wps.delete("PercentComplete");
                }

                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWorkPlannerFields", wps.ToString());
                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPProjectCenter", ddlProjectCenter.SelectedValue);
                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPTaskCenter", ddlTaskCenter.SelectedValue);
                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPEnable", chkEnableWP.Checked.ToString());
                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPMLiveWPUseResPool", chkWPResPool.Checked.ToString());
            }
            Response.Redirect(url + "/_layouts/settings.aspx");
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

            Response.Redirect(url + "/_layouts/epmlive/workplannerconfig.aspx?rnd=" + Guid.NewGuid().ToString());
        }

        protected void loadFields(SPWeb web)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("field");
            dt.Columns.Add("calc");
            dt.Columns.Add("item_id");



            for (int i = 0; i < wps.count(); i++)
            {
                WorkPlannerProperty wp = wps.GetByIndex(i);
                if (wp.field == "PercentComplete")
                {
                    try
                    {
                        txtPercentComplete.Text = wp.val;
                    }
                    catch { }
                }
                else
                    dt.Rows.Add(new string[] { wp.field, wp.val, wp.field });
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;

                wps.delete(e.CommandArgument.ToString());

                loadFields(web);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete " +
                    DataBinder.Eval(e.Row.DataItem, "field") + "?')");

                HyperLink link = (HyperLink)e.Row.FindControl("HyperLink1");
                link.NavigateUrl = "javascript:editField('" + DataBinder.Eval(e.Row.DataItem, "field") + "','" + DataBinder.Eval(e.Row.DataItem, "calc") + "','" + DataBinder.Eval(e.Row.DataItem, "item_id") + "')";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string id = "";
            try
            {
                id = Request["ctl00$PlaceHolderMain$hdnId"];
            }
            catch { }
            SPWeb web = SPContext.Current.Web;
            wps.set(txtAddField.Text.Replace(" ", "_x0020_"), ddlAddCalculation.SelectedValue);


            loadFields(web);

            txtAddField.Text = "";
        }
    }
}