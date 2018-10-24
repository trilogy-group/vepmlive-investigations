using System;
using System.Data;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData : IDisposable
    {
        public ReportData(bool tmp, Guid siteId, Guid webId)
        {
            _siteId = siteId;
            DataRow sAccountInfo;

            using (var site = new SPSite(siteId))
            {
                SPWeb web;

                if (SPContext.Current != null)
                {
                    web = SPContext.Current.Web.IsRootWeb
                        ? site.OpenWeb()
                        : site.OpenWeb(webId);
                }
                else
                {
                    web = site.OpenWeb(webId);
                }

                _webId = web.ID;
                _isRootWeb = web.IsRootWeb;
                webTitle = web.Title;

                try
                {
                    _isReportingV2Enabled = Convert.ToBoolean(CoreFunctions.getConfigSetting(site.RootWeb, ReportingV2));
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    _isReportingV2Enabled = false;
                    SPContext.Current.Site.RootWeb.AllowUnsafeUpdates = true;
                    CoreFunctions.setConfigSetting(site.RootWeb, ReportingV2, "false");
                }

                _epmLiveCs = CoreFunctions.getConnectionString(site.WebApplication.Id);
                sAccountInfo = EPMData.SAccountInfo(siteId, site.WebApplication.Id);
            }

            if (sAccountInfo != null)
            {
                try
                {
                    var useSa = (bool)sAccountInfo[SAccount];

                    if (useSa)
                    {
                        _DAO = new EPMData(
                            _siteId,
                            sAccountInfo[DatabaseName].ToString().Replace(SingleQuote, string.Empty),
                            sAccountInfo["DatabaseServer"].ToString().Replace(SingleQuote, string.Empty),
                            true,
                            sAccountInfo["Username"].ToString().Replace(SingleQuote, string.Empty),
                            EPMData.Decrypt(sAccountInfo["Password"].ToString()).Replace(SingleQuote, string.Empty));
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                    else
                    {
                        _DAO = new EPMData(_siteId);
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    _DAO = new EPMData(_siteId);
                    _siteName = _DAO.SiteName;
                    _siteUrl = _DAO.SiteUrl;
                }
            }
            else
            {
                _DAO = new EPMData(_siteId);
                _siteName = _DAO.SiteName;
                _siteUrl = _DAO.SiteUrl;
            }
        }

        public ReportData(Guid siteId, Guid webAppId)
        {
            _siteId = siteId;
            _epmLiveCs = CoreFunctions.getConnectionString(webAppId);
            var sAccountInfo = EPMData.SAccountInfo(siteId, webAppId);

            if (sAccountInfo != null)
            {
                try
                {
                    var useSa = (bool)sAccountInfo[SAccount];

                    if (useSa)
                    {
                        _DAO = new EPMData(
                            _siteId,
                            sAccountInfo[DatabaseName].ToString().Replace(SingleQuote, string.Empty),
                            sAccountInfo["DatabaseServer"].ToString().Replace(SingleQuote, string.Empty),
                            true,
                            sAccountInfo["Username"].ToString().Replace(SingleQuote, string.Empty),
                            EPMData.Decrypt(sAccountInfo["Password"].ToString()).Replace(SingleQuote, string.Empty));

                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                    else
                    {
                        _DAO = new EPMData(_siteId, webAppId, true);
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    _DAO = new EPMData(_siteId, webAppId, true);
                    _siteName = _DAO.SiteName;
                    _siteUrl = _DAO.SiteUrl;
                }
            }
            else
            {
                _DAO = new EPMData(_siteId, webAppId, true);
                _siteName = _DAO.SiteName;
                _siteUrl = _DAO.SiteUrl;
            }
        }

        public ReportData(Guid siteId)
        {
            _siteId = siteId;
            DataRow sAccountInfo;

            using (var site = new SPSite(siteId))
            {
                var web = SPContext.Current != null
                    ? SPContext.Current.Web.IsRootWeb
                        ? site.OpenWeb()
                        : site.OpenWeb(SPContext.Current.Web.ID)
                    : site.OpenWeb();

                _webId = web.ID;
                _isRootWeb = web.IsRootWeb;
                webTitle = web.Title;

                try
                {
                    _isReportingV2Enabled = Convert.ToBoolean(CoreFunctions.getConfigSetting(site.RootWeb, ReportingV2));
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    _isReportingV2Enabled = false;
                    SPContext.Current.Site.RootWeb.AllowUnsafeUpdates = true;
                    CoreFunctions.setConfigSetting(site.RootWeb, ReportingV2, "false");
                }

                _epmLiveCs = CoreFunctions.getConnectionString(site.WebApplication.Id);
                sAccountInfo = EPMData.SAccountInfo(siteId, site.WebApplication.Id);
            }

            if (sAccountInfo != null)
            {
                try
                {
                    var useSa = (bool)sAccountInfo[SAccount];

                    if (useSa)
                    {
                        _DAO = new EPMData(
                            _siteId,
                            sAccountInfo[DatabaseName].ToString().Replace(SingleQuote, string.Empty),
                            sAccountInfo["DatabaseServer"].ToString().Replace(SingleQuote, string.Empty),
                            true,
                            sAccountInfo["Username"].ToString().Replace(SingleQuote, string.Empty),
                            EPMData.Decrypt(sAccountInfo["Password"].ToString()).Replace(SingleQuote, string.Empty));

                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                    else
                    {
                        _DAO = new EPMData(_siteId);
                        _siteName = _DAO.SiteName;
                        _siteUrl = _DAO.SiteUrl;
                    }
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    _DAO = new EPMData(_siteId);
                    _siteName = _DAO.SiteName;
                    _siteUrl = _DAO.SiteUrl;
                }
            }
            else
            {
                _DAO = new EPMData(_siteId);
                _siteName = _DAO.SiteName;
                _siteUrl = _DAO.SiteUrl;
            }
        }

        public ReportData(Guid siteId, string name, string server, bool useSAccount, string username, string password)
        {
            _siteId = siteId;
            _DAO = new EPMData(_siteId, name, server, useSAccount, username, password);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _DAO.Dispose();
            _cmdWithParams?.Dispose();

            _disposed = false;
        }
    }
}