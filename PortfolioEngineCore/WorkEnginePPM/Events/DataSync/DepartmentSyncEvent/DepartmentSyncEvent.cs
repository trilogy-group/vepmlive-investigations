using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.DataSync;

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class DepartmentSyncEvent : SPItemEventReceiver
    {
        #region Methods (9) 

        // Public Methods (4) 

        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var departmentManager = new DepartmentManager(properties.Web))
                {
                    departmentManager.Synchronize(departmentManager.GetDataTable(properties.List.Items));
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            string rbs = properties.AfterProperties["RBS"] as string ?? string.Empty;

            try
            {
                if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

                object title = properties.AfterProperties["Title"];
                if (string.IsNullOrEmpty(title.ToString())) throw new Exception("Title cannot be empty.");

                object rawManagers = properties.AfterProperties["Managers"];
                if (string.IsNullOrEmpty(rawManagers.ToString()))
                    throw new Exception("Please provide at least one department manager.");

                SPWeb spWeb = properties.Web;

                var spFieldLookupValueCollection = new SPFieldLookupValueCollection((string) rawManagers);

                object managers = spFieldLookupValueCollection.Count == 0
                                      ? (object) new SPFieldLookupValue((string) rawManagers)
                                      : spFieldLookupValueCollection;

                var rawExecutives = (string) properties.AfterProperties["Executives"];

                spFieldLookupValueCollection = new SPFieldLookupValueCollection(rawExecutives);

                object executives = spFieldLookupValueCollection.Count == 0
                                        ? (object) new SPFieldLookupValue(rawExecutives)
                                        : spFieldLookupValueCollection;
                Guid uniqueId = Guid.NewGuid();

                using (var departmentManager = new DepartmentManager(spWeb))
                {
                    DataTable dataTable = departmentManager.GetDataTable(properties.List.Items);

                    DataRow dataRow = dataTable.NewRow();

                    dataRow["Title"] = title;
                    dataRow["Managers"] = new SPFieldLookupValueCollection(managers.ToString());
                    dataRow["Executives"] = new SPFieldLookupValueCollection(executives.ToString());

                    try
                    {
                        dataRow["ParentId"] = new SPFieldLookupValue(rbs).LookupId;
                    }
                    catch
                    {
                    }

                    dataRow["UniqueId"] = uniqueId;

                    dataTable.Rows.Add(dataRow);
                    dataTable = departmentManager.Synchronize(dataTable);

                    SetExtId(properties, dataTable, uniqueId);

                    UpdateDisplayName(properties);
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.ToLower().Contains("incomplete lookup list"))
                {
                    try
                    {
                        AddMissingDepartments(properties);

                        SPListItem spListItem = properties.List.Items.Add();

                        spListItem["Title"] = properties.AfterProperties["Title"];

                        var rawManagers = (string) properties.AfterProperties["Managers"];

                        var spFieldLookupValueCollection = new SPFieldLookupValueCollection(rawManagers);

                        object managers = spFieldLookupValueCollection.Count == 0
                                              ? (object) new SPFieldLookupValue(rawManagers)
                                              : spFieldLookupValueCollection;

                        var rawExecutives = (string) properties.AfterProperties["Executives"];

                        spFieldLookupValueCollection = new SPFieldLookupValueCollection(rawExecutives);

                        object executives = spFieldLookupValueCollection.Count == 0
                                                ? (object) new SPFieldLookupValue(rawExecutives)
                                                : spFieldLookupValueCollection;

                        spListItem["Managers"] = new SPFieldLookupValueCollection(managers.ToString());
                        spListItem["Executives"] = new SPFieldLookupValueCollection(executives.ToString());


                        if (!string.IsNullOrEmpty(rbs))
                        {
                            spListItem["RBS"] = new SPFieldLookupValue(rbs);
                        }

                        spListItem.Update();

                        properties.Cancel = true;
                        properties.Status = SPEventReceiverStatus.CancelNoError;
                    }
                    catch (Exception e)
                    {
                        properties.Cancel = true;
                        properties.ErrorMessage = e.Message;
                        properties.Status = SPEventReceiverStatus.CancelWithError;
                    }
                }
                else
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = exception.Message;
                    properties.Status = SPEventReceiverStatus.CancelWithError;
                }
            }
        }

        /// <summary>
        /// An item is being deleted.
        /// </summary>
        public override void ItemDeleting(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            try
            {
                using (var departmentManager = new DepartmentManager(properties.Web))
                {
                    departmentManager.Delete(properties.ListItem.ID, (string) properties.ListItem["EXTID"]);
                }
            }
            catch (Exception exception)
            {
                properties.Cancel = true;
                properties.ErrorMessage = exception.Message;
                properties.Status = SPEventReceiverStatus.CancelWithError;
            }
        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            if (!ValidateRequest(properties)) return;

            if (properties.ListItem == null) return;

            if (!properties.List.Fields.ContainsFieldWithInternalName("EXTID")) return;

            string title = null;
            string extId = null;
            SPFieldLookupValueCollection managementUsers = null;
            SPFieldLookupValueCollection executiveUsers = null;
            SPFieldLookupValue rbs = null;

            try
            {
                title = (string) (properties.AfterProperties["Title"] ?? properties.ListItem["Title"]);
                if (string.IsNullOrEmpty(title)) throw new Exception("Title cannot be empty.");

                extId = (string) (properties.AfterProperties["EXTID"] ?? properties.ListItem["EXTID"]);
                if (string.IsNullOrEmpty(extId)) throw new Exception("External ID cannot be empty.");

                var managers = (string) (properties.AfterProperties["Managers"] ?? properties.ListItem["Managers"]);
                if (string.IsNullOrEmpty(managers))
                    throw new Exception("Please provide at least one department manager.");

                managementUsers = new SPFieldLookupValueCollection(managers);

                var executives = (string) properties.AfterProperties["Executives"];
                if (string.IsNullOrEmpty(executives)) executives = string.Empty;
                executiveUsers = new SPFieldLookupValueCollection(executives);

                rbs = new SPFieldLookupValue((string) properties.AfterProperties["RBS"]);

                using (var departmentManager = new DepartmentManager(properties.Web))
                {
                    DataTable dataTable = departmentManager.GetDataTable(properties.List.Items);

                    SPListItem spListItem = properties.ListItem;

                    DataRow[] dataRows = dataTable.Select(string.Format("UniqueId = '{0}'", spListItem.UniqueId));

                    dataRows[0]["Id"] = spListItem.ID;
                    dataRows[0]["Title"] = title;
                    dataRows[0]["Managers"] = managementUsers;
                    dataRows[0]["Executives"] = executiveUsers;
                    dataRows[0]["ParentId"] = rbs.LookupId;
                    dataRows[0]["ExtId"] = extId;

                    dataTable = departmentManager.Synchronize(dataTable);

                    SetExtId(properties, dataTable, spListItem.UniqueId);
                }

                UpdateDisplayName(properties);
            }
            catch (Exception exception)
            {
                if (exception.Message.ToLower().Contains("incomplete lookup list"))
                {
                    try
                    {
                        AddMissingDepartments(properties);

                        properties.ListItem["Title"] = title;
                        properties.ListItem["Managers"] = managementUsers;
                        properties.ListItem["Executives"] = executiveUsers;
                        properties.ListItem["EXTID"] = extId;

                        try
                        {
                            properties.ListItem["RBS"] = rbs.LookupId == 0 ? null : rbs;
                        }
                        catch
                        {
                        }

                        properties.ListItem.Update();

                        properties.Cancel = true;
                        properties.Status = SPEventReceiverStatus.CancelNoError;
                    }
                    catch (Exception e)
                    {
                        properties.Cancel = true;
                        properties.ErrorMessage = e.Message;
                        properties.Status = SPEventReceiverStatus.CancelWithError;
                    }
                }
                else
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = exception.Message;
                    properties.Status = SPEventReceiverStatus.CancelWithError;
                }
            }
        }

        // Private Methods (5) 

        /// <summary>
        /// Adds the missing departments.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private void AddMissingDepartments(SPItemEventProperties properties)
        {
            DataTable pfeDepartments;
            using (var departmentManager = new DepartmentManager(properties.Web))
            {
                pfeDepartments = departmentManager.GetAllFromPFE();
            }

            using (new DisabledItemEventScope())
            {
                DataRow[] dataRows = pfeDepartments.Select("Id = 0");

                foreach (DataRow dataRow in dataRows)
                {
                    SPListItem spListItem = properties.List.Items.Add();

                    spListItem["Title"] = dataRow["Title"];
                    spListItem["EXTID"] = dataRow["ExtId"];
                    spListItem["Managers"] = dataRow["Managers"];
                    spListItem["Executives"] = dataRow["Executives"];

                    spListItem.SystemUpdate();

                    dataRow["Id"] = spListItem.ID;
                }

                foreach (DataRow dataRow in pfeDepartments.Rows)
                {
                    var title = (string) dataRow["Title"];

                    try
                    {
                        SPListItem spListItem = properties.List.GetItemById((int) dataRow["Id"]);

                        if (spListItem["Title"].Equals(title)) continue;

                        SPListItemCollection listItemCollection = properties.List.Items;
                        bool found = listItemCollection.Cast<SPListItem>().Any(listItem => listItem["Title"].Equals(title));

                        if (!found) throw new Exception("Department not found");
                    }
                    catch
                    {
                        SPListItem spListItem = properties.List.Items.Add();

                        spListItem["Title"] = title;
                        spListItem["EXTID"] = dataRow["ExtId"];
                        spListItem["Managers"] = dataRow["Managers"];
                        spListItem["Executives"] = dataRow["Executives"];

                        spListItem.SystemUpdate();

                        dataRow["Id"] = spListItem.ID;
                    }
                }

                SPListItemCollection spListItemCollection = properties.List.Items;
                Dictionary<object, int> dictionary =
                    spListItemCollection.Cast<SPListItem>().ToDictionary(i => i["EXTID"],
                                                                         i => i.ID);

                foreach (DataRow dataRow in pfeDepartments.Rows)
                {
                    var id = (int) dataRow["Id"];

                    if (properties.ListItem != null)
                    {
                        if (properties.ListItem.ID == id) continue;
                    }
                    else
                    {
                        if (properties.AfterProperties["Title"].Equals(dataRow["Title"])) continue;
                    }

                    SPListItem spListItem = properties.List.GetItemById(id);

                    var parent = (string) dataRow["Parent"];

                    if (parent.Equals("-1"))
                    {
                        spListItem["DisplayName"] = spListItem["Title"];
                        spListItem.SystemUpdate();

                        continue;
                    }

                    SPListItem parentItem = properties.List.GetItemById(dictionary[parent]);

                    spListItem["RBS"] = new SPFieldLookupValue(parentItem.ID, parentItem.Title);
                    spListItem["DisplayName"] = parentItem["DisplayName"] + "." + spListItem["Title"];

                    spListItem.SystemUpdate();
                }
            }
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        private string GetProperty(SPItemEventProperties properties, string property)
        {
            try
            {
                return properties.AfterProperties[property] != null
                           ? properties.AfterProperties[property].ToString()
                           : properties.ListItem[properties.List.Fields.GetFieldByInternalName("Title").Id].ToString();
            }
            catch
            {
            }
            return string.Empty;
        }

        /// <summary>
        /// Sets the ext id.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="uniqueId">The unique id.</param>
        private void SetExtId(SPItemEventProperties properties, DataTable dataTable, Guid uniqueId)
        {
            EventFiringEnabled = false;

            DataRow[] dataRows = dataTable.Select(string.Format("UniqueId = '{0}'", uniqueId));

            properties.AfterProperties["EXTID"] = dataRows[0]["ExtId"];

            foreach (DataRow row in dataTable.Rows)
            {
                var itemUniqueId = (Guid) row["UniqueId"];

                if (itemUniqueId == uniqueId) continue;

                SPListItem spListItem = properties.List.GetItemByUniqueId(itemUniqueId);

                spListItem["EXTID"] = row["EXTID"];
                spListItem.SystemUpdate();
            }

            EventFiringEnabled = true;
        }

        /// <summary>
        /// Updates the display name.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private void UpdateDisplayName(SPItemEventProperties properties)
        {
            try
            {
                if (properties.List.Fields.ContainsFieldWithInternalName("DisplayName") &&
                    properties.List.Fields.ContainsFieldWithInternalName("RBS"))
                {
                    string title = GetProperty(properties, "Title");
                    string parent = GetProperty(properties, "RBS");

                    if (!string.IsNullOrEmpty(title))
                    {
                        if (!string.IsNullOrEmpty(parent))
                        {
                            var lv = new SPFieldLookupValue(parent);

                            SPListItem liParent = properties.List.GetItemById(lv.LookupId);

                            properties.AfterProperties["DisplayName"] =
                                liParent[properties.List.Fields.GetFieldByInternalName("DisplayName").Id] + "." + title;
                        }
                        else
                        {
                            properties.AfterProperties["DisplayName"] = title;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private bool ValidateRequest(SPItemEventProperties properties)
        {
            return properties.OpenSite().Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null &&
                   properties.List.Title.Equals("Departments");
        }

        #endregion Methods 
    }
}