using System;
using System.Net;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    [UpgradeStep(Version = EPMLiveVersion.V55, Order = 1.0, Description = "Configuring Settings")]
    internal class ReplaceSettingsList55 : UpgradeStep
    {
        #region Fields (2) 

        private const string SETTINGS_LIST = "EPM Live Settings";
        private readonly string _storeUrl;

        #endregion Fields 

        #region Constructors (1) 

        public ReplaceSettingsList55(SPWeb spWeb, bool isPfeSite) : base(spWeb, isPfeSite)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true;

            _storeUrl = "https://store.workengine.com";
        }

        #endregion Constructors 

        #region Overrides of UpgradeStep

        public override bool Perform()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(Web.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(Web.ID))
                        {
                            if (!spWeb.IsRootWeb)
                            {
                                LogMessage(spWeb.Title + " is not a root web.", MessageKind.SKIPPED, 2);
                                return;
                            }

                            LogMessage("Downloading new " + SETTINGS_LIST + " list", 2);

                            var catalog =
                                (SPDocumentLibrary) Web.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

                            const string TEMPLATE_NAME = SETTINGS_LIST + " [5.5]";

                            using (var webClient = new WebClient())
                            {
                                byte[] bytes =
                                    webClient.DownloadData(_storeUrl + "/Upgrade/" + SETTINGS_LIST.ToLower() + ".stp");
                                SPFile file = catalog.RootFolder.Files.Add(SETTINGS_LIST.Replace(" ", "_") + "_55.stp",
                                    bytes, true);
                                SPListItem li = file.GetListItem();
                                li["Title"] = TEMPLATE_NAME;
                                li.SystemUpdate();
                            }

                            SPList list = Web.Lists.TryGetList(SETTINGS_LIST);
                            if (list != null)
                            {
                                LogMessage("Deleting old " + SETTINGS_LIST + " list", 2);

                                if (!list.AllowDeletion)
                                {
                                    list.AllowDeletion = true;
                                    list.Update();
                                }

                                list.Delete();

                                LogMessage(null, MessageKind.SUCCESS, 4);
                            }

                            LogMessage("Creating the " + SETTINGS_LIST + " list", 2);

                            SPListTemplateCollection listTemplates = spSite.GetCustomListTemplates(spWeb);
                            SPListTemplate template = listTemplates[TEMPLATE_NAME];

                            spWeb.Lists.Add(SETTINGS_LIST, string.Empty, template);

                            SPList spList = spWeb.Lists[SETTINGS_LIST];
                            spList.Title = SETTINGS_LIST;
                            spList.Hidden = true;
                            spList.AllowDeletion = false;
                            spList.Update();

                            LogMessage(null, MessageKind.SUCCESS, 4);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                LogMessage(e.Message, MessageKind.FAILURE, 2);
            }
            finally
            {
                try
                {
                    CacheStore.Current.RemoveSafely(Web.Url, new CacheStoreCategory(Web).Navigation);
                }
                catch { }
            }

            return true;
        }

        #endregion
    }
}