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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    FillGrid();
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
                    foreach (GridViewRow gvrow in gridFragments.Rows)
                    {
                        HtmlInputCheckBox chk = (HtmlInputCheckBox)gvrow.FindControl("chkSelect");
                        if (chk != null & chk.Checked)
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
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closeManageFragmentPopup", "<script language='javascript' type='text/javascript'>closeManageFragmentPopup('Fragment(s) deleted successfully!');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gridFragments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                FillGrid();
                gridFragments.PageIndex = e.NewPageIndex;
                gridFragments.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillGrid()
        {
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            SPQuery qryFilterPlanner = new SPQuery();
            string qryFilter = string.Empty;

            if (plannerFragmentList != null)
            {
                if (SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                    qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Author' /><FieldRef Name='FragmentType' /></OrderBy><Where><Eq><FieldRef Name='PlannerID' /><Value Type='Text'>" + Convert.ToString(Request["PlannerID"]) + "</Value></Eq></Where>";
                else
                    qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Author' /><FieldRef Name='FragmentType' /></OrderBy><Where><And><Eq><FieldRef Name='Author' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Eq><Eq><FieldRef Name='PlannerID' /><Value Type='Text'>" + Convert.ToString(Request["PlannerID"]) + "</Value></Eq></And></Where>";

                qryFilterPlanner.Query = qryFilter;

                SPListItemCollection fragmentItems = plannerFragmentList.GetItems(qryFilterPlanner);
                if (fragmentItems != null && fragmentItems.Count > 0)
                {
                    gridFragments.DataSource = fragmentItems.GetDataTable(); ;
                    gridFragments.DataBind();
                }
            }
        }
    }
}
