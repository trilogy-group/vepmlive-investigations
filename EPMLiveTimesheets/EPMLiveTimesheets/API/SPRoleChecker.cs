using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets
{
    public interface ISPRoleChecker
    {
        bool ContainsRole(SPWeb web, string roleName);
    }

    public class SPRoleChecker : ISPRoleChecker
    {
        public bool ContainsRole(SPWeb web, string roleName)
        {
            SPRoleDefinitionBindingCollection usersRoles = web.AllRolesForCurrentUser;
            SPRoleDefinitionCollection roleDefinitions = web.RoleDefinitions;
            SPRoleDefinition roleDefinition = roleDefinitions[roleName];

            return usersRoles.Contains(roleDefinition);
        }
    }
}