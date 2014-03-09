using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using EPMLiveCore.API;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    internal class ListEvents : SPItemEventReceiver
    {
        private ReportData _DAO;
        private Guid _ListID;
        private string _ListName;
        private Guid _SiteID;
        private string _SiteName;
        private string _SiteUrl;
        private string _TableName;
        private ArrayList _arrayList_defaultColumns;
        private DataTable _dtColumns;
        private SPListItem _item;
        private ArrayList _mandatoryHiddenFlds;
        private SPItemEventProperties _properties;

        public override void ItemAdded(SPItemEventProperties properties)
        {
            try
            {
                //Initialize global variables
                if (Initialize(true, properties))
                {
                    //InsertItem
                    InsertItem(properties);
                }
                //Dispose of DAO 
                _DAO.Dispose();
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    if (!EventLog.SourceExists("EPMLive Reporting Item Added"))
                        EventLog.CreateEventSource("EPMLive Reporting Item Added", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting Item Added");
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(
                        "Name: " + _SiteName + " Url: " + _SiteUrl + " ID: " + _SiteID + " : " + ex.Message +
                        ex.StackTrace, EventLogEntryType.Error, 2001);
                });
            }
            finally
            {
                ClearResourceGridCache(properties);
                SocialEngineEvents.ItemAdded(properties);
            }
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            try
            {
                //Initialize global variables
                if (Initialize(true, properties))
                {
                    //UpdateItem
                    UpdateItem(properties);
                }

                //Dispose of DAO 
                _DAO.Dispose();
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    if (!EventLog.SourceExists("EPMLive Reporting Item Updated"))
                        EventLog.CreateEventSource("EPMLive Reporting Item Updated", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting Item Updated");
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(
                        "Name: " + _SiteName + " Url: " + _SiteUrl + " ID: " + _SiteID + " : " + ex.Message +
                        ex.StackTrace, EventLogEntryType.Error, 2002);
                });
            }
            finally
            {
                ClearResourceGridCache(properties);
                SocialEngineEvents.ItemUpdated(properties);
            }
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            try
            {
                if (Initialize(true, properties))
                {
                    //DeleteItem
                    DeleteItem();

                    ////Check IF list reports work
                    //if (_DAO.ListReportsWork(_TableName))
                    //{
                    //    _DAO.DeleteWork(_ListID, _properties.ListItemId);
                    //}
                }

                //Dispose of DAO 
                _DAO.Dispose();
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    if (!EventLog.SourceExists("EPMLive Reporting Item Deleting"))
                        EventLog.CreateEventSource("EPMLive Reporting Item Deleting", "EPM Live");

                    var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting Item Deleting");
                    myLog.MaximumKilobytes = 32768;
                    myLog.WriteEntry(
                        "Name: " + _SiteName + " Url: " + _SiteUrl + " ID: " + _SiteID + " : " + ex.Message +
                        ex.StackTrace, EventLogEntryType.Error, 2003);
                });
            }
            finally
            {
                ClearResourceGridCache(properties);
                SocialEngineEvents.ItemDeleting(properties);
            }
        }

        private void InsertItem(SPItemEventProperties properties)
        {
            //InsertListItem record into DB
            if (_DAO.InsertListItem(GetSql("insert")))
            {
                //Check IF list reports work
                //if (_DAO.ListReportsWork(_TableName))
                //{
                //    //Save list item "work" field values
                //    SaveWork();
                //}
                ProcessSecurity(properties, _DAO.GetClientReportingConnection());
            }
            else
            {
                _DAO.LogStatus(_DAO.GetListId(_ListName), _ListName.Replace("'", ""),
                    "Url:" + _properties.RelativeWebUrl.Replace("'", "") + " Error: Add item was unsuccessful.",
                    _DAO.GetError(), 2, 1); // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        private void ProcessSecurity(SPItemEventProperties properties, SqlConnection cn)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                try
                {
                    using (var site = new SPSite(properties.SiteId))
                    {
                        using (SPWeb web = site.OpenWeb(properties.Web.ID))
                        {
                            SPList list = web.Lists[properties.ListId];
                            SPListItem li = list.GetItemById(properties.ListItemId);

                            var cmd =
                                new SqlCommand(
                                    "DELETE RPTITEMGROUPS where siteid=@siteid and listid=@listid and itemid=@itemid",
                                    cn);
                            cmd.Parameters.AddWithValue("@siteid", properties.SiteId);
                            cmd.Parameters.AddWithValue("@listid", properties.ListId);
                            cmd.Parameters.AddWithValue("@itemid", properties.ListItemId);
                            cmd.ExecuteNonQuery();

                            foreach (SPRoleAssignment ra in li.RoleAssignments)
                            {
                                int type = 0;
                                if (ra.Member.GetType() == typeof (SPGroup))
                                {
                                    type = 1;
                                }
                                bool found = false;
                                foreach (SPRoleDefinition def in ra.RoleDefinitionBindings)
                                {
                                    if ((def.BasePermissions & SPBasePermissions.ViewListItems) ==
                                        SPBasePermissions.ViewListItems)
                                        found = true;
                                }
                                if (found)
                                {
                                    cmd =
                                        new SqlCommand(
                                            "INSERT INTO RPTITEMGROUPS (SITEID, LISTID, ITEMID, GROUPID, SECTYPE) VALUES (@siteid, @listid, @itemid, @groupid, @sectype)",
                                            cn);
                                    cmd.Parameters.AddWithValue("@siteid", properties.SiteId);
                                    cmd.Parameters.AddWithValue("@listid", properties.ListId);
                                    cmd.Parameters.AddWithValue("@itemid", properties.ListItemId);
                                    cmd.Parameters.AddWithValue("@groupid", ra.Member.ID);
                                    cmd.Parameters.AddWithValue("@sectype", type);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            cmd =
                                new SqlCommand(
                                    "INSERT INTO RPTITEMGROUPS (SITEID, LISTID, ITEMID, GROUPID, SECTYPE) VALUES (@siteid, @listid, @itemid, @groupid, @sectype)",
                                    cn);
                            cmd.Parameters.AddWithValue("@siteid", properties.SiteId);
                            cmd.Parameters.AddWithValue("@listid", properties.ListId);
                            cmd.Parameters.AddWithValue("@itemid", properties.ListItemId);
                            cmd.Parameters.AddWithValue("@groupid", 999999);
                            cmd.Parameters.AddWithValue("@sectype", 1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch { }
            });
        }

        private void UpdateItem(SPItemEventProperties properties)
        {
            //InsertListItem record into DB
            if (_DAO.UpdateListItem(GetSql("update")))
            {
                ProcessSecurity(properties, _DAO.GetClientReportingConnection());
                //Check IF list reports work
                //if (_DAO.ListReportsWork(_TableName))
                //{
                //    //Save list item "work" field values
                //    SaveWork();
                //}
            }
            else
            {
                _DAO.LogStatus(_DAO.GetListId(_ListName), _ListName.Replace("'", ""),
                    "Url:" + _properties.RelativeWebUrl.Replace("'", "") + " Error: Update item was unsuccessful.",
                    _DAO.GetError(), 2, 1); // - CAT.NET false-positive: All single quotes are escaped/removed.
            }
        }

        private void DeleteItem()
        {
            _DAO.DeleteListItem(GetSql("delete"));
        }

        // -- HELPER FUNCTIONS -- START
        private bool Initialize(bool blnPopulateCols, SPItemEventProperties properties)
        {
            try
            {
                //Initialize siteID, listID, listItem
                _SiteID = properties.SiteId;
                _ListID = properties.ListId;
                _item = properties.ListItem;
                _properties = properties;
                _ListName = properties.ListTitle;

                //Init. Data Access Object
                _DAO = new ReportData(_SiteID);
                _SiteName = _DAO.SiteName;
                _SiteUrl = _DAO.SiteUrl;

                //Init. list sql table name
                _TableName = _DAO.GetTableName(_ListName);

                if (_TableName == null || _TableName == string.Empty)
                {
                    return false;
                }

                //IF item DELETED no need to populate columns
                if (blnPopulateCols)
                {
                    PopulateDefaultColumns();
                    PopulateMandatoryHiddenFields();
                    PopulateColumns();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void PopulateDefaultColumns()
        {
            _arrayList_defaultColumns = new ArrayList();
            _arrayList_defaultColumns.Add("siteid");
            _arrayList_defaultColumns.Add("webid");
            _arrayList_defaultColumns.Add("listid");
            _arrayList_defaultColumns.Add("itemid");
            _arrayList_defaultColumns.Add("weburl");
        }

        private void PopulateMandatoryHiddenFields()
        {
            _mandatoryHiddenFlds = new ArrayList();
            _mandatoryHiddenFlds.Add("commenters");
            _mandatoryHiddenFlds.Add("commentersread");
            _mandatoryHiddenFlds.Add("commentcount");
            _mandatoryHiddenFlds.Add("workspaceurl");
        }

        private void PopulateColumns()
        {
            _dtColumns = _DAO.GetListColumns(_ListName.Replace("'", ""));
                // - CAT.NET false-positive: All single quotes are escaped/removed.
        }

        private string GetSql(string sAction)
        {
            string sSQL = string.Empty;
            switch (sAction)
            {
                case "insert":
                    sSQL = _DAO.InsertSQL(_TableName.Replace("'", ""), _dtColumns, _item, _arrayList_defaultColumns,
                        _mandatoryHiddenFlds); // - CAT.NET false-positive: All single quotes are escaped/removed.
                    break;

                case "update":
                    sSQL = _DAO.UpdateSQL(_TableName.Replace("'", ""), _dtColumns, _item, _arrayList_defaultColumns,
                        _mandatoryHiddenFlds); // - CAT.NET false-positive: All single quotes are escaped/removed.
                    break;

                case "delete":
                    sSQL = _DAO.DeleteSQL(_TableName.Replace("'", ""), _ListID, _item.ID);
                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                    break;
            }
            return sSQL;
        }

        private void ClearResourceGridCache(SPItemEventProperties properties)
        {
            try
            {
                string listName = properties.ListTitle.ToLower();

                if (listName.Equals("resources") || listName.Equals("departments"))
                {
                    ResourceGrid.ClearCache(properties.Web);
                }
            }
            catch { }
        }
    }
}