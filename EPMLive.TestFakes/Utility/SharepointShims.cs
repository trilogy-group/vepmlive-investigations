﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;

namespace EPMLive.TestFakes.Utility
{
    [ExcludeFromCodeCoverage]
    public class SharepointShims
    {
        public readonly static string DatabaseConnectionString = "test-db-connection-string";

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
        public ShimSPViewFieldCollection ViewFieldsShim { get; private set; }
        public ShimSPView ViewShim { get; private set; }
        public ShimSPContentDatabase ContentDatabaseShim { get; private set; }

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
            ViewFieldsShim = InitializeSPViewFieldCollectionShim();
            ViewShim = InitializeSPViewShim();
            ContentDatabaseShim = InitializeSPContentDatabase();
        }

        private ShimSPField InitializeSPFieldShim()
        {
            return new ShimSPField
            {
                InternalNameGet = () => "test-field"
            };
        }

        private ShimSPFieldCollection InitializeSPFieldsShim()
        {
            var result = new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = (internalName) => 
                {
                    var fieldShim = InitializeSPFieldShim();
                    fieldShim.InternalNameGet = () => internalName;
                    return fieldShim;
                }
            };
            result.Bind(new SPField[] { FieldShim });

            return result;
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
                FieldsGet = () => FieldsShim
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
                WebApplicationGet = () => ApplicationShim,
                ContentDatabaseGet = () => ContentDatabaseShim,
                RootWebGet = () => WebShim
            };
        }

        private ShimSPContentDatabase InitializeSPContentDatabase()
        {
            return new ShimSPContentDatabase { };
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

        private ShimSPView InitializeSPViewShim()
        {
            return new ShimSPView
            {
                ParentListGet = () => ListShim,
                ViewFieldsGet = () => ViewFieldsShim
            };
        }

        private ShimSPViewFieldCollection InitializeSPViewFieldCollectionShim()
        {
            var result = new ShimSPViewFieldCollection();
            result.Bind(new[] { "test-field-1" });
            return result;
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
            ShimSPFarm.LocalGet = () => new ShimSPFarm();

            ShimSPFieldUserValue.ConstructorSPWebString = (instance, web, fieldValue) => new Func<ShimSPFieldUserValue>(() => FieldUserValueShim)();
            ShimSPFieldUserValue.AllInstances.UserGet = instance => UserShim;

            ShimSPFieldLookupValue.ConstructorString = (instance, value) => { };

            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = instance => RoleAssignmentsShim;
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = instance => DatabaseConnectionString;
        }
    }
}
