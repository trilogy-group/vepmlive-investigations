using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class ItemEnableTeamEvent : SPItemEventReceiver
    {
        #region Fields

        private Guid _siteId;
        private Guid _listId;
        private string _webUrl;
        private SPListItem _listItem;
        private string _itemTitle;
        private int _itemId;
        private string _siteName;
        private string _siteUrl;
        private string _listName;
        private SPItemEventProperties _properties;
        private GridGanttSettings _settings;

        #endregion Fields

        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (Initialize(properties))
            {
                SPUser orignalUser = properties.Web.CurrentUser;

                //SPSecurity.RunWithElevatedPrivileges(delegate()
                //{
                //    using (SPSite es = new SPSite(properties.WebUrl))
                //    {
                //        using (SPWeb ew = es.OpenWeb())
                //        {
                SPWeb ew = properties.Web;
                SPList el = properties.List;
                SPListItem ei = properties.ListItem;

                #region ADD ITEM CREATOR TO TEAM BY DEFAULT

                SPFieldLookup assignedTo = null;
                try
                {
                    assignedTo = el.Fields.GetFieldByInternalName("AssignedTo") as SPFieldLookup;
                }
                catch { }

                object assignedToFv = null;
                string sAssignedTo = string.Empty;
                try
                {
                    assignedToFv = ei["AssignedTo"];
                }
                catch { }
                if (assignedToFv != null)
                {
                    sAssignedTo = assignedToFv.ToString();
                }

                SPFieldUserValueCollection uCol = new SPFieldUserValueCollection();

                if (!string.IsNullOrEmpty(sAssignedTo))
                {
                    uCol = new SPFieldUserValueCollection(ew, sAssignedTo);
                }

                if (assignedTo.AllowMultipleValues)
                {
                    uCol.Add(new SPFieldUserValue(ew, orignalUser.ID, orignalUser.LoginName));
                    ei["AssignedTo"] = uCol;
                }
                else
                {
                    ei["AssignedTo"] = new SPFieldUserValue(ew, orignalUser.ID, orignalUser.LoginName);
                }

                EventFiringEnabled = false;
                try
                {
                    ei.Update();
                }
                catch (Exception e)
                {
                }
                EventFiringEnabled = true;

                #endregion
                //        }
                //    }
                //});
            }
        }

        private bool Initialize(SPItemEventProperties properties)
        {
            try
            {
                _listName = properties.ListTitle;
                _siteId = properties.SiteId;
                _webUrl = properties.WebUrl;
                _listId = properties.ListId;
                _listItem = properties.ListItem;
                _itemTitle = _listItem != null ?
                    (!string.IsNullOrEmpty(_listItem.Title) ? _listItem.Title : string.Empty) : string.Empty;
                _itemId = _listItem != null ? _listItem.ID : -1;
                _properties = properties;
                _settings = new GridGanttSettings(properties.List);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
