using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class DeleteFragment : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                FillGrid();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
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
                        try
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
                        catch (Exception) { }
                    }
                }
            }
            Page.Response.Write("<script language='javascript' type='text/javascript'>window.frameElement.commonModalDialogClose(1, 1);</script>");
        }

        protected void gridFragments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillGrid();
            gridFragments.PageIndex = e.NewPageIndex;
            gridFragments.DataBind();
        }


        private void FillGrid()
        {
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            SPQuery qryFilterPlanner = new SPQuery();
            string qryFilter = string.Empty;

            if (plannerFragmentList != null)
            {
                if (SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                    qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Author' /><FieldRef Name='FragmentType' /></OrderBy>";
                else
                    qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Author' /><FieldRef Name='FragmentType' /></OrderBy><Where><Eq><FieldRef Name='Author' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Eq></Where>";

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
