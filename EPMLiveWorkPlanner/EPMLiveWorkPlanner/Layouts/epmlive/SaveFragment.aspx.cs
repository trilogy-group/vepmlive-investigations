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
    public partial class ExportFragment : LayoutsPageBase
    {
        private SPList GetPlannerFragmentList()
        {
            //Create New 'PlannerFragments' list with following columns:
            //Title[PlannerName - Single Line of Text], Description [Multiple Line of Text], PlannerType [Choice], Tag [single Line of Text], FragmentXml [Multiple line of Text]

            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;
            SPList plannerFragmentList = web.Lists.TryGetList("PlannerFragments");

            if (plannerFragmentList == null)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite currentSite = new SPSite(site.ID))
                    {
                        using (SPWeb currentWeb = currentSite.OpenWeb(web.ID))
                        {
                            currentWeb.AllowUnsafeUpdates = true;
                            Guid guid = currentWeb.Lists.Add("PlannerFragments", "Planner Fragments List - Used to store Planner Fragment details", SPListTemplateType.GenericList);
                            plannerFragmentList = currentWeb.Lists[guid];
                            //plannerFragmentList.Hidden = true; //TODO: Uncomment this while code check-in

                            plannerFragmentList.Fields.Add("Description", SPFieldType.Note, false);
                            plannerFragmentList.Fields.Add("PlannerType", SPFieldType.Choice, false);
                            plannerFragmentList.Fields.Add("Tag", SPFieldType.Text, false);
                            plannerFragmentList.Fields.Add("FragmentXML", SPFieldType.Note, false);
                            plannerFragmentList.Update();

                            //Add Planner Type - Choice Field
                            SPFieldChoice plannerTypes = (SPFieldChoice)plannerFragmentList.Fields["PlannerType"];
                            plannerTypes.Choices.Add("Private");
                            plannerTypes.Choices.Add("Public");
                            plannerTypes.DefaultValue = "Private";
                            plannerTypes.Update();  //Saves choices to column
                            plannerFragmentList.Update();

                            SPView view = plannerFragmentList.DefaultView;
                            view.ViewFields.Add("Description");
                            view.ViewFields.Add("PlannerType");
                            view.ViewFields.Add("Tag");
                            view.Update();

                            plannerFragmentList.Update();
                            currentWeb.Update();
                        }
                    }
                });
            }
            return plannerFragmentList;
        }

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
                               plannerFragmentItem["PlannerType"] = rdoScope.SelectedItem.Text;
                               plannerFragmentItem["FragmentXML"] = hdnTaskFragmentXml.Value;

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
            SPList plannerFragmentList = GetPlannerFragmentList();
            SavePlannerFragments(plannerFragmentList);
        }
    }
}
