﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Diagnostics;
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

        public static void ProcessPermissionStrings(SPWeb web, IEnumerable<string> strOuter, DataTable groupsPermissions)
        {
            if (web == null)
            {
                throw new ArgumentNullException(nameof(web));
            }
            if (strOuter == null)
            {
                throw new ArgumentNullException(nameof(strOuter));
            }
            if (groupsPermissions == null)
            {
                throw new ArgumentNullException(nameof(groupsPermissions));
            }

            foreach (var strInner in strOuter)
            {
                var strInnerMost = strInner.Split('~');
                var dataRow = groupsPermissions.NewRow();
                SPGroup spGroup = null;
                SPRoleDefinition roleDefinition = null;

                try
                {
                    spGroup = web.SiteGroups.GetByID(Convert.ToInt32(strInnerMost[0]));
                    roleDefinition = web.RoleDefinitions.GetById(Convert.ToInt32(strInnerMost[1]));
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
                if (spGroup != null && roleDefinition != null)
                {
                    dataRow["GroupsText"] = spGroup.Name;
                    dataRow["GroupsID"] = strInnerMost[0];
                    dataRow["PermissionsText"] = roleDefinition.Name;
                    dataRow["PermissionsID"] = strInnerMost[1];
                    groupsPermissions.Rows.Add(dataRow);
                }
            }
        }

        public static readonly string LIST_ITEM_HTML =
            "<li id=\"{0}\" class=\"ms-core-menu-item\" type=\"option\" menugroupid=\"100\" description=\"{1}\" text=\"{2}\""
            + "iconsrc=\"{3}\" type=\"option\" enabled=\"true\" checked=\"false\""
            + "text_original=\"{2}\" description_original=\"{1}\">"
            + "<a class=\"ms-core-menu-link\" href=\"{4}\" onclick=\"{5}\" >"
            + "<div class=\"ms-hide\">"
            + "<img id=\"mp1_0_0_ICON\" title=\"\" alt=\"\" src=\"/_layouts/15/images/menuprofile.gif?rev=23\" width=\"32\" height=\"32\">"
            + "</div>"
            + "<div id=\"zz2_ID_PersonalInformation\" class=\"ms-core-menu-label\">"
            + "<span class=\"ms-core-menu-title\">{2}</span>"
            + "<span></span>"
            + "</div>"
            + "<span class=\"ms-accessible\"></span>"
            + "<div></div>"
            + "</a>"
            + "</li>";

        public static void SimplePageLoad(HttpResponse httpResponse, HttpRequest httpRequest, ref string requestUrl, string buildListItemHtml)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException(nameof(httpResponse));
            }
            if (httpRequest == null)
            {
                throw new ArgumentNullException(nameof(httpRequest));
            }

            httpResponse.Cache.SetCacheability(HttpCacheability.NoCache);
            httpResponse.Expires = -1;
            httpResponse.ContentEncoding = Encoding.UTF8;

            const string RequestUrl = "requesturl";

            if (!string.IsNullOrWhiteSpace(httpRequest[RequestUrl]))
            {
                requestUrl = httpRequest[RequestUrl];
            }

            var retVal = buildListItemHtml;

            httpResponse.Output.WriteLine(
                !string.IsNullOrWhiteSpace(retVal)
                    ? retVal
                    : string.Empty);
        }
    }
}