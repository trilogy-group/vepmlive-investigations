using System;
using System.Globalization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Resources;
using NewsGator.Install.Common.Constants.Features;

namespace NewsGator.Install.Common.Utilities
{
    public static class Lookout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public static OutputQueue EnableLookoutFeature(string mySiteUrl)
        {
            return Features.EnableFeature(SocialPlatform.LookoutFeature, mySiteUrl, SPFeatureScope.Site);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "HomePage"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "1#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "outputManager"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        public static OutputQueue SetLookoutAsMySiteHomePage(string mySiteWebUrl)
        {
            var output = new OutputQueue();
            try
            {
                using (var site = new SPSite(mySiteWebUrl))
                {
                    if (site != null)
                    {
                        using (var web = site.OpenWeb())
                        {
                            if (web != null)
                            {
                                if (PublishingWeb.IsPublishingWeb(web))
                                {
                                    var publishingWeb = PublishingWeb.GetPublishingWeb(web);
                                    var lookoutPageFile = web.GetFile("Lookout.aspx");
                                    publishingWeb.DefaultPage = lookoutPageFile;
                                    publishingWeb.Update();
                                    publishingWeb.Close();
                                }
                                else
                                {
                                    var rootFolder = web.RootFolder;
                                    rootFolder.WelcomePage = "Lookout.aspx";
                                    rootFolder.Update();
                                    web.Update();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                output.Add(string.Format(CultureInfo.CurrentCulture, Exceptions.ErrorSettingLookoutHomePage, exception.Message), OutputType.Error, string.Empty, exception);
            }
            return output;
        }
    }
}
