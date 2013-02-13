using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using System.Threading;
using System.ComponentModel;
using System.Collections;


namespace EPMLiveCore
{
    public class ChildParentSync : SPItemEventReceiver
    {
        public override void ItemUpdating(SPItemEventProperties properties)
        {

            if(properties.AfterProperties["ChildItem"] != null || properties.AfterProperties["ParentItem"] != null)
                return;

            bool bWorkspaceDriven = true;
            string pcGuid = "";
            bool isCopyingToParent = false;

            try
            {
                pcGuid = properties.ListItem["ChildItem"].ToString();
            }
            catch { }
            try{
                pcGuid = properties.ListItem["ParentItem"].ToString();
                isCopyingToParent = true;

                try
                {
                    bWorkspaceDriven = bool.Parse(properties.AfterProperties["WorkspaceDriven"].ToString());
                }
                catch
                {
                    try
                    {
                        bWorkspaceDriven = bool.Parse(properties.ListItem["WorkspaceDriven"].ToString());
                    }
                    catch { }
                }

            }
            catch { }

            if(pcGuid != "" && bWorkspaceDriven)
            {

                string[] itemInfo = pcGuid.Split('.');

                try
                {
                    Guid WebId = properties.Web.ID;
                    SPWeb pWeb = properties.Web;
                    Guid ListId = properties.ListId;
                    int ListItemId = properties.ListItemId;
                    SPList parentList = properties.List;
                    
                    ArrayList IgnoreFields = new ArrayList();
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using(SPSite site = properties.OpenSite())
                        {
                            using(SPWeb web = site.OpenWeb(new Guid(itemInfo[0])))
                            {
                                SPList list = web.Lists[new Guid(itemInfo[1])];

                                SPListItem li = list.GetItemById(int.Parse(itemInfo[2]));

                                if(isCopyingToParent)
                                {
                                    li["ChildItem"] = WebId + "." + ListId + "." + ListItemId;
                                    IgnoreFields = new ArrayList(CoreFunctions.getConfigSetting(web, "EPMLiveCPSyncIgnore").ToLower().Split(','));
                                }
                                else
                                {
                                    li["ParentItem"] = WebId + "." + ListId + "." + ListItemId;
                                    IgnoreFields = new ArrayList(CoreFunctions.getConfigSetting(pWeb, "EPMLiveCPSyncIgnore").ToLower().Split(','));
                                }

                                foreach(SPField f in parentList.Fields)
                                {
                                    if(!f.ReadOnlyField && f.Reorderable && !IgnoreFields.Contains(f.InternalName.ToLower()))
                                    {
                                        try
                                        {
                                            SPField parentField = list.Fields.GetFieldByInternalName(f.InternalName);

                                            if(properties.AfterProperties[f.InternalName] != null)
                                            {
                                                li[parentField.Id] = properties.AfterProperties[f.InternalName];
                                            }
                                            else
                                            {
                                                if(properties.List.Fields.ContainsFieldWithInternalName(f.InternalName))
                                                {
                                                    try
                                                    {
                                                        li[parentField.Id] = properties.ListItem[f.Id];
                                                    }
                                                    catch { }
                                                }
                                            }

                                        }
                                        catch { }
                                    }
                                }

                                li.SystemUpdate();
                            }
                        }
                    });
                }
                catch { }
            }

        }
    }
}
