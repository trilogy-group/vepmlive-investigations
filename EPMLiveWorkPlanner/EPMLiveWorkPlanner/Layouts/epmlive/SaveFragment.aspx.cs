using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.Data.SqlClient;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class SaveFragment : LayoutsPageBase
    {

        private void SavePlannerFragments(SPList plannerFragmentList)
        {
            try
            {
                SPSite site = SPContext.Current.Site;
                SPWeb web = SPContext.Current.Web;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                   {
                       using (SPSite currentSite = new SPSite(site.ID))
                       {
                           using (SPWeb currentWeb = currentSite.OpenWeb(web.ID))
                           {
                               currentWeb.AllowUnsafeUpdates = true;
                               SPListItem plannerFragmentItem = plannerFragmentList.Items.Add();

                               plannerFragmentItem["Title"] = txtFragmentName.Text;
                               plannerFragmentItem["Description"] = txtDescription.Text;
                               plannerFragmentItem["Tag"] = txtTag.Text;
                               plannerFragmentItem["FragmentType"] = rdoScope.SelectedItem.Text;
                               plannerFragmentItem["FragmentXML"] = hdnTaskFragmentXml.Value;
                               plannerFragmentItem["TaskListID"] = Convert.ToString(Request["tasklistid"]);
                               plannerFragmentItem.Update();
                               plannerFragmentList.Update();
                           }
                       }
                   });
            }
            catch (Exception ex)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //SPBasePermissions.ManageWeb – This is for saving public views
            //SPBasePermissions.EditListItems – Check this against the PlannerFragments list to see if the user can save fragments. If they have this but not manageweb then they can save private fragments only.
            //Any other users can’t save fragments, but can read them.

            rdoScope.Items[0].Enabled = false;
            rdoScope.Items[1].Enabled = false;

            bool doesUserHasManageWebPermission = false;
            try
            {
                if (SPContext.Current.Web.Lists.TryGetList("PlannerFragments") != null)
                    doesUserHasManageWebPermission = SPContext.Current.Web.Lists.TryGetList("PlannerFragments").DoesUserHavePermissions(SPContext.Current.Web.CurrentUser, SPBasePermissions.ManageWeb);
            }
            catch (SPException) { }

            if (doesUserHasManageWebPermission)
            {
                rdoScope.Items[0].Enabled = true;
                rdoScope.Items[1].Enabled = true;
            }
            else
            {
                rdoScope.Items[0].Enabled = true;
                rdoScope.Items[0].Selected = true;
                rdoScope.Items[1].Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            SavePlannerFragments(plannerFragmentList);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "closeSaveFragmentPopup", "closeSaveFragmentPopup()", true);
            Page.Response.Write("<script language='javascript' type='text/javascript'>closeSaveFragmentPopup();");
        }
    }
}
