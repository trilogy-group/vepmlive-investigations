using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EPMLiveCore
{
    public static class Security
    {
        public static Dictionary<string, SPRoleType> AddBasicSecurityToWorkspace(SPWeb eleWeb, string safeTitle, SPUser owner)
        {
            var safeGroupTitle = string.Empty;
            safeGroupTitle = CoreFunctions.GetSafeGroupTitle(safeTitle);

            eleWeb.AllowUnsafeUpdates = true;
            Dictionary<string, SPRoleType> pNewGroups = new Dictionary<string, SPRoleType>();
            string[] grps = new[] { "Owner", "Member", "Visitor" };
            SPGroup ownerGrp = null;

            // add groups and set group owners
            foreach (string grp in grps)
            {
                string finalName = string.Empty;
                SPGroup testGrp = null;
                try
                {
                    testGrp = eleWeb.SiteGroups[safeGroupTitle + " " + grp];
                }
                catch { }
                //Commented code is no longer use and commented to resolve Jira Id 2321
                //if (testGrp != null)
                //{
                //    finalName = testGrp.Name;
                //}
                //else
                //{
                try
                {
                finalName = CoreFunctions.AddGroup(eleWeb, safeGroupTitle, grp, owner, eleWeb.CurrentUser, string.Empty);
                eleWeb.Update();
                }
                catch { }
                //}

                SPGroup finalGrp = eleWeb.SiteGroups[finalName];
                SPRoleType rType;
                switch (grp)
                {
                    case "Owner":
                        ownerGrp = finalGrp;
                        rType = SPRoleType.Administrator;
                        finalGrp.Owner = owner;
                        finalGrp.AddUser(owner);
                        finalGrp.Update();
                        eleWeb.Update();
                        break;
                    default:
                        rType = SPRoleType.Reader;
                        finalGrp.Owner = ownerGrp;
                        finalGrp.Update();
                        eleWeb.Update();
                        break;
                }
                pNewGroups.Add(finalGrp.Name, rType);
            }

            // now set groups to become web's owner, member, visitor
            SPGroup group = null;
            SPRole roll = null;

            foreach (KeyValuePair<string, SPRoleType> g in pNewGroups)
            {
                if (g.Key.Contains("Owner"))
                {
                    group = eleWeb.SiteGroups[g.Key];
                    eleWeb.AssociatedOwnerGroup = group;
                    roll = eleWeb.Roles["Full Control"];
                    roll.AddGroup(group);
                }
                else if (g.Key.Contains("Member"))
                {
                    group = eleWeb.SiteGroups[g.Key];
                    eleWeb.AssociatedOwnerGroup = group;
                    roll = eleWeb.Roles["Contribute"];
                    roll.AddGroup(group);
                }
                else if (g.Key.Contains("Visitor"))
                {
                    group = eleWeb.SiteGroups[g.Key];
                    eleWeb.AssociatedOwnerGroup = group;
                    roll = eleWeb.Roles["Read"];
                    roll.AddGroup(group);
                }
            }

            eleWeb.Update();

            return pNewGroups;
        }
    }
}
