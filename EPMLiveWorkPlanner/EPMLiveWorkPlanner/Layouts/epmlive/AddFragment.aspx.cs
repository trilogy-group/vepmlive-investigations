using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Collections.Generic;
using System.Reflection;
using EPMLiveWorkPlanner;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class AddFragment : LayoutsPageBase
    {
        DataSet ds = new DataSet();

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
                        qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='PlannerType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Title' /></OrderBy>";
                    else
                        qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='Author' /><FieldRef Name='PlannerType' /></ViewFields><Where><Or><And><Eq><FieldRef Name='PlannerType' /><Value Type='Choice'>Public</Value></Eq><Eq><FieldRef Name='PlannerType' /><Value Type='Choice'>Public</Value></Eq></And><Eq><FieldRef Name='Author' /><Value Type='User'>" + SPContext.Current.Web.CurrentUser.Name + "</Value></Eq></Or></Where><OrderBy><FieldRef Name='Title' /></OrderBy>";

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

        protected void btnImport_Click(object sender, EventArgs e)
        {
            String fragmentXml = string.Empty;
            SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
            if (plannerFragmentList != null)
            {
                SPListItem fragment = plannerFragmentList.GetItemById(Convert.ToInt32(ddlFragments.SelectedValue));
                fragmentXml = Convert.ToString(fragment["FragmentXML"]);
            }
        }
    }
}
