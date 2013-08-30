using EPMLiveCore.API;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore
{
    public class ItemWorkspaceEventReceiver : SPItemEventReceiver
    {
        #region Fields

        private string _siteId = string.Empty;
        private string _webId = string.Empty;
        private string _listId = string.Empty;
        private string _itemTitle = string.Empty;
        private string _itemId = string.Empty;
        private string _createFromLiveTemp = string.Empty;
        private string _creationParams = string.Empty;
        private string _templateId = string.Empty;
        private GridGanttSettings _settings;

        #endregion Fields

        public override void ItemAdded(SPItemEventProperties properties)
        {
            if (Initialize(properties))
            {
                if (_settings.BuildTeamSecurity)
                {
                    WorkspaceTimerjobAgent.AddCreateWorkspaceJobAndWait(_creationParams);
                }
                else
                {
                    WorkspaceTimerjobAgent.AddAndQueueCreateWorkspaceJob(_creationParams);
                }
            }
        }

        private bool FieldExistsInList(SPList list, string fieldInternalName)
        {
            SPField testFld = null;
            try { testFld = list.Fields.GetFieldByInternalName(fieldInternalName); }
            catch { }
            return (testFld != null);
        }

        //private void SetUrlFieldMessage(SPItemEventProperties properties)
        //{
        //    EventFiringEnabled = false;

        //    SPSecurity.RunWithElevatedPrivileges(() => 
        //    {
        //        using (SPSite s = new SPSite(properties.SiteId))
        //        {
        //            using (SPWeb w = s.OpenWeb(properties.Web.ID))
        //            {
        //                SPList l = w.Lists[properties.ListId];
        //                SPListItem i = l.GetItemById(properties.ListItemId);
        //                if (!FieldExistsInList(l, "WorkspaceUrl"))
        //                {
        //                    string fldWorkspaceUrlIntName = l.Fields.Add("WorkspaceUrl", SPFieldType.URL, false);
        //                    SPFieldUrl fldWorkspaceUrl = l.Fields.GetFieldByInternalName(fldWorkspaceUrlIntName) as SPFieldUrl;
        //                    fldWorkspaceUrl.Update();
        //                }
        //                i["WorkspaceUrl"] = new SPFieldUrlValue() { Description = "Waiting for security to complete." };
        //                i.SystemUpdate();
        //            }
        //        }
        //    });

        //    EventFiringEnabled = true;
        //}

        private bool Initialize(SPItemEventProperties properties)
        {
            try
            {
                _siteId = properties.SiteId.ToString();
                _webId = properties.Web.ID.ToString();
                _listId = properties.ListId.ToString();
                _itemTitle = properties.ListItem.Title;
                _itemId = properties.ListItem.ID.ToString();
                _settings = new GridGanttSettings(properties.List);

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var s = new SPSite(properties.SiteId))
                    {
                        using (var lockedWeb = s.OpenWeb(CoreFunctions.getLockedWeb(properties.Web)))
                        {
                            _createFromLiveTemp = CoreFunctions.getConfigSetting(lockedWeb, "EPMLiveUseLiveTemplates");
                        }
                    }
                });

                _creationParams = "<Data>" +
                                    "<Param key=\"IsStandAlone\">false</Param>" +
                                    "<Param key=\"TemplateSource\">downloaded</Param>" +
                                    "<Param key=\"TemplateItemId\">" + _settings.AutoCreationTemplateId + "</Param>" +
                                    "<Param key=\"IncludeContent\">True</Param>" +
                                    "<Param key=\"SiteTitle\">" + _itemTitle + "</Param>" +
                                    "<Param key=\"AttachedItemId\">" + _itemId + "</Param>" +
                                    "<Param key=\"AttachedItemListGuid\">" + _listId + "</Param>" +
                                    "<Param key=\"WebUrl\">" + properties.Web.Url + "</Param>" +
                                    "<Param key=\"WebId\">" + properties.Web.ID.ToString() + "</Param>" +
                                    "<Param key=\"SiteId\">" + _siteId.ToString() + "</Param>" +
                                    "<Param key=\"CreatorId\">" + properties.Web.CurrentUser.ID.ToString() + "</Param>" +
                                    "<Param key=\"CreateFromLiveTemp\">" + _createFromLiveTemp + "</Param>" +
                                    "<Param key=\"UniquePermission\">" + properties.ListItem.HasUniqueRoleAssignments.ToString() + "</Param>" +
                                "</Data>";
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
