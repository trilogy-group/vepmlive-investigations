using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;

namespace EPMLive.TestFakes.Utility
{
    public class SharepointShims
    {
        public ShimSPWeb WebShim { get; private set; }
        public ShimSPSite SiteShim { get; private set; }
        public ShimSPListItem ListItemShim { get; private set; }
        public ShimSPListItemCollection ListItemsShim { get; private set; }
        public ShimSPList ListShim { get; private set; }
        public ShimSPListCollection ListsShim { get; private set; }
        public ShimSPUser UserShim { get; private set; }
        public ShimSPUserCollection UsersShim { get; private set; }
        public ShimSPWebApplication ApplicationShim { get; private set; }
        public ShimSPFieldUserValue FieldUserValueShim { get; private set; }
        public ShimSPFieldUserValueCollection FieldUserValuesShim { get; private set; }
        public ShimSPRoleAssignment RoleAssignmentShim { get; private set; }
        public ShimSPRoleAssignmentCollection RoleAssignmentsShim { get; private set; }
        public ShimSPPrincipal PrincipalShim { get; private set; }
        public ShimSPGroup GroupShim { get; private set; }
        public ShimSPGroupCollection GroupsShim { get; private set; }
        public ShimSPForm FormShim { get; private set; }
        public ShimSPFormCollection FormsShim { get; private set; }
        public ShimSPField FieldShim { get; private set; }
        public ShimSPFieldCollection FieldsShim { get; private set; }

        public string ServerRelativeUrl { get; private set; }
        public string WorkspaceUrl { get; private set; }

        public bool IsDbUpdateExecuted { get; private set; }

        private SharepointShims(
            string serverRelativeUrl = "test-server-url",
            string workspaceUrl = "test-workspace-url")
        {
            ServerRelativeUrl = serverRelativeUrl;
            WorkspaceUrl = workspaceUrl;

            UserShim = InitializeSPUserShim();
            UsersShim = InitializeSPUsersShim();
            FieldUserValueShim = InitializeSPFieldUserValueShim();
            FieldUserValuesShim = InitializeSPFieldUserValuesShim();
            RoleAssignmentShim = InitializeSPRoleAssignmentShim();
            RoleAssignmentsShim = InitializeSPRoleAssignmentsShim();
            ApplicationShim = InitializeSPApplicationShim();
            GroupShim = InitializeSPGroupShim();
            GroupsShim = InitializeSPGroupsShim();
            FormShim = InitializeSPFormShim();
            FormsShim = InitializeSPFormsShim();
            FieldShim = InitializeSPFieldShim();
            FieldsShim = InitializeSPFieldsShim();
            PrincipalShim = InitializeSPPrincipalShim();
            SiteShim = InitializeSPSiteShim();
            ListItemShim = InitializeSPListItemShim();
            ListItemsShim = InitializeSPListItemCollectionShim();
            ListShim = InitializeSPListShim();
            ListsShim = InitializeSPListCollectionShim();
            WebShim = InitializeSPWebShim();
        }

        private ShimSPField InitializeSPFieldShim()
        {
            return new ShimSPField();
        }

        private ShimSPFieldCollection InitializeSPFieldsShim()
        {
            return new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = (internalName) => FieldShim
            };
        }

        private ShimSPForm InitializeSPFormShim()
        {
            return new ShimSPForm
            {
                ServerRelativeUrlGet = () => ServerRelativeUrl
            };
        }
        private ShimSPFormCollection InitializeSPFormsShim()
        {
            return new ShimSPFormCollection
            {
                ItemGetPAGETYPE = (pageType) => FormShim
            };
        }

        private ShimSPUser InitializeSPUserShim()
        {
            return new ShimSPUser();
        }

        private ShimSPUserCollection InitializeSPUsersShim()
        {
            return new ShimSPUserCollection
            {
                GetByIDInt32 = id => UserShim
            }
            .Bind(new SPUser[] { UserShim });
        }

        private ShimSPGroup InitializeSPGroupShim()
        {
            return new ShimSPGroup
            {
                UsersGet = () => UsersShim
            };
        }

        private ShimSPGroupCollection InitializeSPGroupsShim()
        {
            return new ShimSPGroupCollection()
            {
                GetByIDInt32 = id => GroupShim
            }
            .Bind(new SPGroup[] { GroupShim });
        }

