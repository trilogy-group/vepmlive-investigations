using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class ManageFragment : LayoutsPageBase
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ScriptLink.Register(Page, "/epmlive/javascripts/libraries/jquery.min.js", false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    FillMyFragmentsGrid();
                    FillPublicFragmentsGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string fragmentName = string.Empty;
                SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
                if (plannerFragmentList != null)
                {
                    foreach (GridViewRow gvrow in gridMyFragments.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)gvrow.FindControl("chkSelect");
                        if (chk != null && chk.Checked)
                        {
                            SPContext.Current.Web.AllowUnsafeUpdates = true;
                            Label lblID = (Label)gvrow.FindControl("lblID");
                            if (lblID != null)
                            {
                                SPListItem fragment = plannerFragmentList.GetItemById(Convert.ToInt32(lblID.Text));
                                fragment.Recycle();
                                plannerFragmentList.Update();
                            }
                        }
                    }

                    if (SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                    {
                        foreach (GridViewRow gvrow in gridPublicFragments.Rows)
                        {
                            HtmlInputCheckBox chk = (HtmlInputCheckBox)gvrow.FindControl("chkSelect");
                            if (chk != null && chk.Checked)
                            {
                                SPContext.Current.Web.AllowUnsafeUpdates = true;
                                Label lblID = (Label)gvrow.FindControl("lblID");
                                if (lblID != null)
                                {
                                    SPListItem fragment = plannerFragmentList.GetItemById(Convert.ToInt32(lblID.Text));
                                    fragment.Recycle();
                                    plannerFragmentList.Update();
                                }
                            }
                        }
                    }
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closeManageFragmentPopup", "<script language='javascript' type='text/javascript'>closeManageFragmentPopup('Fragment(s) deleted successfully!');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillMyFragmentsGrid()
        {
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            SPQuery qryFilterPlanner = new SPQuery();

            string qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Title' /><FieldRef Name='Author' /></OrderBy><Where><And><And><Eq><FieldRef Name='Author' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Eq><Eq><FieldRef Name='PlannerID' /><Value Type='Text'>" + Convert.ToString(Request["PlannerID"]) + "</Value></Eq></And><Eq><FieldRef Name='FragmentType' /><Value Type='Choice'>Private</Value></Eq></And></Where>";

            if (plannerFragmentList != null)
            {
                qryFilterPlanner.Query = qryFilter;

                SPListItemCollection fragmentItems = plannerFragmentList.GetItems(qryFilterPlanner);
                if (fragmentItems != null && fragmentItems.Count > 0)
                {
                    gridMyFragments.DataSource = fragmentItems.GetDataTable();
                    gridMyFragments.DataBind();
                }
            }
        }

        private void FillPublicFragmentsGrid()
        {
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            SPQuery qryFilterPlanner = new SPQuery();
            string qryFilter = string.Empty;

            if (SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Title' /><FieldRef Name='Author' /></OrderBy><Where><And><Eq><FieldRef Name='FragmentType' /><Value Type='Choice'>Public</Value></Eq><Eq><FieldRef Name='PlannerID' /><Value Type='Text'>" + Convert.ToString(Request["PlannerID"]) + "</Value></Eq></And></Where>";
            else
                qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Title' /><FieldRef Name='Author' /></OrderBy><Where><And><And><Eq><FieldRef Name='FragmentType' /><Value Type='Choice'>Public</Value></Eq><Eq><FieldRef Name='PlannerID' /><Value Type='Text'>" + Convert.ToString(Request["PlannerID"]) + "</Value></Eq></And><Eq><FieldRef Name='Author' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Eq></And></Where>";

            if (plannerFragmentList != null)
            {
                qryFilterPlanner.Query = qryFilter;

                SPListItemCollection fragmentItems = plannerFragmentList.GetItems(qryFilterPlanner);
                if (fragmentItems != null && fragmentItems.Count > 0)
                {
                    gridPublicFragments.DataSource = fragmentItems.GetDataTable(); ;
                    gridPublicFragments.DataBind();
                }
            }
        }
    }
}
