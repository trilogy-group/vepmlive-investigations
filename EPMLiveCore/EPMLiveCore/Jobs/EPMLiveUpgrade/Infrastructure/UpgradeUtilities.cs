using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure
{
    internal static class UpgradeUtilities
    {
        #region Methods (4) 

        // Public Methods (1) 

        public static string ScheduleReportingRefresh(SPWeb spWeb)
        {
            return CoreFunctions.ScheduleReportingRefreshJob(spWeb);
        }

        // Internal Methods (3) 

        internal static List<Type> GetUpgradeSteps(string version)
        {
            var versionedSteps = new Dictionary<double, Type>();
            var genericSteps = new Dictionary<double, Type>();

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.BaseType != typeof (UpgradeStep)) continue;

                var attribute =
                    type.GetCustomAttributes(typeof (UpgradeStepAttribute), true).FirstOrDefault() as
                        UpgradeStepAttribute;

                if (attribute == null) continue;

                if (attribute.Version == EPMLiveVersion.GENERIC)
                {
                    genericSteps.Add(attribute.SequenceOrder, type);
                }
                else
                {
                    bool add = false;

                    if (string.IsNullOrEmpty(version))
                    {
                        if (!attribute.IsOptIn) add = true;
                    }
                    else
                    {
                        if (attribute.IsOptIn && attribute.Name.StartsWith(version)) add = true;
                    }

                    if (add) versionedSteps.Add(attribute.SequenceOrder, type);
                }
            }

            List<Type> steps = versionedSteps.OrderBy(s => s.Key).Select(s => s.Value).ToList();
            steps.AddRange(genericSteps.OrderBy(s => s.Key).Select(source => source.Value));

            return steps;
        }

        internal static SPField TryAddField(string internalName, string displayName, SPFieldType spFieldType,
            SPList spList, out string message, out MessageKind messageKind)
        {
            if (string.IsNullOrEmpty(internalName)) throw new ArgumentNullException("internalName");
            if (string.IsNullOrEmpty(displayName)) throw new ArgumentNullException("displayName");
            if (spList == null) throw new ArgumentNullException("spList");

            if (spList.Fields.ContainsFieldWithInternalName(internalName))
            {
                message = @"Field already exists.";
                messageKind = MessageKind.SKIPPED;

                return null;
            }

            SPField spField = spList.Fields.CreateNewField(spFieldType.ToString(), internalName);
            spList.Fields.Add(spField);
            spList.Update();

            SPField field = spList.Fields.GetFieldByInternalName(internalName);
            field.Title = displayName;
            field.Update();

            message = @"Field successfully added.";
            messageKind = MessageKind.SUCCESS;

            return field;
        }

        internal static void UpdateNodeLink(string url, int appId, SPNavigationNode node, SPWeb spWeb,
            out string message,
            out MessageKind messageKind)
        {
            spWeb.AllowUnsafeUpdates = true;

            messageKind = MessageKind.SUCCESS;

            SPList spList = spWeb.Lists.TryGetList("Installed Applications");
            if (spList != null)
            {
                message = string.Format(@"Node: {0}, New URL: {1}, Old URL: {2}", node.Title, url, node.Url);

                var newNode = new SPNavigationNode(node.Title, url, node.IsExternal);

                SPNavigationNode prevNode = null;

                foreach (SPNavigationNode siblingNode in spWeb.Navigation.QuickLaunch.Cast<SPNavigationNode>()
                    .TakeWhile(siblingNode => siblingNode.Id != node.Id))
                {
                    prevNode = siblingNode;
                }

                if (prevNode == null)
                {
                    spWeb.Navigation.QuickLaunch.AddAsLast(newNode);
                }
                else
                {
                    spWeb.Navigation.QuickLaunch.Add(newNode, prevNode);
                }

                node.Delete();

                SPListItem spListItem = spList.GetItemById(appId);

                string nodes = (spListItem["QuickLaunch"] ?? string.Empty).ToString()
                    .Replace(node.Id.ToString(CultureInfo.InvariantCulture),
                        newNode.Id.ToString(CultureInfo.InvariantCulture));

                if (!nodes.Contains("," + newNode.Id))
                {
                    nodes += "," + newNode.Id;
                }

                spListItem["QuickLaunch"] = nodes;
                spListItem.SystemUpdate();

                API.Applications.CreateQuickLaunchXML(spListItem.ID, spWeb);

                spWeb.AllowUnsafeUpdates = false;
                spWeb.Update();
            }
            else
            {
                throw new Exception("Cannot find the Installed Applications list.");
            }
        }

        #endregion Methods 
    }
}