        private ShimSPPrincipal InitializeSPPrincipalShim()
        {
            return new ShimSPPrincipal(GroupShim);
        }

        private ShimSPRoleAssignment InitializeSPRoleAssignmentShim()
        {
            return new ShimSPRoleAssignment
            {
                MemberGet = () => PrincipalShim
            };
        }

        private ShimSPRoleAssignmentCollection InitializeSPRoleAssignmentsShim()
        {
            return new ShimSPRoleAssignmentCollection()
                .Bind(new SPRoleAssignment[] { RoleAssignmentShim });
        }

        private ShimSPWeb InitializeSPWebShim()
        {
            return new ShimSPWeb
            {
                CurrentUserGet = () => UserShim,
                ServerRelativeUrlGet = () => ServerRelativeUrl,
                ListsGet = () => ListsShim,
                SiteGet = () => SiteShim,
                GroupsGet = () => GroupsShim,
                EnsureUserString = userName => UserShim
            };
        }

        private ShimSPListCollection InitializeSPListCollectionShim()
        {
            return new ShimSPListCollection
            {
                ItemGetString = key => ListShim,
                ItemGetGuid = key => ListShim,
                ItemGetInt32 = key => ListShim
            };
        }

        private ShimSPListItem InitializeSPListItemShim()
        {
            return new ShimSPListItem
            {
                ParentListGet = () => ListShim,
                ItemSetStringObject = (liName, value) =>
                {
                    if (liName == "URL")
                    {
                        WorkspaceUrl = value.ToString();
                    }
                },
                Update = () => IsDbUpdateExecuted = true,
            };
        }

        private ShimSPList InitializeSPListShim()
        {
            return new ShimSPList
            {
                ItemsGet = () => ListItemsShim,
                FormsGet = () => FormsShim,
                FieldsGet = () => FieldsShim,
                GetItemByIdInt32 = id => ListItemShim,
                GetItemsSPQuery = query => ListItemsShim,
                GetItemByUniqueIdGuid = id => ListItemShim
            };
        }

        private ShimSPListItemCollection InitializeSPListItemCollectionShim()
        {
            return new ShimSPListItemCollection
            {
                Add = () => ListItemShim
            }
            .Bind(new ShimSPListItem[] { });
        }

        private ShimSPSite InitializeSPSiteShim()
        {
            return new ShimSPSite
            {
                WebApplicationGet = () => ApplicationShim
            };
        }

        private ShimSPFieldUserValue InitializeSPFieldUserValueShim()
        {
            return new ShimSPFieldUserValue
            {
                UserGet = () => UserShim
            };
        }
        private ShimSPFieldUserValueCollection InitializeSPFieldUserValuesShim()
        {
            var result = new SPFieldUserValueCollection();

            result.Add(FieldUserValueShim);
            return new ShimSPFieldUserValueCollection(result);
        }

        private ShimSPWebApplication InitializeSPApplicationShim()
        {
            return new ShimSPWebApplication();
        }
        
        public static SharepointShims ShimSharepointCalls()
        {
            var result = new SharepointShims();
            result.InitializeStaticShims();

            return result;
        }

        private void InitializeStaticShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action =>
            {
                action();
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => WebShim
            };

            ShimSPSite.ConstructorGuid = (instance, guid) => new Func<ShimSPSite>(() => SiteShim)();
            ShimSPSite.ConstructorString = (instance, url) => new Func<ShimSPSite>(() => SiteShim)();
            ShimSPSite.AllInstances.OpenWeb = instance => WebShim;
            ShimSPSite.AllInstances.OpenWebGuid = (instance, webId) => WebShim;
            ShimSPSite.AllInstances.WebApplicationGet = (instance) => ApplicationShim;

            ShimSPFieldUserValue.ConstructorSPWebString = (instance, web, fieldValue) => new Func<ShimSPFieldUserValue>(() => FieldUserValueShim)();
            ShimSPFieldUserValue.AllInstances.UserGet = instance => UserShim;

            ShimSPFieldLookupValue.ConstructorString = (instance, value) => { };

            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = instance => RoleAssignmentsShim;
        }
    }
}
