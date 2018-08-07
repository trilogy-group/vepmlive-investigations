using System.Collections.ObjectModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Constants.Features;

namespace NewsGator.Install.Common.Utilities
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public static class MySite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static OutputQueue EnableMySiteWebPartsFeature(string mySiteUrl)
        {
            return Features.EnableFeature(SocialPlatform.MySiteWebPartsFeature, mySiteUrl, SPFeatureScope.Site);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static OutputQueue EnableMySiteFixerFeature(string mySiteUrl)
        {
            return Features.EnableFeature(SocialPlatform.MySiteFixerFeature, mySiteUrl, SPFeatureScope.Site);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static string FindMySiteUrl()
        {
            try
            {
                var url = string.Empty;

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    if (SPWebService.ContentService != null)
                    {
                        if (SPWebService.ContentService.WebApplications != null)
                        {
                            foreach (SPWebApplication webApplication in SPWebService.ContentService.WebApplications)
                            {
                                try
                                {
                                    var instances = webApplication.QueryFeatures(Constants.Features.SocialPlatform.SharePointMySiteHostFeature);
                                    foreach (var featureInstance in instances)
                                    {
                                        try
                                        {
                                            var site = featureInstance.Parent as SPSite;
                                            if (site != null)
                                            {
                                                url = site.Url;
                                                break;
                                            }
                                        }
                                        catch { }
                                    }

                                    if (!string.IsNullOrEmpty(url))
                                        break;
                                }
                                catch { }
                            }
                        }
                    }
                });

                if (!string.IsNullOrEmpty(url))
                    return url;
            }
            catch { }

            return null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1055:UriReturnValuesShouldNotBeStrings"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static Collection<string> FindMySiteUrls()
        {
            var urls = new Collection<string>();

            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    if (SPWebService.ContentService != null)
                    {
                        if (SPWebService.ContentService.WebApplications != null)
                        {
                            foreach (SPWebApplication webApplication in SPWebService.ContentService.WebApplications)
                            {
                                try
                                {
                                    var instances = webApplication.QueryFeatures(Constants.Features.SocialPlatform.SharePointMySiteHostFeature);
                                    foreach (var featureInstance in instances)
                                    {
                                        try
                                        {
                                            var site = featureInstance.Parent as SPSite;
                                            if (site != null)
                                                urls.Add(site.Url);
                                        }
                                        catch { }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                });
            }
            catch { }

            return urls;
        }
    }
}
