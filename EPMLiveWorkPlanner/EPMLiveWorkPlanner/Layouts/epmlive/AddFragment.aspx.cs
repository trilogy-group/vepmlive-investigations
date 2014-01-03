using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class AddFragment : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            SPQuery qryFilterPlanner = new SPQuery();
            string qryFilter = string.Empty;

            if (!Page.IsPostBack)
            {
                if (plannerFragmentList != null)
                {
                    if (SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                        qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Title' /></OrderBy>";
                    else
                        qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='Author' /><FieldRef Name='FragmentType' /></ViewFields><Where><Or><And><Eq><FieldRef Name='FragmentType' /><Value Type='Choice'>Public</Value></Eq><Eq><FieldRef Name='FragmentType' /><Value Type='Choice'>Public</Value></Eq></And><Eq><FieldRef Name='Author' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Eq></Or></Where><OrderBy><FieldRef Name='Title' /></OrderBy>";

                    qryFilterPlanner.Query = qryFilter;

                    SPListItemCollection fragmentItems = plannerFragmentList.GetItems(qryFilterPlanner);
                    if (fragmentItems != null && fragmentItems.Count > 0)
                    {
                        foreach (SPListItem fragment in fragmentItems)
                            ddlFragments.Items.Add(new ListItem(Convert.ToString(fragment["Title"]), Convert.ToString(fragment["ID"])));
                    }
                }
            }
        }

        private void AddResourceToTeam(List<string> resources)
        {
            string resourceToAdd = string.Empty;
            SPList projectCenter = SPContext.Current.Web.Lists.TryGetList("Project Center");
            if (projectCenter != null)
            {
                SPListItem pItem = projectCenter.GetItemById(Convert.ToInt32(Request["ID"]));

                SPFieldUserValueCollection assignedTo = null;
                try
                {
                    assignedTo = new SPFieldUserValueCollection(SPContext.Current.Web, pItem["AssignedTo"].ToString());
                }
                catch { }

                if (assignedTo == null)
                    assignedTo = new SPFieldUserValueCollection();

                foreach (string resource in resources)
                {
                    if (!assignedTo.ToString().Contains(resource))
                    {
                        resourceToAdd += "'" + resource + "',";
                    }
                }

                if (!string.IsNullOrEmpty(resourceToAdd))
                {
                    resourceToAdd = resourceToAdd.Substring(0, resourceToAdd.Length - 1);

                    string sqlGetResources = "SELECT ID, Title, SharePointAccountID, SharePointAccountText FROM LSTResourcepool WHERE Title IN(" + resourceToAdd + ")";
                    DataTable dtResources = null;

                    try
                    {
                        var queryExecutor = new QueryExecutor(SPContext.Current.Web);
                        dtResources = queryExecutor.ExecuteReportingDBQuery(sqlGetResources, new Dictionary<string, object> { });
                    }
                    catch { }

                    if (dtResources != null && dtResources.Rows.Count > 0)
                    {
                        for (int row = 0; row < dtResources.Rows.Count; row++)
                        {
                            assignedTo.Add(new SPFieldUserValue(SPContext.Current.Web, Convert.ToInt32(dtResources.Rows[row]["SharePointAccountID"]), Convert.ToString(dtResources.Rows[row]["SharePointAccountText"])));
                        }

                        pItem["AssignedTo"] = assignedTo;

                        SPContext.Current.Web.AllowUnsafeUpdates = true;

                        pItem.Update();
                        projectCenter.Update();
                    }
                }
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Page.Response.Write("<script language='javascript' type='text/javascript'>window.frameElement.commonModalDialogClose(1, 1);</script>");
        }
    }
}
