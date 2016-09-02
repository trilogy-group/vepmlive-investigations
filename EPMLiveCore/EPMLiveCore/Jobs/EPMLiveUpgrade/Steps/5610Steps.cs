using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V5610, Order = 1.0, Description = "Remove management of personal views from Contribute2 permission level")]
    internal class RemoveManagementOfPersonalViewsFromContribute2 : UpgradeStep
    {
        public RemoveManagementOfPersonalViewsFromContribute2(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite) { }

        public override bool Perform()
        {
            LogMessage("Removing management of personal views from Contribute2 permission level", 2);
            try
            {

                Web.AllowUnsafeUpdates = true;
                SPRoleDefinition roleDef = Web.RoleDefinitions["Contribute2"];
                if (roleDef.BasePermissions.ToString().Contains(SPBasePermissions.ManagePersonalViews.ToString()))
                {
                    roleDef.BasePermissions &= ~SPBasePermissions.ManagePersonalViews;
                    roleDef.Update();
                    Web.Update();
                    LogMessage("Removed management of personal views from Contribute2 permission level", MessageKind.SUCCESS, 4);
                }
                else
                {
                    LogMessage("Management of personal views already removed from Contribute2 permission level.", MessageKind.SKIPPED, 4);
                }
                Web.AllowUnsafeUpdates = false;
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, MessageKind.FAILURE, 4);
            }
            return true;
        }
    }
}
