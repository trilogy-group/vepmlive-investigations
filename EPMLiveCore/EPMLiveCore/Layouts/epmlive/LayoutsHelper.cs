using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public static class LayoutsHelper
    {
        public static void HandleGridPermanentAddClickEvent(
            StateBag viewState,
            ref DataTable groupsPermissions,
            DropDownList groupsDropDownList,
            DropDownList spPermissionsDropDownList,
            SPGridView gvGroupsPermissions,
            Button button)
        {
            if (viewState == null)
            {
                throw new ArgumentNullException(nameof(viewState));
            }
            if (groupsDropDownList == null)
            {
                throw new ArgumentNullException(nameof(groupsDropDownList));
            }
            if (spPermissionsDropDownList == null)
            {
                throw new ArgumentNullException(nameof(spPermissionsDropDownList));
            }
            if (gvGroupsPermissions == null)
            {
                throw new ArgumentNullException(nameof(gvGroupsPermissions));
            }
            if (button == null)
            {
                throw new ArgumentNullException(nameof(button));
            }

            if (viewState["dtGroupsPermissions"] != null)
            {
                groupsPermissions = (DataTable)viewState["dtGroupsPermissions"];
                var dataRow = groupsPermissions.NewRow();
                dataRow["GroupsText"] = groupsDropDownList.Items[groupsDropDownList.SelectedIndex].Text;
                dataRow["GroupsID"] = groupsDropDownList.Items[groupsDropDownList.SelectedIndex].Value;
                dataRow["PermissionsText"] = spPermissionsDropDownList.Items[spPermissionsDropDownList.SelectedIndex].Text;
                dataRow["PermissionsID"] = spPermissionsDropDownList.Items[spPermissionsDropDownList.SelectedIndex].Value;

                var blnRecordExists = false;
                foreach (DataRow row in groupsPermissions.Rows)
                {
                    if ($"{row["GroupsID"]};{row["PermissionsID"]}"
                        == $"{groupsDropDownList.Items[groupsDropDownList.SelectedIndex].Value};{spPermissionsDropDownList.Items[spPermissionsDropDownList.SelectedIndex].Value}"
                    )
                    {
                        blnRecordExists = true;
                        break;
                    }
                }

                if (!blnRecordExists)
                {
                    groupsPermissions.Rows.Add(dataRow);
                    gvGroupsPermissions.DataSource = groupsPermissions;
                    gvGroupsPermissions.DataBind();
                    viewState["dtGroupsPermissions"] = groupsPermissions;
                }
            }

            button.Focus();
        }

        public static void LoadHeadingDropDownListHelper(
            bool checkCondition,
            string nodeType,
            SPWeb spWeb,
            int appId,
            AppSettingsHelper appSettingsHelper,
            DropDownList dropDownList,
            SPNavigationNode currentSpNavigationNode)
        {
            if (spWeb == null)
            {
                throw new ArgumentNullException(nameof(spWeb));
            }
            if (appSettingsHelper == null)
            {
                throw new ArgumentNullException(nameof(appSettingsHelper));
            }
            if (dropDownList == null)
            {
                throw new ArgumentNullException(nameof(dropDownList));
            }

            if (checkCondition)
            {
                SPNavigationNodeCollection coll = null;

                const string TopNavNodeType = "topnav";
                const string QuickLaunchNodeType = "quiklnch";

                switch (nodeType)
                {
                    case TopNavNodeType:
                        coll = spWeb.Navigation.TopNavigationBar;
                        break;
                    case QuickLaunchNodeType:
                        coll = spWeb.Navigation.QuickLaunch;
                        break;
                }

                var navIds = new List<int>();

                if (appId != -1)
                {
                    switch (nodeType)
                    {
                        case TopNavNodeType:
                            navIds = appSettingsHelper.TryGetTopNavIdsByAppId(appId);
                            break;
                        case QuickLaunchNodeType:
                            navIds = appSettingsHelper.TryGetQuickLaunchIdsByAppId(appId);
                            break;
                    }
                }

                foreach (SPNavigationNode node in coll)
                {
                    if (navIds.Count > 0)
                    {
                        if (navIds.Contains(node.Id))
                        {
                            dropDownList.Items.Add(new ListItem(node.Title, node.Id.ToString()));
                        }
                    }
                    else
                    {
                        dropDownList.Items.Add(new ListItem(node.Title, node.Id.ToString()));
                    }
                }

                if (currentSpNavigationNode != null)
                {
                    dropDownList.SelectedValue = currentSpNavigationNode.ParentId.ToString();
                }
            }
        }
    }
}