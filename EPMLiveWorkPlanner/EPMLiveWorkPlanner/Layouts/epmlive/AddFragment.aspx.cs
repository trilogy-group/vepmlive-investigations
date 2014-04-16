using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class AddFragment : LayoutsPageBase
    {
        #region Events

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "styles/fragments.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "/javascripts/libraries/jquery.min.js", 
                "/javascripts/Fragment.js"

            });
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillMyFragmentsGrid();
                FillPublicFragmentsGrid();
                CheckForNoFragment();
            }
        }

        private void CheckForNoFragment()
        {
            if (gridMyFragments.Rows.Count == 0 && gridPublicFragments.Rows.Count == 0)
            {
                (gridMyFragments.EmptyDataRowStyle).HorizontalAlign = HorizontalAlign.Center;
                gridMyFragments.EmptyDataText = "No fragments exist";
                gridMyFragments.DataSource = null;
                gridMyFragments.DataBind();
            }

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                int itemId = 0;
                string fragmentName = string.Empty;
                SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
                if (plannerFragmentList != null)
                {
                    //Processing MyFragments for Importing fragment
                    foreach (GridViewRow gvrow in gridMyFragments.Rows)
                    {
                        RadioButton rdoSelect = (RadioButton)gvrow.Cells[0].FindControl("rdoSelect");

                        if (rdoSelect != null && rdoSelect.Checked)
                        {
                            Label lblID = (Label)gvrow.FindControl("lblID");
                            if (lblID != null)
                            {
                                fragmentName = gvrow.Cells[2].Text;
                                itemId = Convert.ToInt32(lblID.Text);
                                break;
                            }
                        }
                    }

                    if (itemId > 0)
                    {
                        ImportFragmentAndAddResourceToTeam(itemId);
                    }
                    else
                    {
                        //Processing Public Fragments for Importing fragment
                        foreach (GridViewRow gvrow in gridPublicFragments.Rows)
                        {
                            RadioButton rdoSelect = (RadioButton)gvrow.Cells[0].FindControl("rdoSelect");

                            if (rdoSelect != null && rdoSelect.Checked)
                            {
                                Label lblID = (Label)gvrow.FindControl("lblID");
                                if (lblID != null)
                                {
                                    fragmentName = gvrow.Cells[2].Text;
                                    itemId = Convert.ToInt32(lblID.Text);
                                    ImportFragmentAndAddResourceToTeam(itemId);
                                    break;
                                }
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(fragmentName) && itemId > 0)
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closeAddFragmentPopup", "<script language='javascript' type='text/javascript'>closeAddFragmentPopup('Fragment '" + fragmentName + "' imported successfully!');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Methods

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
            string qryFilter = "<ViewFields><FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='FragmentType' /><FieldRef Name='Author' /></ViewFields><OrderBy><FieldRef Name='Title' /><FieldRef Name='Author' /></OrderBy><Where><And><Eq><FieldRef Name='FragmentType' /><Value Type='Choice'>Public</Value></Eq><Eq><FieldRef Name='PlannerID' /><Value Type='Text'>" + Convert.ToString(Request["PlannerID"]) + "</Value></Eq></And></Where>";

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

        private void ImportFragmentAndAddResourceToTeam(int itemId)
        {
            string fragmentName = string.Empty;
            try
            {
                XmlDocument currentPlanXmlDoc = new XmlDocument();
                XmlDocument fragmentXmlDoc = new XmlDocument();
                XmlNode insertAfterNode = null;
                List<string> teamToAdd = new List<string>();
                string planRowSelectedID = string.IsNullOrEmpty(hdnSelectedRowID.Value) ? "0" : Convert.ToString(hdnSelectedRowID.Value);

                SPList plannerFragmentList = SPContext.Current.Web.Lists.TryGetList("PlannerFragments");
                if (plannerFragmentList != null)
                {
                    if (!string.IsNullOrEmpty(hdnPlanXml.Value) && itemId > 0)
                    {
                        currentPlanXmlDoc.LoadXml(hdnPlanXml.Value);
                        insertAfterNode = currentPlanXmlDoc.SelectSingleNode(string.Format("//I[@id='{0}']", planRowSelectedID));

                        SPListItem fragment = plannerFragmentList.GetItemById(itemId);
                        fragmentName = fragment.Title;
                        fragmentXmlDoc.LoadXml(Convert.ToString(fragment["FragmentXML"]));

                        Int32 rowId = Convert.ToInt32(hdnNewRowID.Value);

                        XmlNode parentINode = fragmentXmlDoc.SelectSingleNode("//Grid/Body/B").FirstChild;

                        if (parentINode != null)
                        {
                            foreach (XmlNode xmlNode in parentINode.ChildNodes)
                            {
                                XmlNode nodeToCopy = currentPlanXmlDoc.ImportNode(fragmentXmlDoc.SelectSingleNode(string.Format("//I[@id='{0}']", xmlNode.Attributes["id"].Value)), true);
                                if (nodeToCopy != null)
                                {
                                    UpdateNodes(nodeToCopy, ref teamToAdd, ref rowId);
                                    if (planRowSelectedID == "0" && insertAfterNode.Attributes["id"].Value == "0")
                                    {
                                        insertAfterNode.AppendChild(nodeToCopy);
                                    }
                                    else
                                    {
                                        insertAfterNode.ParentNode.InsertAfter(nodeToCopy, insertAfterNode);
                                    }
                                    insertAfterNode = nodeToCopy;
                                }
                            }

                            SPFolder folder = SPContext.Current.Web.GetFolder("Project Schedules/" + Request["PlannerID"]);
                            if (!folder.Exists)
                                folder = SPContext.Current.Web.Folders["Project Schedules"].SubFolders.Add(Request["PlannerID"]);

                            folder.Files.Add(Request["ID"] + ".xml", Encoding.GetEncoding("iso-8859-1").GetBytes(currentPlanXmlDoc.OuterXml), true);

                            if (teamToAdd != null && teamToAdd.Count > 0)
                                AddResourceToTeam(teamToAdd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closeAddFragmentPopup", "<script language='javascript' type='text/javascript'>closeAddFragmentPopup('Error: " + ex.Message + "');</script>");
                return;
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "closeAddFragmentPopup", "<script language='javascript' type='text/javascript'>closeAddFragmentPopup('Fragment " + fragmentName + " imported successfully!');</script>");
        }

        private void UpdateNodes(XmlNode xmlNode, ref List<string> teamToAdd, ref Int32 rowId)
        {
            xmlNode.Attributes["id"].Value = rowId.ToString();
            string resourceNames = xmlNode.Attributes["ResourceNames"].Value;
            if (!string.IsNullOrEmpty(resourceNames))
            {
                foreach (string resource in resourceNames.Split(';'))
                {
                    if (!teamToAdd.Contains(resource))
                    {
                        teamToAdd.Add(resource);
                    }
                }
            }
            rowId++;

            if (xmlNode.HasChildNodes)
            {
                UpdateNodes(xmlNode.ChildNodes[0], ref teamToAdd, ref rowId);
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

        #endregion
    }
}
