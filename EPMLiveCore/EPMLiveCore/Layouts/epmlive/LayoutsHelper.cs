using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    }
}