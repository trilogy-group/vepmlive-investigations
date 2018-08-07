using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Entities.SharePoint
{
    [DataContract]
    internal class SharePointFarm
    {
        #region Properties
        [DataMember]
        internal Guid? Id { get; set; }
        [DataMember]
        internal string Version { get; set; }
        [DataMember]
        internal string Name { get; set; }
        [DataMember]
        internal string DefaultServiceAccount { get; set; }
        [DataMember]
        internal string Status { get; set; }
        [DataMember]
        internal Collection<Guid> Products { get; set; }
        [DataMember]
        internal Collection<SharePointServer> Servers { get; set; }
        [DataMember]
        internal Collection<SharePointService> Services { get; set; }
        [DataMember]
        internal Collection<SharePointProperty> Properties { get; set; }
        [DataMember]
        internal Collection<SharePointSolution> FarmSolutions { get; set; }
        [DataMember]
        internal Collection<SharePointFeature> FeatureDefinitions { get; set; }
        [DataMember]
        internal Collection<SharePointFeature> FarmFeatures { get; set; }
        [DataMember]
        internal Collection<SharePointWebApplication> WebApplications { get; set; }
        [DataMember]
        internal Collection<SharePointServiceApplication> ServiceApplications { get; set; }
        [DataMember]
        internal Collection<SharePointApplicationPool> ApplicationPools { get; set; }
        [DataMember]
        internal Collection<string> ManagedAccounts { get; set; }
        [DataMember]
        internal Collection<string> MySiteHostUrls { get; set; }
        [DataMember]
        internal Collection<SharePointUser> CentralAdministrationUsers { get; set; }
        #endregion

        #region Constructors
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal SharePointFarm()
        {
            this.Initialize();
        }
        #endregion

        #region Private Methods
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        private void Initialize()
        {
            var farm = LocalFarm.Get();
            if (farm != null)
            {
                this.Id = farm.Id;
                this.Version = farm.BuildVersion.ToString();
                this.Name = farm.DisplayName;
                this.Status = farm.Status.ToString();

                this.ManagedAccounts = Utilities.ApplicationPools.GetManagedAccountsNames();

                try
                {
                    this.DefaultServiceAccount = farm.DefaultServiceAccount.LookupName();
                }
                catch
                {
                    this.DefaultServiceAccount = null;
                }

                this.Products = new Collection<Guid>();
                if ((farm.Products != null) && (farm.Products.Any()))
                    this.Products.AddRange(farm.Products);

                if ((farm.Servers != null) && (farm.Servers.Count > 0))
                {
                    this.Servers = new Collection<SharePointServer>();
                    foreach (var farmServer in farm.Servers)
                    {
                        var server = new SharePointServer();
                        server.Address = farmServer.Address;
                        server.Id = farmServer.Id;
                        server.Name = farmServer.DisplayName;
                        server.Role = farmServer.Role.ToString();
                        server.Status = farmServer.Status.ToString();
                        
                        if ((farmServer.ServiceInstances != null) && (farmServer.ServiceInstances.Count > 0))
                        {
                            server.Services = new Collection<SharePointService>();
                            foreach (var serverService in farmServer.ServiceInstances)
                            {
                                var service = new SharePointService();
                                service.Id = serverService.Id;
                                service.Name = serverService.DisplayName;
                                service.Status = serverService.Status.ToString();
                                server.Services.Add(service);
                            }
                        }

                        this.Servers.Add(server);
                    }
                }

                if ((farm.Services != null) && (farm.Services.Count > 0))
                {
                    this.Services = new Collection<SharePointService>();
                    foreach (var farmService in farm.Services)
                    {
                        var service = new SharePointService();
                        service.Id = farmService.Id;
                        service.Name = farmService.DisplayName;
                        service.Status = farmService.Status.ToString();
                        this.Services.Add(service);
                    }
                }

                if ((farm.Properties != null) && (farm.Properties.Count > 0))
                    this.Properties = Utilities.Conversions.GetSharePointPropertiesFromHashtable(farm.Properties);                

                if ((farm.Solutions != null) && (farm.Solutions.Count > 0))
                {
                    this.FarmSolutions = new Collection<SharePointSolution>();
                    foreach (var farmSolution in farm.Solutions)
                    {
                        var solution = new SharePointSolution();
                        solution.Deployed = farmSolution.Deployed;
                        solution.Id = farmSolution.Id;
                        solution.Name = farmSolution.DisplayName;
                                                
                        if ((farmSolution.ContainsWebApplicationResource) && (farmSolution.Deployed) && (farmSolution.DeployedWebApplications != null) && (farmSolution.DeployedWebApplications.Count > 0))
                        {
                            solution.WebApplications = new Collection<string>();
                            solution.WebApplications.AddRange(farmSolution.DeployedWebApplications.Select(p => Utilities.WebApplications.GetWebApplicationName(p)));
                        }

                        this.FarmSolutions.Add(solution);
                    }
                }

                if ((farm.FeatureDefinitions != null) && (farm.FeatureDefinitions.Count > 0))
                {
                    this.FeatureDefinitions = new Collection<SharePointFeature>();
                    foreach (var farmFeature in farm.FeatureDefinitions)
                    {
                        var feature = new SharePointFeature();
                        feature.Id = farmFeature.Id;
                        feature.Name = farmFeature.DisplayName;
                        feature.Scope = farmFeature.Scope.ToString();
                        this.FeatureDefinitions.Add(feature);
                    }
                }

                var adminService = SPWebService.AdministrationService;
                var contentService = SPWebService.ContentService;

                if ((adminService.Features != null) && (adminService.Features.Count > 0))
                {
                    this.FarmFeatures = new Collection<SharePointFeature>();
                    foreach (var farmFeature in adminService.Features)
                    {
                        var feature = new SharePointFeature();
                        feature.Id = farmFeature.DefinitionId;
                        feature.Name = farmFeature.Definition.DisplayName;
                        feature.Scope = farmFeature.FeatureDefinitionScope.ToString();
                        this.FarmFeatures.Add(feature);
                    }
                }

                var webApplications = new Collection<SharePointWebApplication>();
                var farmWebApplications = new Collection<SPWebApplication>();

                if ((adminService.WebApplications != null) && (adminService.WebApplications.Count > 0))
                    farmWebApplications.AddRange(adminService.WebApplications);
                if ((contentService.WebApplications != null) && (contentService.WebApplications.Count > 0))
                    farmWebApplications.AddRange(contentService.WebApplications);

                if (farmWebApplications.Count > 0)
                {
                    foreach (var farmWebApplication in farmWebApplications)
                    {
                        var webApp = new SharePointWebApplication();
                        webApp.Id = farmWebApplication.Id;
                        webApp.Name = farmWebApplication.DisplayName;
                        webApp.Status = farmWebApplication.Status.ToString();
                        if ((farmWebApplication.Properties != null) && (farmWebApplication.Properties.Count > 0))
                            webApp.Properties = Utilities.Conversions.GetSharePointPropertiesFromHashtable(farmWebApplication.Properties);
                        webApp.IsCentralAdministration = farmWebApplication.IsAdministrationWebApplication;

                        webApp.UrlZoneCustom = Utilities.WebApplications.GetWebApplicationZoneUrl(farmWebApplication, SPUrlZone.Custom);
                        webApp.UrlZoneDefault = Utilities.WebApplications.GetWebApplicationZoneUrl(farmWebApplication, SPUrlZone.Default);
                        webApp.UrlZoneExtranet = Utilities.WebApplications.GetWebApplicationZoneUrl(farmWebApplication, SPUrlZone.Extranet);
                        webApp.UrlZoneInternet = Utilities.WebApplications.GetWebApplicationZoneUrl(farmWebApplication, SPUrlZone.Internet);
                        webApp.UrlZoneIntranet = Utilities.WebApplications.GetWebApplicationZoneUrl(farmWebApplication, SPUrlZone.Intranet);
                        
                        if ((farmWebApplication.Features != null) && (farmWebApplication.Features.Count > 0))
                        {
                            webApp.Features = new Collection<SharePointFeature>();
                            foreach (var farmFeature in farmWebApplication.Features)
                            {
                                var feature = new SharePointFeature();
                                feature.Id = farmFeature.DefinitionId;
                                feature.Name = farmFeature.Definition.DisplayName;
                                feature.Scope = farmFeature.FeatureDefinitionScope.ToString();
                                webApp.Features.Add(feature);
                            }
                        }

                        if ((farmWebApplication.Sites != null) && (farmWebApplication.Sites.Count > 0))
                        {
                            webApp.SiteCollections = new Collection<SharePointSiteCollection>();
                            foreach (SPSite webAppSite in farmWebApplication.Sites)
                            {
                                var site = new SharePointSiteCollection();
                                site.Id = webAppSite.ID;
                                site.Url = webAppSite.Url;

                                if ((webAppSite.EventReceivers != null) && (webAppSite.EventReceivers.Count > 0))
                                {
                                    site.EventReceivers = new Collection<SharePointEventReceiver>();
                                    foreach (SPEventReceiverDefinition siteEventReceiver in webAppSite.EventReceivers)
                                    {
                                        var eventReceiver = new SharePointEventReceiver();
                                        eventReceiver.Assembly = siteEventReceiver.Assembly;
                                        eventReceiver.Class = siteEventReceiver.Class;
                                        eventReceiver.Id = siteEventReceiver.Id;
                                        eventReceiver.Name = siteEventReceiver.Name;
                                        site.EventReceivers.Add(eventReceiver);
                                    }
                                }

                                if ((webAppSite.Features != null) && (webAppSite.Features.Count > 0))
                                {
                                    site.Features = new Collection<SharePointFeature>();
                                    foreach (var farmFeature in webAppSite.Features)
                                    {
                                        var feature = new SharePointFeature();
                                        feature.Id = farmFeature.DefinitionId;
                                        feature.Name = farmFeature.Definition.DisplayName;
                                        feature.Scope = farmFeature.FeatureDefinitionScope.ToString();
                                        site.Features.Add(feature);
                                    }
                                }

                                if ((webAppSite.AllWebs != null) && (webAppSite.AllWebs.Count > 0))
                                {
                                    site.Webs = new Collection<SharePointWeb>();
                                    foreach (SPWeb siteWeb in webAppSite.AllWebs)
                                    {
                                        try
                                        {
                                            var web = new SharePointWeb();
                                            web.Id = siteWeb.ID;
                                            web.CustomMasterPageUrl = siteWeb.CustomMasterUrl;
                                            web.Description = siteWeb.Description;
                                            web.IsRootWeb = siteWeb.IsRootWeb;
                                            web.LogoUrl = siteWeb.SiteLogoUrl;
                                            web.MasterPageUrl = siteWeb.MasterUrl;
                                            if (!siteWeb.IsRootWeb)
                                                web.ParentWebId = siteWeb.ParentWebId;
                                            if ((siteWeb.AllProperties != null) && (siteWeb.AllProperties.Count > 0))
                                                web.Properties = Utilities.Conversions.GetSharePointPropertiesFromHashtable(siteWeb.AllProperties);
                                            web.Title = siteWeb.Title;
                                            web.UIVersion = siteWeb.UIVersion;
                                            web.Url = siteWeb.Url;
                                            web.WebTemplate = siteWeb.WebTemplate;

                                            if ((siteWeb.EventReceivers != null) && (siteWeb.EventReceivers.Count > 0))
                                            {
                                                web.EventReceivers = new Collection<SharePointEventReceiver>();
                                                foreach (SPEventReceiverDefinition webEventReceiver in siteWeb.EventReceivers)
                                                {
                                                    var eventReceiver = new SharePointEventReceiver();
                                                    eventReceiver.Assembly = webEventReceiver.Assembly;
                                                    eventReceiver.Class = webEventReceiver.Class;
                                                    eventReceiver.Id = webEventReceiver.Id;
                                                    eventReceiver.Name = webEventReceiver.Name;
                                                    web.EventReceivers.Add(eventReceiver);
                                                }
                                            }

                                            if ((siteWeb.Features != null) && (siteWeb.Features.Count > 0))
                                            {
                                                web.Features = new Collection<SharePointFeature>();
                                                foreach (var farmFeature in siteWeb.Features)
                                                {
                                                    var feature = new SharePointFeature();
                                                    feature.Id = farmFeature.DefinitionId;
                                                    feature.Name = farmFeature.Definition.DisplayName;
                                                    feature.Scope = farmFeature.FeatureDefinitionScope.ToString();
                                                    web.Features.Add(feature);
                                                }
                                            }

                                            if ((siteWeb.Lists != null) && (siteWeb.Lists.Count > 0))
                                            {
                                                web.Lists = new Collection<SharePointList>();
                                                foreach (SPList webList in siteWeb.Lists)
                                                {
                                                    try
                                                    {
                                                        var list = new SharePointList();
                                                        list.Description = webList.Description;
                                                        list.Id = webList.ID;
                                                        list.ItemCount = webList.ItemCount;
                                                        list.Title = webList.Title;
                                                        list.Url = webList.DefaultViewUrl;

                                                        if ((webList.EventReceivers != null) && (webList.EventReceivers.Count > 0))
                                                        {
                                                            list.EventReceivers = new Collection<SharePointEventReceiver>();
                                                            foreach (SPEventReceiverDefinition listEventReceiver in webList.EventReceivers)
                                                            {
                                                                var eventReceiver = new SharePointEventReceiver();
                                                                eventReceiver.Assembly = listEventReceiver.Assembly;
                                                                eventReceiver.Class = listEventReceiver.Class;
                                                                eventReceiver.Id = listEventReceiver.Id;
                                                                eventReceiver.Name = listEventReceiver.Name;
                                                                list.EventReceivers.Add(eventReceiver);
                                                            }
                                                        }

                                                        web.Lists.Add(list);
                                                    }
                                                    catch { } // Don't Care
                                                }
                                            }

                                            siteWeb.Dispose();
                                            site.Webs.Add(web);
                                        }
                                        catch
                                        { } // Don't Care
                                    }

                                    if (webAppSite.ContentDatabase != null)
                                    {
                                        site.Database = new SharePointDatabase()
                                            {
                                                Id = webAppSite.ContentDatabase.Id,
                                                Name = webAppSite.ContentDatabase.DisplayName,
                                                Server = webAppSite.ContentDatabase.Server,
                                                Username = webAppSite.ContentDatabase.Username
                                            };                                        
                                    }
                                }

                                webAppSite.Dispose();
                                webApp.SiteCollections.Add(site);
                            }
                        }

                        if ((farmWebApplication.ContentDatabases != null) && (farmWebApplication.ContentDatabases.Count > 0))
                        {
                            webApp.Databases = new Collection<SharePointDatabase>();
                            foreach (var webAppDatabase in farmWebApplication.ContentDatabases)
                            {
                                webApp.Databases.Add(new SharePointDatabase()
                                {
                                    Id = webAppDatabase.Id,
                                    Name = webAppDatabase.DisplayName,
                                    Server = webAppDatabase.Server,
                                    Username = webAppDatabase.Username
                                });
                            }
                        }

                        webApplications.Add(webApp);
                    }
                }
                this.WebApplications = webApplications;

                this.ApplicationPools = new Collection<SharePointApplicationPool>();
                if ((adminService.ApplicationPools != null) && (adminService.ApplicationPools.Count > 0))
                {
                    foreach (var farmApplicationPool in adminService.ApplicationPools)
                    {
                        var appPool = new SharePointApplicationPool();
                        appPool.Id = farmApplicationPool.Id;
                        appPool.ManagedAccount = farmApplicationPool.ManagedAccount == null ? null : farmApplicationPool.ManagedAccount.DisplayName;
                        appPool.Name = farmApplicationPool.DisplayName;
                        appPool.ProcessAccount = farmApplicationPool.ProcessAccount == null ? null : farmApplicationPool.ProcessAccount.ToString();
                        appPool.TypeName = farmApplicationPool.TypeName;
                        appPool.Username = farmApplicationPool.Username;
                        this.ApplicationPools.Add(appPool);
                    }
                }
                if ((contentService.ApplicationPools != null) && (contentService.ApplicationPools.Count > 0))
                {
                    foreach (var farmApplicationPool in contentService.ApplicationPools)
                    {
                        var appPool = new SharePointApplicationPool();
                        appPool.Id = farmApplicationPool.Id;
                        appPool.ManagedAccount = farmApplicationPool.ManagedAccount == null ? null : farmApplicationPool.ManagedAccount.DisplayName;
                        appPool.Name = farmApplicationPool.DisplayName;
                        appPool.ProcessAccount = farmApplicationPool.ProcessAccount == null ? null : farmApplicationPool.ProcessAccount.ToString();
                        appPool.TypeName = farmApplicationPool.TypeName;
                        appPool.Username = farmApplicationPool.Username;
                        this.ApplicationPools.Add(appPool);
                    }
                }

                this.ServiceApplications = new Collection<SharePointServiceApplication>();
                foreach (var service in farm.Services)
                {
                    foreach (var farmServiceApp in service.Applications)
                    {
                        var farmServiceApplication = farmServiceApp as SPIisWebServiceApplication;
                        if (farmServiceApplication != null)
                        {
                            var serviceApp = new SharePointServiceApplication();
                            serviceApp.Id = farmServiceApplication.Id;
                            serviceApp.Name = farmServiceApplication.DisplayName;
                            serviceApp.Status = farmServiceApplication.Status.ToString();
                            serviceApp.Version = farmServiceApplication.ApplicationVersion;
                            serviceApp.AccessRules = new Collection<SharePointAccessRule>();
                            serviceApp.AdminAccessRules = new Collection<SharePointAccessRule>();

                            foreach (var accessRule in farmServiceApplication.GetAdministrationAccessControl().GetAccessRules())
                            {
                                serviceApp.AdminAccessRules.Add(new SharePointAccessRule()
                                {
                                    AllowedObjectRights = accessRule.AllowedObjectRights.ToString(),
                                    AllowedRights = accessRule.AllowedRights.ToString(),
                                    Description = accessRule.Description,
                                    Name = accessRule.Name
                                });
                            }

                            foreach (var accessRule in farmServiceApplication.GetAccessControl().GetAccessRules())
                            {
                                serviceApp.AccessRules.Add(new SharePointAccessRule()
                                {
                                    AllowedObjectRights = accessRule.AllowedObjectRights.ToString(),
                                    AllowedRights = accessRule.AllowedRights.ToString(),
                                    Description = accessRule.Description,
                                    Name = accessRule.Name
                                });
                            }

                            this.ServiceApplications.Add(serviceApp);
                        }
                    }
                }

                this.MySiteHostUrls = Utilities.MySite.FindMySiteUrls();

                if (adminService != null)
                {
                    var centralAdminWebApp = adminService.WebApplications.Where(p => p.IsAdministrationWebApplication).FirstOrDefault();
                    if (centralAdminWebApp != null)
                    {
                        var centralAdminWebAppUrl = Utilities.WebApplications.GetWebApplicationZoneUrl(centralAdminWebApp);
                        if (centralAdminWebAppUrl != null)
                        {
                            using (var centralAdminSite = new SPSite(centralAdminWebAppUrl))
                            {
                                if (centralAdminSite != null)
                                {
                                    var centralAdminWeb = centralAdminSite.RootWeb;
                                    if (centralAdminWeb != null)
                                    {
                                        this.CentralAdministrationUsers = new Collection<SharePointUser>();
                                        foreach (SPUser farmUser in centralAdminWeb.AllUsers)
                                        {
                                            var user = new SharePointUser()
                                            {
                                                Username = farmUser.LoginName,
                                                Permissions = new Collection<string>()
                                            };

                                            var effectivePermissions = centralAdminWeb.GetUserEffectivePermissions(farmUser.LoginName);

                                            foreach (SPBasePermissions permission in Enum.GetValues(typeof(SPBasePermissions)))
                                            {
                                                if ((effectivePermissions & permission) != 0)
                                                    user.Permissions.Add(permission.ToString());
                                            }

                                            this.CentralAdministrationUsers.Add(user);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
