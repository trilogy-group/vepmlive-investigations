using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace EPMLiveCore
{
    public partial class myworksettings : LayoutsPageBase
    {
        #region Fields (14) 

        private const string GeneralSettingsCrossSiteUrls = "EPMLive_MyWork_GeneralSettings_CrossSiteUrls";
        private const string GeneralSettingsExcludedMyWorkLists = "EPMLive_MyWork_GeneralSettings_ExcludedMyWorkLists";
        private const string GeneralSettingsListsAndFields = "EPMLive_MyWork_GeneralSettings_AllListsAndFields";
        private const string GeneralSettingsMyWorkIncludeFixApplied = "EPMLive_MyWork_GeneralSettings_IncludeFixApplied";
        private const string GeneralSettingsMyWorkListsAndFields = "EPMLive_MyWork_GeneralSettings_MyWorkListsAndFields";
        //private const string GeneralSettingsNewItemButtonLists = "EPMLive_MyWork_GeneralSettings_NewItemButtonLists";
        private const string GeneralSettingsPerformanceMode = "EPMLive_MyWork_GeneralSettings_PerformanceMode";
        private const string GeneralSettingsSelectedFields = "EPMLive_MyWork_GeneralSettings_SelectedFields";
        public const string GeneralSettingsSelectedLists = "EPMLive_MyWork_GeneralSettings_SelectedLists";
        public const string GeneralSettingsSelectedMyWorkLists = "EPMLive_MyWork_GeneralSettings_SelectedMyWorkLists";
        private const int MyWorkListServerTemplateId = 10115;
        private readonly SPWeb _web = SPContext.Current.Web;
        protected string FieldLists;
        protected string ListWorkspaces;
        protected List<MWList> MyWorkLists;

        #endregion Fields 

        #region Properties (1) 

        private string[] CurrentlySelectedLists
        {
            get
            {
                //if (string.IsNullOrEmpty(tbSelectedLists.Text)) return null;

                List<string> lists =
                    tbSelectedLists.Text.Replace("\r\n", "\n").Split('\n').Where(list => !string.IsNullOrEmpty(list)).
                        ToList();
                lists.AddRange(from ListItem item in lstIncludedMyWorkLists.Items select item.Text);

                return lists.Distinct().ToArray();
            }
        }

        #endregion Properties 

        #region Methods (19) 

        // Public Methods (1) 

        public static List<MWList> GetMyWorkListsFromDb(SPWeb web, List<Guid> archivedWebs)
        {
            var lists = new List<MWList>();

            using (SqlConnection sqlConnection = MyWork.GetSpContentDbSqlConnection(web))
            {
                string webUrl = web.ServerRelativeUrl;
                webUrl = webUrl.Equals("/") ? string.Empty : webUrl.Substring(1);

                string archivedWebString = string.Join(",",
                                                       archivedWebs.Select(
                                                           archivedWeb => string.Format("'{0}'", archivedWeb)).
                                                           ToArray());

                string queryString =
                    @"
                            SELECT     dbo.AllLists.tp_Id, dbo.AllLists.tp_Title, dbo.Webs.FullUrl
                            FROM        dbo.Webs 
                            INNER JOIN  dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId 
                            WHERE ";

                queryString += string.IsNullOrEmpty(webUrl)
                                   ? string.Format(@"(dbo.Webs.SiteId = '{0}')", web.Site.ID)
                                   : string.Format(
                                       @"(dbo.Webs.FullUrl LIKE '{0}/%' OR dbo.Webs.FullUrl = '{0}')", webUrl);

                if (archivedWebs.Count > 0)
                    queryString += string.Format(@" AND (dbo.AllLists.tp_WebId NOT IN ({0}))", archivedWebString);

                queryString += string.Format(@" AND (dbo.AllLists.tp_ServerTemplate = {0})",
                                             MyWorkListServerTemplateId);

                using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        string listId = string.Format("MW_{0}",
                                                      sqlDataReader.GetGuid(0).ToString().Replace("-", string.Empty));
                        string listName = sqlDataReader.GetString(1);
                        string listWeb = sqlDataReader.GetString(2);

                        if (!lists.Exists(l => l.Name.Equals(listName)))
                        {
                            lists.Add(new MWList
                                          {
                                              Id = listId,
                                              Name = listName,
                                              Webs = new List<string> {listWeb}
                                          });
                        }
                        else
                        {
                            foreach (
                                MWList mwList in
                                    lists.Where(mwList => mwList.Name.Equals(listName)).Where(
                                        mwList => !mwList.Webs.Contains(listWeb)))
                            {
                                mwList.Webs.Add(listWeb);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return lists;
        }

        // Protected Methods (9) 

        /// <summary>
        /// Handles the OnClick event of the btnAddField control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnAddField_OnClick(object sender, EventArgs e)
        {
            var fieldsToRemove = new List<ListItem>();

            foreach (ListItem listItem in lstAllFields.Items.Cast<ListItem>().Where(listItem => listItem.Selected))
            {
                lstSelectedFields.Items.Add(listItem);
                fieldsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in fieldsToRemove)
                lstAllFields.Items.Remove(listItem);

            lstSelectedFields.Sort();

            ListMyWorkFields();
        }

        /// <summary>
        /// Handles the OnClick event of the btnExcludeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnExcludeList_OnClick(object sender, EventArgs e)
        {
            var listsToRemove = new List<ListItem>();

            foreach (
                ListItem listItem in lstIncludedMyWorkLists.Items.Cast<ListItem>().Where(listItem => listItem.Selected))
            {
                lstExcludedMyWorkLists.Items.Add(listItem);
                listsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in listsToRemove) lstIncludedMyWorkLists.Items.Remove(listItem);

            lstExcludedMyWorkLists.Sort();

            ListMyWorkFields();
        }

        /// <summary>
        /// Handles the OnClick event of the btnIncludeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnIncludeList_OnClick(object sender, EventArgs e)
        {
            var listsToRemove = new List<ListItem>();

            foreach (
                ListItem listItem in lstExcludedMyWorkLists.Items.Cast<ListItem>().Where(listItem => listItem.Selected))
            {
                lstIncludedMyWorkLists.Items.Add(listItem);
                listsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in listsToRemove)
                lstExcludedMyWorkLists.Items.Remove(listItem);

            lstIncludedMyWorkLists.Sort();

            ListMyWorkFields();
        }

        /// <summary>
        /// Handles the OnClick event of the btnRefreshField control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnRefreshField_OnClick(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> listsAndFields = GetListsAndFields();
            Dictionary<string, List<string>> myWorkListsAndFields = GetMyWorkListsAndFields();

            List<string> selectedFields =
                (lstSelectedFields.Items.Cast<ListItem>().Select(listItem => listItem.Value)).ToList();

            //if (string.IsNullOrEmpty(tbSelectedLists.Text))
            //{
            //    IOrderedEnumerable<ListItem> availableFields = (listsAndFields.SelectMany(
            //        listAndField => listAndField.Value)
            //        .Where(theField => !selectedFields.Exists(f => f.Equals(theField))).Select(
            //            theField => new ListItem(theField.ToPrettierName(_web), theField)))
            //        .ToList().Distinct().OrderBy(f => f.Text);

            //    lstAllFields.DataTextField = "Text";
            //    lstAllFields.DataValueField = "Value";
            //    lstAllFields.DataSource = availableFields;
            //    lstAllFields.DataBind();
            //}
            //else
            //{
            string[] selectedLists = CurrentlySelectedLists;

            #region Available Fields

            var availableFields = new List<ListItem>();

            foreach (string list in selectedLists.Where(listsAndFields.ContainsKey))
            {
                string theList = list;
                availableFields.AddRange(from field in listsAndFields[list]
                                         where listsAndFields.ContainsKey(theList)
                                         let theField = field
                                         where
                                             !lstSelectedFields.Items.Contains(
                                                 new ListItem(theField.ToPrettierName(_web), field))
                                         select new ListItem(theField.ToPrettierName(_web), field));
            }

            availableFields.AddRange(from myWorkListsAndField in myWorkListsAndFields
                                     from field in myWorkListsAndField.Value
                                     let fieldInternalName = field.ToPrettierName(_web)
                                     where !lstSelectedFields.Items.Contains(new ListItem(fieldInternalName, field))
                                     select new ListItem(fieldInternalName, field));

            //availableFields.AddRange(from myWorkListsAndField in myWorkListsAndFields
            //                         where selectedLists.Contains(myWorkListsAndField.Key)
            //                         from field in myWorkListsAndField.Value
            //                         let fieldInternalName = field.ToPrettierName(_web)
            //                         where !lstSelectedFields.Items.Contains(new ListItem(fieldInternalName, field))
            //                         select new ListItem(fieldInternalName, field));

            lstAllFields.DataSource = availableFields.Distinct().OrderBy(f => f.Text);
            lstAllFields.DataTextField = "Text";
            lstAllFields.DataValueField = "Value";
            lstAllFields.DataBind();

            #endregion

            #region Selected Fields

            List<ListItem> fieldsToRemove = (from ListItem theListItem in lstSelectedFields.Items
                                             let exists = (from selectedList in selectedLists
                                                           where listsAndFields.ContainsKey(selectedList)
                                                           let item = theListItem
                                                           where
                                                               listsAndFields[selectedList].Exists(
                                                                   f => f.Equals(item.Value))
                                                           select selectedList).Any()
                                             where !exists
                                             select theListItem).ToList();

            foreach (ListItem listItem in fieldsToRemove) lstSelectedFields.Items.Remove(listItem);

            #endregion

            //}

            ListMyWorkFields();
        }

        /// <summary>
        /// Handles the OnClick event of the btnRemoveField control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnRemoveField_OnClick(object sender, EventArgs e)
        {
            var fieldsToRemove = new List<ListItem>();

            foreach (ListItem listItem in lstSelectedFields.Items.Cast<ListItem>().Where(listItem => listItem.Selected))
            {
                lstAllFields.Items.Add(listItem);
                fieldsToRemove.Add(listItem);
            }

            foreach (ListItem listItem in fieldsToRemove) lstSelectedFields.Items.Remove(listItem);

            lstAllFields.Sort();

            ListMyWorkFields();
        }

        /// <summary>
        /// Handles the OnClick event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnReset_OnClick(object sender, EventArgs e)
        {
            LoadGeneralSettings();
        }

        /// <summary>
        /// Handles the OnClick event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SaveGeneralSettings();
        }

        /// <summary>
        /// Handles the RowDataBound event of the GvFields control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void GvFields_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            string sFieldDisplayName = DataBinder.Eval(e.Row.DataItem, "DisplayName").ToString();
            string sFieldInternalName = DataBinder.Eval(e.Row.DataItem, "InternalName").ToString();
            string sFieldType = DataBinder.Eval(e.Row.DataItem, "FieldType").ToString();
            string sLink = "<a href=\"#\" onclick=\"pageRedir('" + SPContext.Current.Web.Url +
                           "/_layouts/FldEdit.aspx?source="
                           + HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl) + "&List=" +
                           _web.Lists["My Work"].ID + "&Field="
                           + HttpUtility.HtmlDecode(sFieldInternalName) + "')\" >" + sFieldDisplayName + "</a>";
            e.Row.Cells[0].Text = HttpUtility.HtmlDecode(sLink);
            e.Row.Cells[1].Text = HttpUtility.HtmlDecode(sFieldType);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _web.AllowUnsafeUpdates = true;

            #region MASTER RESET

            //CoreFunctions.setConfigSetting(_web, GeneralSettingsSelectedLists, string.Empty);
            //CoreFunctions.setConfigSetting(_web, GeneralSettingsSelectedFields, string.Empty);
            //CoreFunctions.setConfigSetting(_web, GeneralSettingsCrossSiteUrls, string.Empty);
            //CoreFunctions.setConfigSetting(_web, GeneralSettingsPerformanceMode, string.Empty);
            //CoreFunctions.setConfigSetting(_web, GeneralSettingsListsAndFields, string.Empty);
            //CoreFunctions.setConfigSetting(_web, GeneralSettingsMyWorkListsAndFields, string.Empty);
            //CoreFunctions.setConfigSetting(_web, GeneralSettingsNewItemButtonLists, string.Empty);

            #endregion

            if (IsPostBack)
            {
                FieldLists = hfFieldLists.Value;
                ListWorkspaces = hfListWorkspaces.Value;

                return;
            }

            Guid lWeb = CoreFunctions.getLockedWeb(_web);

            if (lWeb != _web.ID)
            {
                pnlAdmin.Visible = true;
                using (SPWeb w = _web.Site.OpenWeb(lWeb))
                {
                    hlAdmin.NavigateUrl = w.ServerRelativeUrl + "/_layouts/epmlive/myworksettings.aspx";
                }
                pnlMain.Visible = false;

                return;
            }

            if (!MyWorkListExists())
            {
                pnlMyWorkList.Visible = true;
                pnlMain.Visible = false;

                return;
            }

            SetListsAndFields();

            #region Get Field Lists

            var fieldLists = new Dictionary<string, List<string>>();

            foreach (var listAndFields in GetListsAndFields())
            {
                foreach (string field in listAndFields.Value)
                {
                    if (!fieldLists.ContainsKey(field)) fieldLists.Add(field, new List<string>());
                    fieldLists[field].Add(listAndFields.Key);
                }
            }

            List<string> fields = fieldLists.Select(fieldList => string.Format(@"{0}:[{1}]", fieldList.Key,
                                                                               string.Join(",",
                                                                                           fieldList.Value.Select(
                                                                                               list =>
                                                                                               string.Format(@"'{0}'",
                                                                                                             list)).
                                                                                               ToArray()))).ToList();

            FieldLists = string.Join(",", fields.ToArray());
            hfFieldLists.Value = FieldLists;

            #endregion

            LoadGeneralSettings();

            IEnumerable<string> lists = MyWorkLists.Select(list => string.Format(@"{0}:[{1}]", list.Id,
                                                                                 string.Join(",",
                                                                                             list.Webs.Select(
                                                                                                 workspace =>
                                                                                                 string.Format(
                                                                                                     @"'{0}'", workspace))
                                                                                                 .ToArray())));

            ListWorkspaces = string.Join(",", lists.ToArray());
            hfListWorkspaces.Value = ListWorkspaces;

            ListMyWorkFields();
        }

        // Private Methods (9) 

        /// <summary>
        /// Gets the lists and fields.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, List<string>> GetListsAndFields()
        {
            string selectedListsAndFields =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsListsAndFields).Decompress();

            string[] arrListsAndFields = selectedListsAndFields.Split('|');

            var allListsAndFields = new Dictionary<string, List<string>>();
            foreach (string listAndFields in arrListsAndFields)
            {
                if (string.IsNullOrEmpty(listAndFields)) continue;
                string[] lf = listAndFields.Split(':');

                if (string.IsNullOrEmpty(lf[0]) || string.IsNullOrEmpty(lf[1])) continue;
                List<string> fields = lf[1].Split(',').Where(field => !string.IsNullOrEmpty(field)).ToList();

                allListsAndFields.Add(lf[0], fields);
            }

            return allListsAndFields;
        }

        /// <summary>
        /// Gets my work lists and fields.
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, List<string>> GetMyWorkListsAndFields()
        {
            string selectedListsAndFields =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsMyWorkListsAndFields).Decompress();

            string[] arrListsAndFields = selectedListsAndFields.Split('|');

            var allListsAndFields = new Dictionary<string, List<string>>();
            foreach (string listAndFields in arrListsAndFields)
            {
                if (string.IsNullOrEmpty(listAndFields)) continue;
                string[] lf = listAndFields.Split(':');

                if (string.IsNullOrEmpty(lf[0]) || string.IsNullOrEmpty(lf[1])) continue;
                List<string> fields = lf[1].Split(',').Where(field => !string.IsNullOrEmpty(field)).ToList();

                allListsAndFields.Add(lf[0], fields);
            }

            return allListsAndFields;
        }

        /// <summary>
        /// Determines if the fix is applied.
        /// </summary>
        /// <returns></returns>
        private bool IncludeFixApplied()
        {
            return
                !string.IsNullOrEmpty(
                    CoreFunctions.getConfigSetting(_web, GeneralSettingsMyWorkIncludeFixApplied).Trim());
        }

        /// <summary>
        /// Lists my work fields.
        /// </summary>
        private void ListMyWorkFields()
        {
            var dt = new DataTable();
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("FieldType");
            dt.Columns.Add("InternalName");

            foreach (SPField fld in _web.Lists["My Work"].Fields)
            {
                if (!fld.Sealed && (!fld.ReadOnlyField || fld.Type == SPFieldType.Calculated)
                    && fld.Type != SPFieldType.Attachments && fld.InternalName != "Order" &&
                    fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo")
                {
                    dt.Rows.Add(new[] {fld.Title, fld.TypeShortDescription, fld.InternalName});
                }
            }

            dt.DefaultView.Sort = "DisplayName ASC";

            GvFields.DataSource = dt;
            GvFields.DataBind();
        }

        /// <summary>
        /// Loads the general settings.
        /// </summary>
        private void LoadGeneralSettings()
        {
            #region All Lists and Fields

            Dictionary<string, List<string>> listsAndFields = GetListsAndFields();
            Dictionary<string, List<string>> myWorkListsAndFields = GetMyWorkListsAndFields();

            #endregion

            #region Selected Lists

            MyWorkLists = GetMyWorkListsFromDb(_web, MyWork.GetArchivedWebs(_web.Site.ID));

            if (!NewSetup())
            {
                if (!IncludeFixApplied())
                {
                    List<string> selectedMyWorkLists =
                        CoreFunctions.getConfigSetting(_web, GeneralSettingsSelectedMyWorkLists).Split(new[] {','}).
                            ToList();

                    var excludedLists = new List<string>();
                    var includedLists = new List<string>();

                    foreach (MWList myWorkList in MyWorkLists)
                    {
                        if (!selectedMyWorkLists.Contains(myWorkList.Name)) excludedLists.Add(myWorkList.Name);
                        else includedLists.Add(myWorkList.Name);
                    }

                    CoreFunctions.setConfigSetting(_web, GeneralSettingsExcludedMyWorkLists,
                                                   excludedLists.Count > 0
                                                       ? string.Join(",", excludedLists.ToArray())
                                                       : string.Empty);

                    CoreFunctions.setConfigSetting(_web, GeneralSettingsSelectedMyWorkLists,
                                                   includedLists.Count > 0
                                                       ? string.Join(",", includedLists.ToArray())
                                                       : string.Empty);

                    CoreFunctions.setConfigSetting(_web, GeneralSettingsMyWorkIncludeFixApplied,
                                                   true.ToString(CultureInfo.InvariantCulture));
                }
            }

            //List<string> selectedMyWorkLists =
            //    CoreFunctions.getConfigSetting(_web, GeneralSettingsSelectedMyWorkLists).Split(new[] {','}).ToList();

            //MyWorkLists = GetMyWorkListsFromDb(_web, MyWork.GetArchivedWebs(_web.Site.ID));

            //foreach (MWList list in MyWorkLists)
            //{
            //    var listItem = new ListItem(list.Name, list.Id);

            //    if (selectedMyWorkLists.Contains(list.Name) ||
            //        (selectedMyWorkLists.Count == 1 && string.IsNullOrEmpty(selectedMyWorkLists[0])))
            //    {
            //        lstIncludedMyWorkLists.Items.Add(listItem);
            //    }
            //    else
            //    {
            //        lstExcludedMyWorkLists.Items.Add(listItem);
            //    }
            //}

            List<string> excludedMyWorkLists =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsExcludedMyWorkLists).Split(new[] {','}).ToList();

            foreach (MWList myWorkList in MyWorkLists)
            {
                var listItem = new ListItem(myWorkList.Name, myWorkList.Id);

                if (excludedMyWorkLists.Contains(myWorkList.Name))
                {
                    lstExcludedMyWorkLists.Items.Add(listItem);
                }
                else
                {
                    lstIncludedMyWorkLists.Items.Add(listItem);
                }
            }

            List<string> selectedLists =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsSelectedLists).Split(new[] {','}).ToList();
            selectedLists.RemoveAll(string.IsNullOrEmpty);

            foreach (string selectedList in selectedLists)
            {
                tbSelectedLists.Text += selectedList + Environment.NewLine;
            }

            #endregion

            #region New Item Button List

            //string newItemButtonLists = CoreFunctions.getConfigSetting(_web, GeneralSettingsNewItemButtonLists);

            //if (!string.IsNullOrEmpty(newItemButtonLists))
            //    tbNewItemButtonLists.Text = newItemButtonLists.Replace("|", Environment.NewLine);

            #endregion

            #region Selected Fields

            List<string> selectedFields =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsSelectedFields).Split(new[] {','}).ToList();

            lstSelectedFields.DataSource = (from selectedField in selectedFields
                                            where !string.IsNullOrEmpty(selectedField)
                                            let theField = selectedField
                                            select new ListItem(theField.ToPrettierName(_web), selectedField)).ToList();
            lstSelectedFields.DataTextField = "Text";
            lstSelectedFields.DataValueField = "Value";
            lstSelectedFields.DataBind();

            #endregion

            #region Available Fields

            var availableFields = new List<ListItem>();

            availableFields.AddRange((selectedLists.Count > 0
                                          ? (from selectedList in selectedLists
                                             where listsAndFields.ContainsKey(selectedList)
                                             from field in listsAndFields[selectedList]
                                             where !selectedFields.Exists(f => f.Equals(field))
                                             let theField = field
                                             select new ListItem(theField.ToPrettierName(_web), field))
                                          : (from listAndFields in listsAndFields
                                             from field in listAndFields.Value
                                             where !selectedFields.Exists(f => f.Equals(field))
                                             let theField = field
                                             select new ListItem(theField.ToPrettierName(_web), field))));

            availableFields.AddRange(from myWorkListsAndField in myWorkListsAndFields
                                     from field in myWorkListsAndField.Value
                                     where !selectedFields.Contains(field)
                                     select new ListItem(field.ToPrettierName(_web), field));

            lstAllFields.DataTextField = "Text";
            lstAllFields.DataValueField = "Value";
            lstAllFields.DataSource = availableFields.Distinct().OrderBy(f => f.Text);
            lstAllFields.DataBind();

            #endregion

            #region Cross Site Urls

            string crossSiteUrls = CoreFunctions.getConfigSetting(_web, GeneralSettingsCrossSiteUrls);

            if (!string.IsNullOrEmpty(crossSiteUrls))
                tbCrossSiteUrls.Text = crossSiteUrls.Replace("|", Environment.NewLine);

            #endregion

            #region Performance Mode

            string performanceMode = CoreFunctions.getConfigSetting(_web, GeneralSettingsPerformanceMode);
            cbPerformanceMode.Checked = string.IsNullOrEmpty(performanceMode) || performanceMode.Equals("on");

            #endregion
        }

        /// <summary>
        /// Checks if the my work list exists.
        /// </summary>
        /// <returns></returns>
        private bool MyWorkListExists()
        {
            return _web.Lists.TryGetList("My Work") != null;
        }

        /// <summary>
        /// Determines if this is a new setup.
        /// </summary>
        /// <returns></returns>
        private bool NewSetup()
        {
            List<string> includedMyWorkLists =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsSelectedMyWorkLists).Split(new[] {','}).ToList();
            List<string> excludedMyWorkLists =
                CoreFunctions.getConfigSetting(_web, GeneralSettingsExcludedMyWorkLists).Split(new[] {','}).ToList();

            return includedMyWorkLists.Count == 1 && string.IsNullOrEmpty(includedMyWorkLists[0]) &&
                   excludedMyWorkLists.Count == 1 && string.IsNullOrEmpty(excludedMyWorkLists[0]);
        }

        /// <summary>
        /// Saves the general settings.
        /// </summary>
        private void SaveGeneralSettings()
        {
            string[] selectedMyWorkLists =
                (lstIncludedMyWorkLists.Items.Cast<ListItem>().Select(item => item.Text)).ToArray();
            CoreFunctions.setConfigSetting(_web, GeneralSettingsSelectedMyWorkLists,
                                           string.Join(",", selectedMyWorkLists));

            string[] excludedMyWorkLists =
                (lstExcludedMyWorkLists.Items.Cast<ListItem>().Select(item => item.Text)).ToArray();
            CoreFunctions.setConfigSetting(_web, GeneralSettingsExcludedMyWorkLists,
                                           string.Join(",", excludedMyWorkLists));

            List<string> selectedLists = CurrentlySelectedLists.Where(currentlySelectedList =>
                                                                      lstIncludedMyWorkLists.Items.FindByText(
                                                                          currentlySelectedList) == null).Where(
                                                                              currentlySelectedList =>
                                                                              lstExcludedMyWorkLists.Items.FindByText(
                                                                                  currentlySelectedList) == null).ToList
                ();

            CoreFunctions.setConfigSetting(_web, GeneralSettingsSelectedLists,
                                           selectedLists.Count > 0
                                               ? string.Join(",", selectedLists.ToArray())
                                               : string.Empty);

            string[] selectedFields =
                (lstSelectedFields.Items.Cast<ListItem>().Select(listItem => listItem.Value)).ToArray();
            CoreFunctions.setConfigSetting(_web, GeneralSettingsSelectedFields, string.Join(",", selectedFields));

            //CoreFunctions.setConfigSetting(_web, GeneralSettingsNewItemButtonLists,
            //                               tbNewItemButtonLists.Text.Replace(Environment.NewLine, "|"));

            CoreFunctions.setConfigSetting(_web, GeneralSettingsCrossSiteUrls,
                                           tbCrossSiteUrls.Text.Replace(Environment.NewLine, "|"));

            CoreFunctions.setConfigSetting(_web, GeneralSettingsPerformanceMode,
                                           cbPerformanceMode.Checked ? "on" : "off");

            if (!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        /// <summary>
        /// Sets the lists and fields.
        /// </summary>
        /// <returns></returns>
        private void SetListsAndFields()
        {
            var listsAndFields = new Dictionary<string, List<string>>();
            var myWorkListsAndFields = new Dictionary<string, List<string>>();

            foreach (SPList spList in _web.Lists)
            {
                List<string> fields =
                    (from SPField spField in spList.Fields
                     where !spField.Hidden && spField.Reorderable
                     select spField.InternalName).ToList();

                string title = spList.Title;

                listsAndFields.Add(title, fields);

                if ((int)spList.BaseTemplate == MyWorkListServerTemplateId || title.Equals("My Work"))
                {
                    myWorkListsAndFields.Add(title, fields);
                }
            }

            string serializedListsAndFields = listsAndFields.Aggregate(string.Empty, (current, listAndFields)
                                                                                     =>
                                                                                     current +
                                                                                     string.Format(@"{0}:{1}|",
                                                                                                   listAndFields.Key,
                                                                                                   string.Join(",",
                                                                                                               listAndFields
                                                                                                                   .
                                                                                                                   Value
                                                                                                                   .
                                                                                                                   ToArray
                                                                                                                   ())));

            CoreFunctions.setConfigSetting(_web, GeneralSettingsListsAndFields, serializedListsAndFields.Compress());

            string serializedMyWorkListsAndFields = myWorkListsAndFields.Aggregate(string.Empty,
                                                                                   (current, myWorkListAndFields)
                                                                                   =>
                                                                                   current +
                                                                                   string.Format(@"{0}:{1}|",
                                                                                                 myWorkListAndFields.Key,
                                                                                                 string.Join(",",
                                                                                                             myWorkListAndFields
                                                                                                                 .Value.
                                                                                                                 ToArray
                                                                                                                 ())));

            CoreFunctions.setConfigSetting(_web, GeneralSettingsMyWorkListsAndFields,
                                           serializedMyWorkListsAndFields.Compress());
        }

        #endregion Methods 

        #region Nested type: MWList

        public struct MWList
        {
            #region Data Members (3) 

            public string Id;
            public string Name;
            public List<string> Webs;

            #endregion Data Members 
        }

        #endregion
    }
}