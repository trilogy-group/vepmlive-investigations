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
                           plannerFragmentItem["PlannerID"] = Convert.ToString(Request["PlannerID"]);

                           plannerFragmentItem.Update();
                           plannerFragmentList.Update();
                       }
                   }
               });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool doesUserHasManageWebPermission = false;                
                SPList plannerFragmentsList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");;
                if (plannerFragmentsList != null)
                    doesUserHasManageWebPermission = plannerFragmentsList.DoesUserHavePermissions(SPContext.Current.Web.CurrentUser, SPBasePermissions.ManageWeb);
                rdoScope.Items[1].Enabled = doesUserHasManageWebPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
                if (plannerFragmentList != null)
                {
                    SavePlannerFragments(plannerFragmentList);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closeSaveFragmentPopup", "<script language='javascript' type='text/javascript'>closeSaveFragmentPopup('Fragment " + txtFragmentName.Text + " saved successfully!');</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
