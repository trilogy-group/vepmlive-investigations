using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NewsGator.Install.Resources;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Sites
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        internal static Collection<string> GetSitesUsingSocialSitesFeatures(Collection<Guid> solutionIds, bool includeWebTemplates)
        {
            var sites = new Collection<string>();

            if (solutionIds == null || solutionIds.Count == 0)
                solutionIds = Constants.Solutions.All.Get().Select(p => p.SolutionId).ToCollection();

            foreach (SPWebApplication webApplication in SPWebService.ContentService.WebApplications)
            {
                try
                {
                    foreach (SPSite site in webApplication.Sites)
                    {
                        try
                        {
                            if (!sites.Contains(site.Url) && site.Features.Any(p => solutionIds.Contains(p.Definition.SolutionId)))
                                sites.Add(site.Url);

                            foreach (SPWeb web in site.AllWebs)
                            {
                                try
                                {
                                    if (!sites.Contains(web.Url))
                                    {
                                        if ((web.Features.Any(p => solutionIds.Contains(p.Definition.SolutionId)))
                                            || (includeWebTemplates && (web.WebTemplate.StartsWith("NG", StringComparison.OrdinalIgnoreCase) || web.WebTemplate.StartsWith("NewsGator", StringComparison.OrdinalIgnoreCase))))
                                            sites.Add(web.Url);
                                    }
                                }
                                catch { }
                                finally
                                {
                                    if (web != null)
                                        web.Dispose();
                                }
                            }
                        }
                        catch { }
                        finally
                        {
                            if (site != null)
                                site.Dispose();
                        }
                    }
                }
                catch { }
            }

            return sites;
        }
    }
}

 