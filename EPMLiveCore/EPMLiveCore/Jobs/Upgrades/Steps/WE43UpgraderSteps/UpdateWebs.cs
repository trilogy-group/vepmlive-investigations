using System;
using System.Data;
using System.IO;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 50)]
    public class UpdateWebs : Step
    {
        public UpdateWebs(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Updating Webs"; }
        }

        public override bool Perform()
        {
            SPWebCollection spWebCollection = SPSite.AllWebs;
            for (int i = 0; i < spWebCollection.Count; i++)
            {
                using (SPWeb web = spWebCollection[i])
                {
                    LogMessage("Web: " + web.ServerRelativeUrl);

                    try
                    {
                        UpdateMaster(web);
                    }
                    catch (Exception ex)
                    {
                        LogMessage("", ex.Message, 3);
                    }

                    try
                    {
                        ActivateAppsList(web);
                    }
                    catch (Exception ex)
                    {
                        LogMessage("", ex.Message, 3);
                    }

                    try
                    {
                        UpdateSettings(web);
                    }
                    catch (Exception ex)
                    {
                        LogMessage("", ex.Message, 3);
                    }

                    try
                    {
                        AddCommunity(web);
                    }
                    catch (Exception ex)
                    {
                        LogMessage("", ex.Message, 3);
                    }
                }
            }

            return true;
        }

        private string getCategoryName(string category)
        {
            try
            {
                return category.Substring(category.IndexOf(")") + 2);
            }
            catch
            {
            }
            return category;
        }

        private string getCategoryNumber(string category)
        {
            try
            {
                return category.Substring(0, category.IndexOf(")"));
            }
            catch
            {
            }
            return category;
        }

        private void UpdateSettings(SPWeb web)
        {
            if (!web.IsRootWeb)
            {
                LogMessage("\tUpdating Settings List");


                SPList list = web.Lists.TryGetList("EPM Live Settings");

                if (list != null)
                {
                    var oField = (SPFieldChoice) list.Fields.GetFieldByInternalName("Category");

                    bool bCatFound = false;

                    string lastNum = "1";
                    string CategoryName = "";

                    foreach (string s in oField.Choices)
                    {
                        if (getCategoryName(s) == "Configuration")
                        {
                            CategoryName = s;
                            bCatFound = true;
                        }

                        lastNum = getCategoryNumber(s);
                    }

                    if (!bCatFound)
                    {
                        LogMessage("\t\tAdding Category");

                        lastNum = (int.Parse(lastNum) + 1).ToString();

                        oField.Choices.Add(lastNum + ") Configuration");

                        oField.Update();

                        CategoryName = lastNum + ") Configuration";
                    }

                    DataTable dt = list.Items.GetDataTable();

                    DataRow[] dr = dt.Select("Title='Manage Communities'");

                    if (dr.Length == 0)
                    {
                        LogMessage("\t\tAdding Setting: Manage Communities");

                        SPListItem li = list.Items.Add();
                        li["Title"] = "Manage Communities";
                        li["Category"] = CategoryName;
                        li["URL"] = "/_layouts/epmlive/applications/manage.aspx";
                        li.Update();
                    }

                    dr = dt.Select("Title='Manage Applications'");

                    if (dr.Length == 0)
                    {
                        LogMessage("\t\tAdding Setting: Manage Applications");

                        SPListItem li = list.Items.Add();
                        li["Title"] = "Manage Applications";
                        li["Category"] = CategoryName;
                        li["URL"] = "/_layouts/epmlive/applications/manageapps.aspx";
                        li.Update();
                    }
                }
                else
                {
                    LogMessage("", "EPM Live Settings List does not exist", 3);
                }
            }
        }

        private void AddCommunity(SPWeb web)
        {
            LogMessage("Adding Communities");

            SPList list = API.Applications.GetApplicationList(web);

            var query = new SPQuery();
            query.Query =
                "<Where><IsNull><FieldRef Name='EXTID'/></IsNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            if (list.GetItems(query).Count == 0)
            {
                try
                {
                    API.Applications.CreateCommunity("Projects", web);

                    LogMessage("\tAdding Community: Projects");
                }
                catch (Exception ex)
                {
                    LogMessage("", "Adding Community: Projects: " + ex.Message, 3);
                }
            }

            query = new SPQuery();
            query.Query =
                "<Where><IsNotNull><FieldRef Name='EXTID'/></IsNotNull></Where><OrderBy><FieldRef Name='Title'/></OrderBy>";

            if (list.GetItems(query).Count == 0)
            {
                try
                {
                    SPListItem li = list.Items.Add();
                    li["Title"] = "Project Management Office";
                    li["AppVersion"] = "1.0.0";
                    li["Configured"] = "Yes";
                    li["Default"] = "No";
                    li["Description"] = "Manage and Track Projects";
                    li["EXTID"] = "1";
                    li.Update();

                    LogMessage("\tAdding App: PMO");
                }
                catch (Exception ex)
                {
                    LogMessage("", "Adding App: PMO: " + ex.Message, 3);
                }
            }
        }

        private void ActivateAppsList(SPWeb web)
        {
            LogMessage("\tActivating Apps List Feature");

            web.Features.Add(new Guid("21c3b2a2-f0c6-4abf-8671-a07c9f50d00d"), true);
        }

        private void UpdateMaster(SPWeb web)
        {
            LogMessage("\tUpdating Master Page");

            string masterUrl = web.MasterUrl;

            if (Path.GetFileName(masterUrl).ToLower().Equals("wetoplevel.master"))
            {
                ActivateFeature(true, web);
                ChangeMasterPage("MasterV43LightBlueTop", web);
            }
            else if (Path.GetFileName(masterUrl).ToLower().Equals("weworkspacetopnav.master"))
            {
                ActivateFeature(false, web);
                ChangeMasterPage("MasterV43LightBlueWS", web);
            }
            else
            {
                if (web.IsRootWeb)
                {
                    ActivateFeature(true, web);
                    //ChangeMasterPage("MasterV43LightBlueTop", SPWeb);
                }
                else
                {
                    ActivateFeature(false, web);
                    //ChangeMasterPage("MasterV43LightBlueWS", SPWeb);
                }
            }
        }

        private void ChangeMasterPage(string masterPage, SPWeb spWeb)
        {
            LogMessage(string.Format("\t\tChanging MasterPage to: {0}", masterPage));

            string url = (spWeb.ServerRelativeUrl == "/" ? "" : spWeb.ServerRelativeUrl);

            spWeb.MasterUrl = string.Format(url + "/_catalogs/masterpage/{0}.master", masterPage);
            spWeb.CustomMasterUrl = string.Format(url + "/_catalogs/masterpage/{0}.master", masterPage);
            spWeb.Update();
        }

        private void ActivateFeature(bool bTopLevel, SPWeb web)
        {
            LogMessage("\t\tActivating Master Page Feature Top: " + bTopLevel);

            web.Features.Add(bTopLevel
                ? new Guid("12c595be-1b08-4eda-b45a-b4703650234f")
                : new Guid("7d08f889-c324-460b-95e2-c26ee42657ad"), true);
        }
    }
}