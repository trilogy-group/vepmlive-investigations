using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using NewsGator.Install.Common.Output;
using NewsGator.Install.Common.Entities.Flags;
using NewsGator.Install.Resources;
using NewsGator.Install.Common.Entities.SocialSites;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Receivers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed"), System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.LinkDemand, Name = "FullTrust")]
        internal static OutputQueue RemoveEventReceivers(Collection<SolutionSet> solutionSets = null)
        {
            var outputQueue = new OutputQueue();

            try
            {
                outputQueue.Add(UserDisplay.EventReceiversRemoving);
                Collection<ReceiverPrefix> prefixes = new Collection<ReceiverPrefix>();

                if ((solutionSets == null) || (solutionSets.Count() == 0))
                    prefixes = Constants.ReceiverPrefixes.Get();
                else
                    prefixes = Constants.ReceiverPrefixes.Get().Where(p => solutionSets.Contains(p.SolutionSet)).ToCollection();

                if (prefixes.Any())
                {
                    var webApplications = new Collection<SPWebApplication>();
                    var siteCollections = new Collection<SPSite>();
                    var webs = new Collection<SPWeb>();
                    var lists = new Collection<SPList>();

                    webApplications.AddRange(SPWebService.AdministrationService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                    webApplications.AddRange(SPWebService.ContentService.WebApplications.Where(webApplication => webApplication.IisSettings.Count > 0));
                    foreach (var webApplication in webApplications)
                    {
                        if (webApplication.Sites != null)
                            siteCollections.AddRange(webApplication.Sites);
                    }
                    foreach (var site in siteCollections)
                    {
                        if (site.AllWebs != null)
                            webs.AddRange(site.AllWebs);
                    }
                    foreach (var web in webs)
                    {
                        if (web.EventReceivers != null)
                        {
                            if (web.EventReceivers.Count > 0)
                            {
                                foreach (SPEventReceiverDefinition receiver in web.EventReceivers)
                                {
                                    foreach (var prefix in prefixes)
                                    {
                                        if (receiver.Assembly.StartsWith(prefix.Prefix, StringComparison.OrdinalIgnoreCase))
                                        {
                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.EventReceiverRemovingWeb, web.Url, receiver.Class, receiver.Assembly));
                                            receiver.Delete();
                                            outputQueue.Add(UserDisplay.EventReceiverRemoved);
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (web.Lists != null)
                        {
                            foreach (SPList list in web.Lists)
                            {
                                lists.Add(list);
                            }
                        }
                    }

                    foreach (var list in lists)
                    {
                        if (list.EventReceivers != null)
                        {
                            if (list.EventReceivers.Count > 0)
                            {
                                foreach (SPEventReceiverDefinition receiver in list.EventReceivers)
                                {
                                    foreach (var prefix in prefixes)
                                    {
                                        if (receiver.Assembly.StartsWith(prefix.Prefix, StringComparison.OrdinalIgnoreCase))
                                        {
                                            outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, UserDisplay.EventReceiverRemovingList, list.DefaultViewUrl, receiver.Class, receiver.Assembly));
                                            receiver.Delete();
                                            outputQueue.Add(UserDisplay.EventReceiverRemoved);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                outputQueue.Add(UserDisplay.EventReceiversRemovingComplete);
            }
            catch (Exception exception)
            {
                outputQueue.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, Exceptions.ErrorRemovingEventReceivers, exception.Message), OutputType.Error, null, exception);
            }

            return outputQueue;
        }
    }
}
