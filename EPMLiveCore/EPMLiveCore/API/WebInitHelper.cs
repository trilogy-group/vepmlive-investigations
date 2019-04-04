using System;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class WebInitHelper
    {
        private const string featureGuid = "f78dc45f-b6bb-4d59-8f45-c73bbcd28a61";

        public static bool EeEnsureWebInitFeature(string webId, SPSite site, SPWeb web, SPSite eSite)
        {
            var success = true;

            if (webId != null)
            {
                try
                {
                    var workEngineListEventsFeatEnabled = false;

                    if (webId.Equals(web.ID))
                    {
                        foreach (var feat in web.Features)
                        {
                            if (feat.DefinitionId.Equals(new Guid(featureGuid)))
                            {
                                workEngineListEventsFeatEnabled = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        using (var spWeb = site.OpenWeb(new Guid(webId)))
                        {
                            foreach (var feat in spWeb.Features)
                            {
                                if (feat.DefinitionId.Equals(new Guid(featureGuid)))
                                {
                                    workEngineListEventsFeatEnabled = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!workEngineListEventsFeatEnabled)
                    {
                        using (var tempWeb = eSite.OpenWeb(new Guid(webId)))
                        {
                            tempWeb.Site.AllowUnsafeUpdates = true;
                            tempWeb.Site.RootWeb.AllowUnsafeUpdates = true;
                            tempWeb.AllowUnsafeUpdates = true;
                            tempWeb.Features.Add(new Guid(featureGuid));
                            tempWeb.Update();
                        }
                    }
                    else
                    {
                        using (var tempWeb = eSite.OpenWeb(new Guid(webId)))
                        {
                            tempWeb.Site.AllowUnsafeUpdates = true;
                            tempWeb.Site.RootWeb.AllowUnsafeUpdates = true;
                            tempWeb.AllowUnsafeUpdates = true;
                            tempWeb.Features.Remove(new Guid(featureGuid));
                            tempWeb.Features.Add(new Guid(featureGuid));
                            tempWeb.Update();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    success = false;
                }
            }

            return success;
        }
    }
}