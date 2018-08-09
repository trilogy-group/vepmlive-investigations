using System;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Principal;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.AccessControl;
using Microsoft.Office.Server.UserProfiles;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;
using System.Globalization;

namespace NewsGator.Install.Common.Utilities
{
    internal static class UserProfileService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue GetUserProfileApplication(out SPIisWebServiceApplication serviceApplication)
        {
            var outputQueue = new OutputQueue();

            serviceApplication = null;

            var serviceContext = SPServiceContext.GetContext(SPServiceApplicationProxyGroup.Default, new SPSiteSubscriptionIdentifier(Guid.Empty));

            try
            {
                var upmType = TypeUserProfileManager;
                var upapType = TypeUserProfileApplicationProxy;

                var upmConstructor = upmType.GetConstructor(new[] { typeof(SPServiceContext), typeof(bool), typeof(bool) });
                var upm = upmConstructor.Invoke(new object[] { serviceContext, false, false });
                var prop = upm.GetType().GetProperty("UserProfileApplicationProxy", BindingFlags.Instance | BindingFlags.NonPublic);

                var proxy = prop.GetValue(upm, null);
                var prop1 = upapType.GetProperty("UserProfileApplication", BindingFlags.Instance | BindingFlags.NonPublic);

                var app = prop1.GetValue(proxy, null);

                serviceApplication = app as SPIisWebServiceApplication;

                if (serviceApplication == null)
                    throw new ArgumentNullException(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.NullException, "serviceApplication"));
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.UserProfileServiceApplicationNotFound, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue UserHasAccess(out bool hasAccess, string accountName = null)
        {
            var outputQueue = new OutputQueue();
            hasAccess = false;

            if (string.IsNullOrEmpty(accountName))
                accountName = WindowsIdentity.GetCurrent().Name;

            var mossContext = SPServiceContext.GetContext(SPServiceApplicationProxyGroup.Default, new SPSiteSubscriptionIdentifier(Guid.Empty));

            using (var scope = new SPServiceContextScope(mossContext))
            {
                SPIisWebServiceApplication app = null;
                outputQueue.Add(GetUserProfileApplication(out app));
                if (app != null)
                {
                    var accessControl = app.GetAccessControl();
                    if (accessControl != null)
                    {
                        var accessRules = accessControl.GetAccessRules();

                        foreach (var rule in accessRules)
                        {
                            if (rule.Name.ToUpperInvariant().EndsWith(accountName.ToUpperInvariant(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                hasAccess = rule.AllowedRights == SPIisWebServiceApplicationRights.FullControl;
                                if (hasAccess)
                                    break;
                            }
                        }
                    }
                }
            }

            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue UserIsAdministrator(out bool isAdmin, string accountName = null)
        {
            var outputQueue = new OutputQueue();
            isAdmin = false;

            if (string.IsNullOrEmpty(accountName))
                accountName = WindowsIdentity.GetCurrent().Name;

            var mossContext = SPServiceContext.GetContext(SPServiceApplicationProxyGroup.Default, new SPSiteSubscriptionIdentifier(Guid.Empty));

            using (var scope = new SPServiceContextScope(mossContext))
            {
                SPIisWebServiceApplication app = null;
                outputQueue.Add(GetUserProfileApplication(out app));
                if (app != null)
                {
                    var adminAccessControl = app.GetAdministrationAccessControl();
                    if (adminAccessControl != null)
                    {
                        var accessRules = adminAccessControl.GetAccessRules();

                        foreach (var rule in accessRules)
                        {
                            if (rule.Name.ToUpperInvariant().EndsWith(accountName.ToUpperInvariant(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                isAdmin = rule.AllowedRights == SPCentralAdministrationRights.FullControl;
                                if (isAdmin)
                                    break;
                            }
                        }
                    }
                }
            }
            return outputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue EnsureUserAccess(string accountName = null)
        {
            var outputQueue = new OutputQueue();

            if (string.IsNullOrEmpty(accountName))
                accountName = WindowsIdentity.GetCurrent().Name;

            var mossContext = SPServiceContext.GetContext(SPServiceApplicationProxyGroup.Default, new SPSiteSubscriptionIdentifier(Guid.Empty));

            using (var scope = new SPServiceContextScope(mossContext))
            {
                SPIisWebServiceApplication app = null;
                outputQueue.Add(GetUserProfileApplication(out app));
                if (app != null)
                {
                    var isAdmin = false;
                    outputQueue.Add(UserIsAdministrator(out isAdmin, accountName));
                    if (!isAdmin)
                    {
                        var aac = app.GetAdministrationAccessControl();
                        aac.AddAccessRule(new SPAclAccessRule<SPCentralAdministrationRights>(new NTAccount(accountName), SPCentralAdministrationRights.FullControl));
                        app.SetAdministrationAccessControl(aac);
                    }

                    var hasAccess = false;
                    outputQueue.Add(UserHasAccess(out hasAccess, accountName));
                    if (!hasAccess)
                    {
                        var ac = app.GetAccessControl();
                        ac.AddAccessRule(new SPAclAccessRule<SPIisWebServiceApplicationRights>(new NTAccount(accountName), SPIisWebServiceApplicationRights.FullControl));
                        app.SetAccessControl(ac);
                    }
                    app.Update();
                }
            }

            return outputQueue;
        }

        private static Type TypeUserProfileApplicationProxy
        {
            get
            {
                return Types.TryGetType(string.Format(CultureInfo.InvariantCulture,
                    "Microsoft.Office.Server.Administration.UserProfileApplicationProxy, Microsoft.Office.Server.UserProfiles, Version={0}.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c",
                    LocalFarm.Get().BuildVersion.Major));
            }
        }

        private static Type TypeUserProfileManager
        {
            get
            {
                return Types.TryGetType(string.Format(CultureInfo.InvariantCulture,
                   "Microsoft.Office.Server.UserProfiles.UserProfileManager, Microsoft.Office.Server.UserProfiles, Version={0}.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c",
                   LocalFarm.Get().BuildVersion.Major));    
            }
        }
    }
}
