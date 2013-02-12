using System;
using System.IO;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class SaveCurrentSiteAsTemplate : LayoutsPageBase
    {
        protected string Result;

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SPUtility.ValidateFormDigest();

                var siteId = SPContext.Current.Site.ID;

                var web = SPContext.Current.Web;
                var webId = web.ID;
                var safeServerRelativeUrl = web.SafeServerRelativeUrl();

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(siteId))
                    {
                        using (var spWeb = spSite.OpenWeb(webId))
                        {
                            string templateName = string.Format("{0}.wsp", Path.GetFileName(safeServerRelativeUrl));
                            bool includeContent = true;

                            SPUserSolution currentTemplate = (from SPUserSolution s in spWeb.Site.Solutions 
                                                          let name = s.Name where name.Equals(templateName) select s).FirstOrDefault();

                            if (currentTemplate != null)
                            {
                                spWeb.Site.Solutions.Remove(currentTemplate);

                                SPList solGallery = spWeb.Site.RootWeb.Site.GetCatalog(SPListTemplateType.SolutionCatalog);
                                foreach (SPListItem item in solGallery.Items.Cast<SPListItem>().Where(item => item.File.Name.Equals(templateName)))
                                {
                                    solGallery.Items.DeleteItemById(item.ID);
                                    break;
                                }
                            }

                            SPList spList = spWeb.Site.RootWeb.Lists.TryGetList("Template Gallery");

                            if (spList != null)
                            {
                                SPListItem listItem = (from SPListItem spListItem in spList.Items
                                                       let spFieldUrlValue = new SPFieldUrlValue(spListItem["URL"].ToString())
                                                       where  new Uri(spFieldUrlValue.Url).AbsolutePath.ToLower().Equals(spWeb.ServerRelativeUrl.ToLower())
                                                       select spListItem).FirstOrDefault();

                                if (listItem != null)
                                {
                                    bool.TryParse(listItem["IncludeContent"].ToString(), out includeContent);
                                }
                            }

                            spWeb.SaveAsTemplate(templateName, spWeb.Title, spWeb.Description, includeContent);
                        }
                    }
                });

                Result = "SUCCESS";
            }
            catch(Exception exception)
            {
                Result = exception.Message;
            }
        }
    }
}
